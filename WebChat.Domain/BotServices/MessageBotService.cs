using System.Linq;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.Domain.BotServices
{
    public class MessageBotService : IMessageBotService
    {
        private IMessageRepository _messages;
        private IUserRepository _users;
        private IChatUserRepository _chatUserRepository;

        public MessageBotService(IMessageRepository messages, IChatUserRepository chatUsersRepository, IUserRepository users)
        {
            _messages = messages;
            _users = users;
            _chatUserRepository = chatUsersRepository;
        }

        public async Task AddMessage(string botName, int chatId, string answer)
        {
            var chatUsers = _chatUserRepository.GetAll(x => x.ChatId == chatId).Select(x => x.UserId);
            var bot = await _users.Get(botName);

            if (chatUsers.Contains(bot.Id))
            {
                var message = new Message(bot.Id, chatId, answer);
                await _messages.Add(message);
                await _messages.SaveChangesAsync();
            }
        }
    }
}