using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;
using WebNetworkManagement.Models;

namespace WebNetworkManagement.logic
{
    public class GetUserTweets
    {
        public ListOfTweetDetails GetTweetsFromUser(TwitterContext context)
        {
            var tweetDetails = new ListOfTweetDetails
            {
                Details = new List<TweetDetails>()
            };
            // last tweet processed on previous query set
            ulong sinceID = 210024053698867204;

            ulong maxID;
            const int Count = 10;
            var statusList = new List<Status>();

            var userStatusResponse =
                (from tweet in context.Status
                    where tweet.Type == StatusType.User &&
                          tweet.ScreenName == "webTutorial17" &&
                         // tweet.SinceID == sinceID &&
                          tweet.Count == Count
                    select tweet)
                .ToList();

            statusList.AddRange(userStatusResponse);

            // first tweet processed on current query
            maxID = userStatusResponse.Min(
                        status => ulong.Parse(status.StatusID.ToString())) - 1;

            do
            {
                // now add sinceID and maxID
                userStatusResponse =
                    (from tweet in context.Status
                        where tweet.Type == StatusType.User &&
                              tweet.ScreenName == "webTutorial17" &&
                              tweet.Count == Count &&
                              //tweet.SinceID == sinceID &&
                              tweet.MaxID == maxID
                        select tweet)
                    .ToList();

                if (userStatusResponse.Count > 0)
                {
                    // first tweet processed on current query
                    maxID = userStatusResponse.Min(
                                status => ulong.Parse(status.StatusID.ToString())) - 1;

                    statusList.AddRange(userStatusResponse);
                }
            }
            while (userStatusResponse.Count != 0 && statusList.Count < 30);


            foreach (var tweetObject in statusList)
            {
                tweetDetails.Details.Add(new TweetDetails
                {
                    Name = tweetObject.ScreenName,
                    CreatedAt = tweetObject.CreatedAt,
                    FavouriteCount = tweetObject.FavoriteCount,
                    Language = tweetObject.Lang,
                    RetweetCount = tweetObject.RetweetCount,
                    TweetDesc = tweetObject.Text
                });
            }

            return tweetDetails;
        }
    }
}