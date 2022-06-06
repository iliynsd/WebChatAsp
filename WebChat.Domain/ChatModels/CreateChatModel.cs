using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.Domain.ChatModels
{
    public class CreateChatModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
