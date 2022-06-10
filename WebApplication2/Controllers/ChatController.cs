using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebChat.Domain.ChatModels;
using WebChat.Domain.ChatService;

namespace WebChat.Controllers
{
    [Authorize]
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
            await _chatService.Create(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser([FromBody] RemoveUserFromChatModel model)
        {
            await _chatService.RemoveUserFromChat(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int chatId)
        {
            await _chatService.Delete(chatId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserToChatModel model)
        {
            await _chatService.AddUser(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            var chats = await _chatService.GetUserChats(userId);
            return Ok(chats);
        }
    }
}
