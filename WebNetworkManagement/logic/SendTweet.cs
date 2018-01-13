using System;
using System.Threading.Tasks;
using LinqToTwitter;

namespace WebNetworkManagement.logic
{
    public class SendTweet
    {
        // private static readonly ConnectToTwitter _connectToTwitter = new ConnectToTwitter();

        public bool SendAtweetFromUi(string message, TwitterContext context1)
        {
            try
            {
                Task.Run(() => SendTheTweet(message, context1));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                throw;
            }
        }

        public async void SendTheTweet(string message, TwitterContext context1)
        {
            //var auth = _connectToTwitter.ConnectionToTwitter();
            //var context = new TwitterContext(auth);
            await context1.TweetAsync(message);
        }
    }
}