﻿

using System.Threading.Tasks;
using WebChat.DAL;
using WebChat.DAL.Repositories;

namespace WebChat.Domain.BotServices
{
    class GoToUrlBotService : IGoToUrlBotService
    {
        private IChatRepository _chats;
        private IUserRepository _users;

        public GoToUrlBotService(IChatRepository chats, IUserRepository users)
        {
            _chats = chats;
            _users = users;
        }

        public async Task GoToUrl(string botName, int chatId, string url)
        {
            var bot = await _users.Get(botName);
            var chat = await _chats.GetChatById(chatId);

            //проверить находится ли бот в данном чате
          //  new OpenQA.Selenium.Chrome.ChromeDriver().Navigate().GoToUrl(url);
            
        }
    }
}