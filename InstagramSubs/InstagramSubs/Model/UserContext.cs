using InstagramApiSharp.Classes.Models;
using System.Collections.Generic;

namespace InstagramSubs.Model
{
    public class UserContext
    {
        public User User { get; }

        public IEnumerable<InstaUserShort> Followers { get; set; }
        public InstaUserShortList UserFollowing { get; set; }

        public int CountUsersIDontFollowBack { get; set; }
        public int CountUsersDontFollowMe { get; set; }

        public UserContext()
        {
            User = new User();
        }
    }
}