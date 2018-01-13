using System.Linq;
using LinqToTwitter;
using WebNetworkManagement.Models;

namespace WebNetworkManagement.logic
{
    public class GetUserDetails
    {
        public UserModel UserDetails(TwitterContext context)
        {
            var userResponse =
            (from tweet in context.User
                where tweet.Type == UserType.Show &&
                      tweet.ScreenName == "webTutorial17"
                select tweet).ToList();

            var user = userResponse[0];

            return new UserModel
            {
                Username = user.Name,
                Description = user.Description,
                DateJoined = user.CreatedAt,
                Email = user.Email,
                FollowerCount = user.FollowersCount,
                ProfileImageUrl = user.ProfileImageUrl,
                Tweet = user.Status.Text
            };
        }
    }
}