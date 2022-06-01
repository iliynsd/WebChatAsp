using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebChat.Domain.Models;


namespace WebChat.Controllers
{

    public class AccountController: Controller
    {
        public IActionResult LogIn([FromBody] LoginModel model)
        {
            
            //find user

            
            return Ok("ed");
        }

        public IActionResult Register()
        {
            return Ok("req");
        }

        [Authorize]
        public IActionResult LogOut()
        {
            return Ok();
        }
    }
}
