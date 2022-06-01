using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.Domain.Bots
{
    public class MessageBotInvoker : BaseBot<IMessageBot, Message>
    {
        public MessageBotInvoker(IOptions<BotOptions> options) : base(options)
        {

        }

        public override Task Invoke(IEnumerable<IMessageBot> bots, Message message)
        {
            foreach (var bot in bots)
            {
                var task = new Task(async () =>
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

                task.Start();
            }

            return Task.CompletedTask;
        }
    }
}
