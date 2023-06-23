using InstagramAnalyzer.API.Data;
using InstagramAnalyzer.API.Helpers;
using InstagramAnalyzer.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramAnalyzer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthController(IConfiguration config, AppDbContext dbContext)
        {
            _configuration = config;
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Token(LoginRequestModel model)
        {
            var user = _dbContext.Users.Any(x => x.Username == model.Username && x.Password == model.Password);
            if (user)
            {
                var token = new TokenHelper().GeneratorToken(model.Username);
                return Ok(new { token });
            }
            var message = "Kullanıcı adı veya şifre yanlış";
            return Unauthorized(new { message });
        }
    }
}
