using System.Threading.Tasks;

namespace WebChat.Domain.BotServices
{
    public interface IGoToUrlBotService
    {
        public Task GoToUrl(int chatId, string url);
    }
}
