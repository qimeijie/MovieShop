namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }

        //navigation prop
        public Movie Movie { get; set; } = new Movie();
        public User User { get; set; } = new User();
    }
}
