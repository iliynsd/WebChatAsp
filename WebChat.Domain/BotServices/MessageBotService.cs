using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.Domain.BotServices
{
    public class MessageBotService : IMessageBotService
    {
        private IMessageRepository _messages;
        private IChatRepository _chats;
        private IChatActionsRepository _chatActions;
        private IUserRepository _users;

        public MessageBotService(IMessageRepository messages, IChatRepository chats, IChatActionsRepository chatActions, IUserRepository users)
        {
            _messages = messages;
            _chats = chats;
            _chatActions = chatActions;
            _users = users;
        }

        public async Task AddMessage(string botName, int chatId, string answer)
        {
            var bot = await _users.Get(botName);
            var chat = await _chats.GetChatById(chatId);

            //проверить находится ли бот в чате
                var message = new Message(bot.Id, chat.Id, answer);
                await _messages.Add(message);
                var action = new ChatAction(ChatActions.UserAddMessage(botName, chat.Name, answer));
                await _chatActions.Add(action);
            

            await _messages.SaveChangesAsync();
            await _chatActions.SaveChangesAsync();
        }
    }
}