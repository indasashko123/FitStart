using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FitStart.WebApi.AuthOptions
{
    public class AuthConfig
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient"; 
        const string KEY = "mysupersecret_secretkey!123";   
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

        public static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthConfig.ISSUER,
                ValidateAudience = true,
                ValidAudience = AuthConfig.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = AuthConfig.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }
    }
}
