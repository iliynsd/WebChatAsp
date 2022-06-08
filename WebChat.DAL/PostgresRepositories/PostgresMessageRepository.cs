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

        public async Task Delete(int messageId) => (await _dataContext.Messages.FirstOrDefaultAsync(i => i.Id == messageId)).IsActive = false;
        
        public IQueryable<Message> GetAll() => _dataContext.Messages.Where(i => i.IsActive).AsQueryable();

        public IQueryable<Message> GetChatMessages(int chatId) => _dataContext.Messages.Where(i => i.IsActive).Where(i => i.ChatId == chatId).AsQueryable();

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();

        public async Task Update(Message message) => await Task.Run(() => _dataContext.Update(message));
    }
}