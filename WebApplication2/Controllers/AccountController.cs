using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebChat.Domain.AuthenticationModels;
using WebChat.Domain.UserServices;

namespace WebChat.Controllers
{

    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginModel model)
        {
            var authenticateResponse = await _userService.Authenticate(model);

            if (authenticateResponse is null)
            {
                return BadRequest("Can't login");
            }

            return Ok(authenticateResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] LoginModel model)
        {
            var registrationResponse = await _userService.Register(model);
            if (registrationResponse is null)
            {
                return BadRequest("Can't register");
            }
            return Ok(registrationResponse);
        }
    }
}
