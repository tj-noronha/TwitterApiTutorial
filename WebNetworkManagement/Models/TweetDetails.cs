using System;
using System.Collections.Generic;

namespace WebNetworkManagement.Models
{
    public class TweetDetails
    {
        public string Name { get; set; }
        public string TweetDesc { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Language { get; set; }
        public int RetweetCount { get; set; }
        public int? FavouriteCount { get; set; }
    }

    public class ListOfTweetDetails
    {
        public List<TweetDetails> Details { get; set; }
    }
}