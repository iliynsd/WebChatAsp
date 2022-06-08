using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebChat.Domain.MessageModels;
using WebChat.Domain.MessageServices;

namespace WebChat.Controllers
{
    public class MessageController: Controller
    {
        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMessageModel model)
        {
            await _messageService.Add(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int messageId)
        {
            await _messageService.Delete(messageId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditMessageModel model)
        {
            await _messageService.Edit(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int chatId)
        {
            var messages = await _messageService.Get(chatId);

            if(messages == null)
            {
                return Ok("Chat Empty");
            }

            return Ok(messages);
        }
    }
}