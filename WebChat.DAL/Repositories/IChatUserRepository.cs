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
        public Task Delete(ChatUser chatUser); 
        public Task DeleteChat(IEnumerable<ChatUser> chatUsers);
        public IQueryable<ChatUser> GetAll(Func<ChatUser, bool> func);
        public IQueryable<ChatUser> GetAll();
        public Task SaveChangesAsync();
    }
}
