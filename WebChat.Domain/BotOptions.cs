using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Domain
{
    public class BotOptions
    {
        public const string Threads = "ThreadsForBotsAmount";
        public int BotThreads { get; set; }
    }
}
