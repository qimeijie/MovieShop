using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IGenreRepositoryAsync genreRepositoryAsync;
        private readonly IMovieRepositoryAsync movieRepository;
        private readonly ITrailerRepositoryAsync trailerRepositoryAsync;
        private readonly ICastRepositoryAsync castRepositoryAsync;

        public MovieController(IGenreRepositoryAsync genreRepositoryAsync, IMovieRepositoryAsync movieRepository, ITrailerRepositoryAsync trailerRepositoryAsync, ICastRepositoryAsync castRepositoryAsync)
        {
            this.genreRepositoryAsync = genreRepositoryAsync;
            this.movieRepository = movieRepository;
            this.trailerRepositoryAsync = trailerRepositoryAsync;
            this.castRepositoryAsync = castRepositoryAsync;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int currentPage = 1, int? genreId = null, int pageSize = 24)
        {
            var movies = await movieRepository.GetMoviesByGenreAsync(currentPage, pageSize, genreId);
            var totalMovies = await movieRepository.GetTotalMoviesCountAsync(genreId);
            var paginatedPageSet = new PaginatedResultSet<Movie>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
                Movies = movies,
            };
            var movieList = new MovieListViewModel()
            {
                GenreId = genreId,
                PaginatedResultSet = paginatedPageSet,
            };
            return View(movieList);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int movieId) { 
            var movie = await movieRepository.GetMovieDetailsAsync(movieId);
            var casts = await castRepositoryAsync.GetCastByMovieIdAsync(movieId);
            var trailer = await trailerRepositoryAsync.GetTrailersByMovieIdAsync(movieId);
            var genres = await genreRepositoryAsync.GetGenresAsync(movieId);
            var model = new MovieDetailViewModel()
            {
                IsPurchased = false,
                Rating = movie?.Reviews.Average(r => r.Rating).ToString("F2"),
                ReleaseYear = movie?.ReleaseDate?.Year,
                Movie = movie??new Movie(),
                Genres = genres,
                Casts = casts,
                Trailers = trailer
            };
            return View(model);
        }
    }
}
