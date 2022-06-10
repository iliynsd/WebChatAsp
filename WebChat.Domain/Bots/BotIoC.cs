using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;
using WebChat.Domain.BotServices;

namespace WebChat.Domain.Bots
{
    public class BotIoC : IBotIoC
    {
        private ServiceProvider provider;

        public BotIoC(IServiceProvider serviceProvider)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json")
                .Build();
            var services = new ServiceCollection();

            services.AddScoped<IMessageBotService, MessageBotService>((_) => new MessageBotService(serviceProvider.GetRequiredService<IMessageRepository>(), serviceProvider.GetRequiredService<IChatUserRepository>(), serviceProvider.GetRequiredService<IUserRepository>()));
            services.AddScoped<IGoToUrlBotService, GoToUrlBotService>((_) => new GoToUrlBotService(serviceProvider.GetRequiredService<IChatUserRepository>(), serviceProvider.GetRequiredService<IUserRepository>()));
            services.AddScoped<IMessageBot, ClockBot>();
            services.AddScoped<IMessageBot, BotUploader>();

            services.Configure<BotOptions>(configuration.GetSection(BotOptions.Threads).Bind);
            services.AddScoped<IBotsInvoker<IMessageBot, Message>, MessageBotInvoker>();
            provider = services.BuildServiceProvider();
        }

        public T Get<T>() => provider.GetRequiredService<T>();

        public IEnumerable<T> GetServices<T>() => provider.GetServices<T>();
    }
}