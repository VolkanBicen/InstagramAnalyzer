using InstagramAnalyzer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using InstagramAnalyzer.Web.Helpers;

namespace InstagramAnalyzer.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var cookies = new InstagramLoginHelper().GetCookies(model);
            if (cookies.IsLogin == false)
            {
                // giriş başarısız
                return View();
            }
            var allFollowers = new InstagramGetDataHelper().GetAllFollowers(cookies);
            UnfollowListModel unfollowList = new InstagramGetDataHelper().GetUnfollowList(allFollowers);
            return RedirectToAction("Unfollow", "List", unfollowList);
        }
      
    }
}