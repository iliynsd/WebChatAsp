using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.DAL.PostgresRepositories
{
    public class PostgresChatActionsRepository : IChatActionsRepository
    {
        private DataContext _dataContext;

        public PostgresChatActionsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(ChatAction action) => await _dataContext.ChatActions.AddAsync(action);

        public IQueryable<ChatAction> GetAll() => _dataContext.ChatActions.AsQueryable();

        public async Task<ChatAction> Get(string chatActionText) => await _dataContext.ChatActions.Where(i => i.ActionText == chatActionText).FirstOrDefaultAsync();

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}