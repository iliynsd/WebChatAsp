using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;
using WebChat.Domain.ChatModels;

namespace WebChat.Domain.ChatService
{
    [Authorize]
    public class ChatService : IChatService
    {
        private IChatRepository _chatRepository;
        private IChatUserRepository _chatUserRepository;
        private IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IChatUserRepository chatUserRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
        }

        public async Task<> Create(CreateChatModel model)
        {
            var chat = _mapper.Map<Chat>(model);
            await _chatRepository.Add(chat);
            await _chatRepository.SaveChangesAsync();
            var addedChat = await _chatRepository.GetChat(chat.Name);
            var chatUser = _mapper.Map<ChatUser>((model, addedChat.Id));
            await _chatUserRepository.Add(chatUser);
            await _chatUserRepository.SaveChangesAsync();
        }
        
        public async Task AddUser(AddUserToChatModel model)
        {
            var chatUser = _mapper.Map<ChatUser>(model);
            await _chatUserRepository.Add(chatUser);
            await _chatUserRepository.SaveChangesAsync();
        }

        public async Task Delete(int chatId)
        {
            var chatUsers = _chatUserRepository.GetAll(x => x.ChatId == chatId);
            await _chatUserRepository.DeleteChat(chatUsers);
            await _chatRepository.Delete(chatId);
            await _chatRepository.SaveChangesAsync();
        }

        public async Task RemoveUserFromChat(RemoveUserFromChatModel model)
        {
            var chatUser = _mapper.Map<ChatUser>(model);
            await _chatUserRepository.Delete(chatUser);
            await _chatUserRepository.SaveChangesAsync();
        }
    }
}