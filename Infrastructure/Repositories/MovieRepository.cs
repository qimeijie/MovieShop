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

        public IEnumerable<Movie> GetAllWithCastTrailer()
        {
            return _movieDbContext.Set<Movie>().Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast).Include(m => m.Trailers);
        }

        public Movie? GetByIdWithCastTrailer(int id)
        {
            return _movieDbContext.Set<Movie>().Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast).Include(m=>m.Trailers).FirstOrDefault(m => m.Id == id);
        }
    }
}
