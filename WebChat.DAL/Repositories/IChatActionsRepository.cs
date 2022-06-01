using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public interface IChatActionsRepository
    {
        public Task Add(ChatAction action);
        public IQueryable<ChatAction> GetAll();
        public Task<ChatAction> Get(string chatActionText);
        public Task SaveChangesAsync();
    }
}