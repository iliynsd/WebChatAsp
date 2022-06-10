using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.Domain.Bots
{
    public class MessageBotInvoker : BaseBot<IMessageBot, Message>
    {
        BotOptions botOptions;
        public MessageBotInvoker(IOptions<BotOptions> options) : base(options)
        {
            botOptions = options.Value;
        }

        public override async Task Invoke(IEnumerable<IMessageBot> bots, Message message)
        {
            foreach (var bot in bots)
            {
                await Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        await bot.OnMessage(message);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });
            }
        }
    }
}
