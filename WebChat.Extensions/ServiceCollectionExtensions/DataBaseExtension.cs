using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.DAL;
using WebChat.DAL.PostgresRepositories;
using WebChat.DAL.Repositories;

namespace WebChat.Extensions.ServiceCollectionExtensions
{
    public static class DataBaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DataContext>(options =>
             {
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                     a => a.MigrationsAssembly("WebChat.DAL.Migrations"));
             })
             .AddTransient<IMessageRepository, PostgresMessageRepository>()
             .AddTransient<IChatRepository, PostgresChatRepository>()
             .AddTransient<IChatUserRepository, PostgresChatUserRepository>()
             .AddTransient<IUserRepository, PostgresUserRepository>()
             .AddTransient<IChatActionsRepository, PostgresChatActionsRepository>();
        }
    }
}
