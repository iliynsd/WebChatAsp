using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebChat.DAL;
using WebChat.DAL.PostgresRepositories;
using WebChat.DAL.Repositories;
using WebChat.Domain.ChatService;
using WebChat.Domain.MapperConfiguration;
using WebChat.Domain.UserServices;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(config => 
            {
                byte[] secretBytes = Encoding.UTF8.GetBytes("my_secret_key");//authOptions

                var key = new SymmetricSecurityKey(secretBytes);
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidIssuer = Configuration.GetSection("Authorization").Key,
                    ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = key
                };
            });
            services.AddCors();
            services.AddAuthorization();
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    a => a.MigrationsAssembly("WebChat.DAL.Migrations"));
            });
            services.AddAutoMapper(typeof(UserProfile), typeof(ChatProfile));

            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptions.Authorization).Bind);
            services.AddTransient<IMessageRepository, PostgresMessageRepository>();
            services.AddTransient<IChatRepository, PostgresChatRepository>();
            services.AddTransient<IUserRepository, PostgresUserRepository>();
            services.AddTransient<IChatActionsRepository, PostgresChatActionsRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
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
