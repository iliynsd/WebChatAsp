using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.DAL.PostgresRepositories
{
    public class PostgresUserRepository : IUserRepository
    {
        private DataContext _dataContext;

        public PostgresUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(User user) => await _dataContext.Users.AddAsync(user);

        public async Task Delete(User user) => (await _dataContext.Users.FirstOrDefaultAsync(i => i.Id == user.Id)).IsActive = false;

        public async Task<User> Get(string email) => await _dataContext.Users.FirstOrDefaultAsync(i => i.Email == email);

        public IQueryable<User> GetAll() => _dataContext.Users.AsQueryable();

        public async Task<User> GetById(int userId) => await _dataContext.Users.FirstOrDefaultAsync(i => i.Id == userId);

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}