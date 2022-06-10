using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.Domain.BotServices;

namespace WebChat.Domain.Bots
{
    public class ClockBot : IMessageBot
    {
        private const string Name = "ClockBot";
        private readonly IMessageBotService _messageService;
        private Dictionary<string, Func<string>> _botCommands;

        public ClockBot(IMessageBotService messageService)
        {
            _botCommands = new Dictionary<string, Func<string>>()
             {
                 {"time",() => DateTime.Now.ToString()},
                 {"early",() => DateTime.Now.AddMinutes(5).ToString()},
                 {"clockbot", () => DateTime.Now.ToString()}
             };
            _messageService = messageService;
        }

        public async Task OnMessage(Message message)
        {
            if (_botCommands.ContainsKey(message.Text))
            {
                var botAnswer = _botCommands[message.Text]?.Invoke();
                await _messageService.AddMessage(Name, message.ChatId, botAnswer);
            }
        }
    }
}
