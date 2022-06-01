using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IChatRepository
    {
        public Task Add(Chat chat);
        public Task Delete(Chat chat);
        public IQueryable<Chat> GetAll();
        public Task SaveChangesAsync();
        public Task<Chat> GetChat(string chatName);
        public Task<Chat> GetChatById(int id);
    }
}