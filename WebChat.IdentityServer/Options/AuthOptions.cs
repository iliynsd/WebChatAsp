using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.IdentityServer.Options
{
    public class AuthOptions
    {
        public const string Authorization = "Authorization";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int MinuteExpires { get; set; }
    }
}