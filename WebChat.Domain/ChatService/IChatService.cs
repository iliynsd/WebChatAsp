using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.Domain.ChatModels;

namespace WebChat.Domain.ChatService
{
    public interface IChatService
    {
        public Task Create(CreateChatModel model);
        public Task Delete(int chatId);
        public Task AddUser(AddUserToChatModel model);
        public Task RemoveUserFromChat(RemoveUserFromChatModel model);
        public Task<IEnumerable<string>> GetUserChats(int userId);
    }
}