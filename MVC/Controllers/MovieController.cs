using ApplicationCore.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository _movieRepository;
        private IGenreRepository _genreRepository;
        public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }
        [HttpGet]
        public IActionResult Index(int currentPage = 1, int? genreId = null, int pageSize = 24)
        {
            var movies = _movieRepository.GetMovies(currentPage, pageSize, genreId);
            var totalMovies = _movieRepository.GetTotalMoviesCount(genreId);
            var genres = _genreRepository.GetAll().ToList();
            var movieCards = movies.Select(movie => new MovieCardViewModel()
            {
                Id = movie.Id,
                ImageUrl = movie.PosterUrl ?? string.Empty
             });
            var movieList = new MovieListViewModel()
            {
                GenreId = genreId,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
                MovieCards = movieCards,
            };
            ViewData["Genres"] = genres;
            return View(movieList);
        }
        [HttpGet]
        public IActionResult Detail(int movieId) { 
            var movie = _movieRepository.GetMovieDetails(movieId);
            var casts = _movieRepository.GetMoviesCast(movieId);
            var trailer = _movieRepository.GetMovieTrailers(movieId);
            var model = new MovieDetailViewModel()
            {
                IsPurchased = false,
                Movie = movie,
                Casts = casts,
                Trailers = trailer
            };
            return View(model);
        }
    }
}
