using System;
using System.Web.Mvc;
using LinqToTwitter;
using WebNetworkManagement.logic;
using WebNetworkManagement.Models;

namespace WebNetworkManagement.Controllers
{
    public class TutorialController : Controller
    {
        private static readonly ConnectToTwitter Connection = new ConnectToTwitter();
        private static readonly GetUserDetails Details = new GetUserDetails();
        private static readonly GetUserTweets Tweets = new GetUserTweets();
        private static readonly TwitterContext Context =  new TwitterContext(Connection.ConnectionToTwitter());
        private static readonly SendTweet SendTweet = new SendTweet();

        // GET: Tutorial
        public ActionResult Index()
        {
            return View("../Tutorial/Prerequisites");
        }

        public ActionResult Prerequisties()
        {
            ViewBag.Message = "Prequisites page";
            return View("../Tutorial/Prerequisites");
        }

        
        public ActionResult GetUserDetails()
        {
            //var auth = _connection.ConnectionToTwitter();
            //var context = new TwitterContext(auth);

            var details = Details.UserDetails(Context);

            return View("UserResults", details);
        }

        public ActionResult HowToGetUserDetails()
        {
            return View("HowToGetUserDetails");
        }

        public ActionResult LoadDetailPage()
        {
            return View("UserResults");
        }

        public ActionResult HowTweets()
        {
            return View("HowToGetTweets");
        }

        public ActionResult GetTweets()
        {
            //var auth = _connection.ConnectionToTwitter();
            //var context = new TwitterContext(auth);

            var allTweetDetails = Tweets.GetTweetsFromUser(Context);
            return View("GetTweets", allTweetDetails);
        }

        public ActionResult TwitterApp()
        {
            return View("TwitterApp");
        }

        public ActionResult HowToSendTweets()
        {
            return View("../Tutorial/HowToSendTweets");
        }

        public ActionResult AttemptToSendTweet(string tweet)
        {
            var modelToPass = new TweetSentModel();
            if (tweet.Length < 260)
            {
                if (SendTweet.SendAtweetFromUi(tweet, Context))
                {
                    modelToPass.Message = "sent";
                    return View("../Tutorial/SendTweet", modelToPass);
                }

                modelToPass.Message = "Error sending Tweet";
                return View("../Tutorial/SendTweet", modelToPass);
            }

            modelToPass.Message = "Too many characters";
            return View("SendTweet", modelToPass);
        }

        public ActionResult Reflection()
        {
            return View("../Tutorial/Reflection");
        }

        public ActionResult Connect()
        {
            return View("ConnectToTwitter");
        }
    }
}