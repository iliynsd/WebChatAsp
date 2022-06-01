using System.Threading;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.Domain.BotServices;

namespace WebChat.Domain.Bots
{
    public class BotUploader : IMessageBot
    {
        public const string Name = "BotUploader";
        private readonly IGoToUrlBotService _goToUrlBotService;

        public BotUploader(IGoToUrlBotService parGoToUrlBotService)
        {
            _goToUrlBotService = parGoToUrlBotService;
        }

        public Task OnMessage(Message message)
        {

            var url = message.Text;
            if (url.Contains("http"))
            {
                Thread.Sleep(6000);
                _goToUrlBotService.GoToUrl(Name, message.ChatId, url);
            }
            return Task.CompletedTask;
        }
    }
}
