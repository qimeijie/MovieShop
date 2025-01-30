namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public Movie Movie { get; set; } = new Movie();
        public Genre Genre { get; set; } = new Genre();
    }
}
