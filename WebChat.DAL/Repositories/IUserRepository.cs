using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task Delete(User user);
        public Task<User> Get(string email);
        public IQueryable<User> GetAll();
        public Task SaveChangesAsync();
    }
}