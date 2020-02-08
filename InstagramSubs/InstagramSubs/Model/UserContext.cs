namespace InstagramSubs.Model
{
    public class UserContext
    {
        public User User { get; }

        public int FollowersNumber { get; set; }

        public UserContext()
        {
            User = new User();
        }
    }
}
