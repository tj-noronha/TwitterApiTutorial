using System.Net;
using System.Web.Mvc;
using LinqToTwitter;
using Newtonsoft.Json;
using WebNetworkManagement.logic;
using WebNetworkManagement.Models;

namespace WebNetworkManagement.Controllers
{
    public class TutorialController : Controller
    {
        private static readonly ConnectToTwitter Connection = new ConnectToTwitter();
        private static readonly GetUserDetails Details = new GetUserDetails();
        private static readonly GetUserTweets Tweets = new GetUserTweets();
        private static readonly TwitterContext Context = new TwitterContext(Connection.ConnectionToTwitter());
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

        public ActionResult EndResult()
        {
            return View("../Tutorial/EndResult");
        }

        public ActionResult GetUserDetails()
        {
            TempData["valid"] = "";
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
                //if (SendTweet.SendAtweetFromUi(tweet, Context))
                //{
                //    modelToPass.Message = "sent";
                //    return View("../Tutorial/SendTweet", modelToPass);
                //}

                //modelToPass.Message = "Error sending Tweet";
                //return View("../Tutorial/SendTweet", modelToPass);

                modelToPass.Message = "sent";
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

        [HttpPost]
        public ActionResult ValidateCaptcha(string viewName)
        {
            var response = Request["g-recaptcha-response"];//secret that was generated in key value pair
            const string secret = "6LdymEAUAAAAAPkg73bq3c4n6LipM3yTmOawqWVI";

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                        secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (!string.IsNullOrWhiteSpace(captchaResponse.Success))
            {
                if (captchaResponse.ErrorCodes?.Count <= 0)
                {
                    var error = captchaResponse.ErrorCodes[0].ToLower();
                    switch (error)
                    {
                        case ("missing-input-secret"):
                            ViewBag.Message = "The secret parameter is missing.";
                            break;
                        case ("invalid-input-secret"):
                            ViewBag.Message = "The secret parameter is invalid or malformed.";
                            break;

                        case ("missing-input-response"):
                            ViewBag.Message = "The response parameter is missing.";
                            break;
                        case ("invalid-input-response"):
                            ViewBag.Message = "The response parameter is invalid or malformed.";
                            break;

                        default:
                            ViewBag.Message = "Error occured. Please try again";
                            break;
                    }

                    ViewBag.Message = "InValid";
                    return View(viewName);
                }
                else if (captchaResponse.Success == "True")
                {
                    if (viewName == "UserResults")
                    {
                        var details = Details.UserDetails(Context);
                        return View("UserResults", details);
                    }
                    if (viewName == "GetTweets")
                    {
                        var allTweetDetails = Tweets.GetTweetsFromUser(Context);
                        return View("GetTweets", allTweetDetails);
                    }
                    return View(viewName);
                }
            }

            ViewBag.Message = "Invalid";
            return View(viewName);
        }
    }
}