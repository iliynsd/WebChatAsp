using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.Domain.BotServices;

namespace WebChat.Domain.Bots
{
    public class BotUploader : IMessageBot
    {
        private readonly IGoToUrlBotService _goToUrlBotService;

        public BotUploader(IGoToUrlBotService parGoToUrlBotService)
        {
            _goToUrlBotService = parGoToUrlBotService;
        }

        public async Task OnMessage(Message message)
        {
            var url = message.Text;
            if (url.Contains("http"))
            {
                await _goToUrlBotService.GoToUrl(message.ChatId, url);
            }
        }
    }
}
