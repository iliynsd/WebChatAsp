
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.IdentityServer.Options
{
    public class JwtOptionsConfig
    {
        private AuthOptions _authOptions;

        public JwtOptionsConfig(IOptions<AuthOptions> options)
        {
            _authOptions = options.Value;
        }

        public void ConfigJwt(JwtBearerOptions options)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(_authOptions.SecretKey);

            var key = new SymmetricSecurityKey(secretBytes);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = _authOptions.Issuer,
                ValidAudience = _authOptions.Audience,
                IssuerSigningKey = key
            };
        }
    }
}
