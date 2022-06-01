using System.Threading.Tasks;

namespace WebChat.Domain.BotServices
{
    public interface IGoToUrlBotService
    {
        public Task GoToUrl(string botName, int chatId, string url);
    }
}
