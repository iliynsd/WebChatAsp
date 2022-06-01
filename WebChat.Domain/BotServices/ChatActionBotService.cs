
using System.Threading.Tasks;
using WebChat.DAL;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.Domain.BotServices
{
    public class ChatActionBotService : IChatActionBotService
    {
        private IChatRepository _chats;
        private IChatActionsRepository _chatActions;

        public ChatActionBotService(IChatRepository chats, IChatActionsRepository chatActions)
        {
            _chats = chats;
            _chatActions = chatActions;
        }

        public async Task AddChatAction(string botName, int chatId, string text)
        {
            var chat = await _chats.GetChatById(chatId);
            var action = new ChatAction(ChatActions.BotAddMessage(botName, chat.Name, text));
            await _chatActions.Add(action);
            await _chatActions.SaveChangesAsync();
        }

        
    }
}