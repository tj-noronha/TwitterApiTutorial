using System;
using System.Web.Mvc;
using WebNetworkManagement.Models;

namespace WebNetworkManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetTweets()
        {
            return View("../Tutorial/GetTweets");
        }

        public ActionResult SendTweet()
        {
            return View("../Tutorial/SendTweet");
        }

        public ActionResult UserDetails()
        {
            return View("../Tutorial/UserResults");
        }
    }
}