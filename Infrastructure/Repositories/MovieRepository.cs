using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie? GetByIdWithCastTrailer(int id)
        {
            return _movieDbContext.Set<Movie>().Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast).Include(m => m.Trailers).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMovies(int page, int pageSize, int? genreId = null)
        {
            var query = _movieDbContext.Set<Movie>().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public int GetTotalMoviesCount(int? genreId = null)
        {
            var query = GetAll().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return query.Count();
        }
    }
}
