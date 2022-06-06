using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.DAL.PostgresRepositories
{
    public class PostgresChatRepository : IChatRepository
    {
        private DataContext _dataContext;

        public PostgresChatRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Chat chat) => await _dataContext.Chats.AddAsync(chat);

        public async Task Delete(int chatId) => (await _dataContext.Chats.FirstOrDefaultAsync(i => i.Id == chatId)).IsActive = false;
          
        public IQueryable<Chat> GetAll() => _dataContext.Chats.Where(i => i.IsActive).AsQueryable();

        public async Task<Chat> GetChat(string chatName) => await _dataContext.Chats.Where(i => i.IsActive).FirstOrDefaultAsync(i => i.Name == chatName);

        public async Task<Chat> GetChatById(int id) => await _dataContext.Chats.Where(i => i.IsActive).FirstOrDefaultAsync(i => i.Id == id);

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}
