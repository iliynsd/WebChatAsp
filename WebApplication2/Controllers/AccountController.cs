﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebChat.Domain.Models;
using WebChat.Domain.Services;

namespace WebChat.Controllers
{

    public class AccountController: Controller
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

        public IActionResult Do()
        {
            
            return Ok("dce");
        }
    }
}
