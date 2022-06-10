using System.Threading.Tasks;
using WebChat.Domain.AuthenticationModels;

namespace WebChat.Domain.UserServices
{
    public interface IUserService
    {
        public Task<AuthenticateResponse> Authenticate(LoginModel model);
        public Task<AuthenticateResponse> Register(LoginModel model);
    }
}
