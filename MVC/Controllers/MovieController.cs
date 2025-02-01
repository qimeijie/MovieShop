using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
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
            var movieCount = 0;
            var movieCards = Enumerable.Empty<MovieCardViewModel>();
            var genres = _genreRepository.GetAll();
            if (genreId != null)
            {
                var genre = _genreRepository.GetByIdWithMovie(genreId ?? 0);
                var movies = genre?.MovieGenres.Select(mv => mv.Movie);
                movieCount = movies?.Count() ?? 0;
                movieCards = movies?
                    .Skip((currentPage - 1) * pageSize).Take(pageSize)
                    .Select(movie => new MovieCardViewModel()
                    {
                        Id = movie.Id,
                        Title = movie.Title ?? string.Empty,
                        Price = movie.Price ?? 0,
                        ImageUrl = movie.PosterUrl ?? string.Empty
                    }) ?? Enumerable.Empty<MovieCardViewModel>();
            }
            else
            {
                movieCount = _movieRepository.GetAll().Count();
                movieCards = _movieRepository.GetAll()
                    .Skip((currentPage - 1) * pageSize).Take(pageSize)
                    .Select(movie => new MovieCardViewModel()
                    {
                        Id = movie.Id,
                        Title = movie.Title ?? string.Empty,
                        Price = movie.Price ?? 0,
                        ImageUrl = movie.PosterUrl ?? string.Empty
                    });
            }
            
            var paginationViewModel = new PaginationViewModel()
            {
                GenreId = genreId,
                CurrentPage = currentPage,
                TotalPages = (int)Math.Ceiling((double)movieCount / pageSize),
            };
            var movieList = new MovieListViewModel()
            {
                Pagination = paginationViewModel,
                MovieCards = movieCards,
            };
            ViewData["Genres"] = genres;
            return View(movieList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Insert(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        [HttpGet]
        public IActionResult Detail(int movieId) { 
            var movie = _movieRepository.GetByIdWithCastTrailer(movieId)??new Movie();
            var castInfos = movie.MovieCasts.Select(
                mc => new CastInfo() 
                {
                    Character = mc.Character,
                    ProfileUrl = mc.Cast.ProfilePath,
                    Actor = mc.Cast.Name
                });
            var model = new MovieDetailViewModel()
            {
                IsPurchased = false,
                Movie = movie??new Movie(),
                Casts = castInfos,
            };
            return View(model);
        }
    }
}
