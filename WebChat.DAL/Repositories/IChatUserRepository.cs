using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IChatUserRepository
    {
        public Task Add(ChatUser chatUser);
        public Task Delete(int id);
        public IQueryable<ChatUser> GetAll();
        public Task SaveChangesAsync();
    }
}
