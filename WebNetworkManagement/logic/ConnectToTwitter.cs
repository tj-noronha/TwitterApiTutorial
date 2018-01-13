using System.Configuration;
using LinqToTwitter;

namespace WebNetworkManagement.logic
{
    public class ConnectToTwitter
    {
        private static readonly string CustomerKey;
        private static readonly string CustomerKeySecret;
        private static readonly string AccessToken;
        private static readonly string AccessTokenSecret;

        static ConnectToTwitter()
        {
            CustomerKey = ConfigurationManager.AppSettings["customerKey"];
            CustomerKeySecret = ConfigurationManager.AppSettings["customerKeySecret"];
            AccessToken = ConfigurationManager.AppSettings["accessToken"];
            AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"];
        }

        public SingleUserAuthorizer ConnectionToTwitter()
        {
            return new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = CustomerKey,
                    ConsumerSecret = CustomerKeySecret,
                    AccessToken = AccessToken,
                    AccessTokenSecret = AccessTokenSecret
                }
            };
        }
    }
}