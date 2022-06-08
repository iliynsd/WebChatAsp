using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Domain.MessageModels
{
    public class MessageResponse
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public bool IsViewed { get; set; }
        public string Author { get; set; }
    }
}
