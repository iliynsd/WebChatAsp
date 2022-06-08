using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IMessageRepository
    {
        public Task Add(Message message);
        public Task Delete(int messageId);
        public IQueryable<Message> GetAll();
        public Task SaveChangesAsync();
        public Task Update(Message message);  
        public IQueryable<Message> GetChatMessages(int chatId);
    }
}