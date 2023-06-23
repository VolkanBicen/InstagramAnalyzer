using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InstagramAnalyzer.API.Helpers
{
    public class TokenHelper
    {
        private static SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CommonHelperSettings.Instance.Key));
        public string GeneratorToken(string Username)
        {

            var claims = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           });

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1), // Geçerlilik süresi
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                Issuer = CommonHelperSettings.Instance.Issuer,
                Audience = CommonHelperSettings.Instance.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        //public bool ValidateToken(string Token)
        //{
        //    try
        //    {
        //        JwtSecurityTokenHandler handler = new();
        //        handler.ValidateToken(Token, new TokenValidationParameters()
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = securityKey,

        //            ValidateLifetime = true,
        //            ValidateAudience = true,
        //            ValidAudience = CommonHelperSettings.Instance.Audience,

        //            ValidateIssuer = true,
        //            ValidIssuer = CommonHelperSettings.Instance.Issuer,
                    
        //        }, out SecurityToken validatedToken);

        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //}
    }
}
