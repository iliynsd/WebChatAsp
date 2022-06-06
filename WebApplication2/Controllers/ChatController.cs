using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Domain.ChatModels;
using WebChat.Domain.ChatService;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        private IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChatModel model)
        {

            var createChatResponse = await _chatService.Create(model);
            return Ok();
        }
    }
}
