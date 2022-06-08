using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;
using WebChat.Domain.MessageModels;

namespace WebChat.Domain.MessageServices
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;
        private IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task Add(AddMessageModel model)
        {
            var message = _mapper.Map<Message>(model);
            await _messageRepository.Add(message);
            await _messageRepository.SaveChangesAsync();
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
            return await Task.FromResult(_mapper.Map<List<MessageResponse>>(messages));
        }
    }
}
