using InstagramAnalyzer.API.Data;
using InstagramAnalyzer.API.Models;

namespace InstagramAnalyzer.API.Helpers
{
    public class UserHelper
    {
        private AppDbContext _dbContext;
        public UserHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UserCheck(LoginRequestModel model)
        {
            var user = _dbContext.Users.Any(x => x.Username == model.Username && x.Password==model.Password);
            if (user)
            {
                 return true;
            }
           return false;
        }
    }
}
