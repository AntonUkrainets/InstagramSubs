using InstagramApiSharp.Classes.Models;

namespace InstagramSubs.Model
{
    public class UserContext
    {
        public User User { get; }

        public InstaUserShortList Followers { get; set; }
        public InstaUserShortList UserFollowing { get; set; }

        public int CountUsersIDontFollowBack { get; set; }
        public int CountUsersDontFollowMe { get; set; }

        public UserContext()
        {
            User = new User();
        }
    }
}