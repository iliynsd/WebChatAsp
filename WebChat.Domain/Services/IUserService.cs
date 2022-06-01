using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Domain.Models;

namespace WebChat.Domain.Services
{
    public interface IUserService
    {
        public Task<AuthenticateResponse> Authenticate(LoginModel model);
        public Task<AuthenticateResponse> Register(LoginModel model);
    }
}
