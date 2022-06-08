using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.DAL.PostgresRepositories
{
    public class PostgresChatUserRepository : IChatUserRepository
    {
        private DataContext _dataContext;

        public PostgresChatUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(ChatUser chatUser) => await _dataContext.ChatUser.AddAsync(chatUser);

        public async Task Delete(int id) 
        {
            var chatUser = await _dataContext.ChatUser.FirstOrDefaultAsync(x => x.Id == id);
            await Task.Run(() => _dataContext.ChatUser.Remove(chatUser));
        }

        public async Task<ChatUser> Find(Func<ChatUser, bool> func) => await Task.Run(() => _dataContext.ChatUser.Where(func).FirstOrDefault());

        public async Task Delete(ChatUser chatUser) => await Task.Run(() => _dataContext.ChatUser.Remove(chatUser));

        public async Task DeleteChat(IEnumerable<ChatUser> chatUsers) => await Task.Run(() => _dataContext.ChatUser.RemoveRange(chatUsers));
        
        public IQueryable<ChatUser> GetAll(Func<ChatUser, bool> func) => _dataContext.ChatUser.Where(func).AsQueryable();

        public IQueryable<ChatUser> GetAll() => _dataContext.ChatUser.AsQueryable();

        public async Task SaveChangesAsync() => await _dataContext.SaveChangesAsync();
    }
}