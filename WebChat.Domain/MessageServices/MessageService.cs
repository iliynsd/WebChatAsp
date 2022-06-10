using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;
using WebChat.Domain.Bots;
using WebChat.Domain.MessageModels;

namespace WebChat.Domain.MessageServices
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        private IBotIoC _botIoC;
        private IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IMapper mapper, IBotIoC botIoC)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _botIoC = botIoC;
        }

        public async Task Add(AddMessageModel model)
        {
            var message = _mapper.Map<Message>(model);
            await _messageRepository.Add(message);
            await _messageRepository.SaveChangesAsync();
            var bots = _botIoC.GetServices<IMessageBot>().ToList();
            var botInvoker = _botIoC.Get<IBotsInvoker<IMessageBot, Message>>();
            await botInvoker.Invoke(bots, message);
        }

        public async Task Delete(int messageId)
        {
            await _messageRepository.Delete(messageId);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task Edit(EditMessageModel model)
        {
            var message = _mapper.Map<Message>(model);
            await _messageRepository.Update(message);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageResponse>> Get(int chatId)
        {
            var messages = _messageRepository.GetChatMessages(chatId).ToList();
            messages.ForEach(m => m.IsViewed = true);
            var userIds = messages.Select(m => m.UserId);
            var users = _userRepository.GetAll().Where(x => userIds.Contains(x.Id)).ToList();
            var messagesWithUsers = messages.Zip(users);

            return await Task.FromResult(MapMessageResponse(messagesWithUsers));

            IEnumerable<MessageResponse> MapMessageResponse(IEnumerable<(Message mes, User user)> messagesWithUsers)
            {
                foreach (var messageWithUser in messagesWithUsers)
                {
                    yield return _mapper.Map<MessageResponse>((messageWithUser.mes, messageWithUser.user));
                }
            }
        }
    }
}
