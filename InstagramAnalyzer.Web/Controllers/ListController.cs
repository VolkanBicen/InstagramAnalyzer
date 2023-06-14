using InstagramAnalyzer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Resources;

namespace InstagramAnalyzer.Web.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Unfollow(UnfollowListModel unfollowList)
        {
           
            return View(unfollowList);
        }
    }
}
