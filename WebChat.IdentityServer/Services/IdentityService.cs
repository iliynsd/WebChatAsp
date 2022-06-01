using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.IdentityServer.Options;

namespace WebChat.IdentityServer
{
    public class IdentityService : IIdentityService
    {
        private AuthOptions _authOptions;
        public IdentityService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            byte[] secretBytes = Encoding.UTF8.GetBytes(_authOptions.SecretKey);

            var key = new SymmetricSecurityKey(secretBytes);

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _authOptions.Issuer,
                _authOptions.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_authOptions.MinuteExpires),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
