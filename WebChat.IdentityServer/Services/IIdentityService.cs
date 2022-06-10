using WebChat.DAL.Entities;

namespace WebChat.IdentityServer
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(User user);
    }
}
