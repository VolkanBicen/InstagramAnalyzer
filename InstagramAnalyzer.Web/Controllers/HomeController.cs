using InstagramAnalyzer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View();
        }
      
    }
}