using System.Collections.Generic;
using System.Threading.Tasks;
using WebChat.Domain.MessageModels;

namespace WebChat.Domain.MessageServices
{
    public interface IMessageService
    {
        public Task Add(AddMessageModel model);
        public Task Delete(int messageId);
        public Task Edit(EditMessageModel model);
        public Task<IEnumerable<MessageResponse>> Get(int chatId);
    }
}
