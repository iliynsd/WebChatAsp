using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebChat.Domain.Bots;
using WebChat.Domain.ChatService;
using WebChat.Domain.MapperConfiguration;
using WebChat.Domain.MessageServices;
using WebChat.Domain.UserServices;
using WebChat.Extensions.ServiceCollectionExtensions;
using WebChat.IdentityServer;
using WebChat.IdentityServer.Options;

namespace WebChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDatabase(Configuration);
            services.AddAutoMapper(typeof(UserProfile), typeof(ChatProfile), typeof(MessageProfile));

            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptions.Authorization).Bind);

            services.AddScoped<IBotIoC, BotIoC>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}