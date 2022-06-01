using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.Domain.Bots
{
    public interface IMessageBot
    {
        public Task OnMessage(Message message);
    }
}