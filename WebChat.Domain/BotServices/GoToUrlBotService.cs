using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Repositories;

namespace WebChat.Domain.BotServices
{
    class GoToUrlBotService : IGoToUrlBotService
    {
        private const string BotUploaderName = "BotUploader";
        private IUserRepository _users;
        private IChatUserRepository _chatUserRepository;

        public GoToUrlBotService(IChatUserRepository chatUserRepository, IUserRepository users)
        {
            _users = users;
            _chatUserRepository = chatUserRepository;
        }

        public async Task GoToUrl(int chatId, string url)
        {
            var chatUsers = _chatUserRepository.GetAll(x => x.ChatId == chatId).Select(x => x.UserId);
            var bot = await _users.Get(BotUploaderName);

            if (chatUsers.Contains(bot.Id))
            {
                new ChromeDriver().Navigate().GoToUrl(url);
            }
        }
    }
}