using System.Web.Mvc;

namespace WebNetworkManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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