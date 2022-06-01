using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.DAL.PostgresRepositories
{
    public class PostgresMessageRepository : IMessageRepository
    {
        private DataContext _dataContext;

        public PostgresMessageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Message message) => await _dataContext.Messages.AddAsync(message);

        public async Task Delete(Message message) => (await _dataContext.Messages.FirstOrDefaultAsync(i => i.Id == message.Id)).IsActive = false;
        
        public IQueryable<Message> GetAll() => _dataContext.Messages.Where(i => i.IsActive).AsQueryable();

        public IQueryable<Message> GetChatMessages(Chat chat) => _dataContext.Messages.Where(i => i.IsActive).Where(i => i.ChatId == chat.Id).AsQueryable();

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}