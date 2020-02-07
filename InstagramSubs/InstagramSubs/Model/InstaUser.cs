using SQLite;

namespace InstagramSubs.Model
{
    public class InstaUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public int CurrentFollowers { get; set; }
        public int NewFollowers { get; set; }
        public int LostFollowers { get; set; }
    }
}