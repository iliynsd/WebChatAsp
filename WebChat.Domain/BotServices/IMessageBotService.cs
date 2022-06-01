using System.Threading.Tasks;

namespace WebChat.Domain.BotServices
{
    public interface IMessageBotService
    {
        public Task AddMessage(string botName, int chatId, string answer);
    }
}
