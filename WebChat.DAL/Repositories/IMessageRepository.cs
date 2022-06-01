using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IMessageRepository
    {
        public Task Add(Message message);
        public Task Delete(Message message);
        public IQueryable<Message> GetAll();
        public Task SaveChangesAsync();
        public IQueryable<Message> GetChatMessages(Chat chat);
    }
}