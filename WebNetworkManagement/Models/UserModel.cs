using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNetworkManagement.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public DateTime DateJoined { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int FollowerCount { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Tweet { get; set; }
    }
}