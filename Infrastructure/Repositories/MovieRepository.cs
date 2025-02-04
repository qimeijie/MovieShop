using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
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

        public IEnumerable<Movie> GetMovies(int page, int pageSize, int? genreId = null)
        {
            var query = _movieDbContext.Movies.AsNoTracking().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetTotalMoviesCount(int? genreId = null, DateTime ? purchaseStart = null, DateTime? purchaseEnd = null)
        {
            var query = _movieDbContext.Movies.AsNoTracking().AsQueryable();

            if (genreId != null)
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
            }
            if(purchaseStart != null)
            {
                query = query.Where(m => m.Purchases.Any(p => purchaseStart == null || purchaseStart < p.PurchaseDateTime));
            }
            if(purchaseEnd != null)
            {
                query = query.Where(m => m.Purchases.Any(p => purchaseEnd == null || purchaseEnd > p.PurchaseDateTime));
            }
            return query.ToList().Count;
        }

        public MovieDetailModel? GetMovieDetails(int movieId)
        {
            return _movieDbContext.Movies.AsNoTracking()
                .Where(m => m.Id == movieId)
                .Select(m => new MovieDetailModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    TagLine = m.Tagline,
                    ReleaseDate = m.ReleaseDate,
                    Overview = m.Overview,
                    Price = m.Price,
                    PosterUrl = m.PosterUrl,
                    BackdropUrl = m.BackdropUrl,
                    Runtime = m.RunTime,
                    BoxOffice = m.Revenue,
                    Budget = m.Budget,
                })
                .FirstOrDefault();
        }

        public IEnumerable<MovieTrailerModel> GetMovieTrailers(int movieId)
        {
            return _movieDbContext.Trailers.AsNoTracking()
                .Where(t => t.MovieId == movieId)
                .Select(t => new MovieTrailerModel
                {
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                })
                .ToList();
        }

        public IEnumerable<MovieCastModel> GetMoviesCast(int movieId)
        {
            return _movieDbContext.MovieCasts.AsNoTracking()
                .Where(mc => mc.MovieId == movieId)
                .Select(mc => new MovieCastModel
                {
                    ActorName = mc.Cast.Name,
                    CharacterName = mc.Character,
                    ProfilePath = mc.Cast.ProfilePath,
                    TmdbUrl = mc.Cast.TmdbUrl
                })
                .ToList();
        }
    }
}
