﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Domain.ChatModels
{
    public class RemoveUserFromChatModel
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
    }
}
