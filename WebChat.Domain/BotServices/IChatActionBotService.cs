using System.Threading.Tasks;

namespace WebChat.Domain.BotServices
{
    public interface IChatActionBotService
    {
        public Task AddChatAction(string botName, int chatId, string action);
    }
}
