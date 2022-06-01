using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.IdentityServer
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(User uer);
    }
}
