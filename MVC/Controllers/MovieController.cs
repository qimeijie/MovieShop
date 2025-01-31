using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index(int currentPage = 1, int pageSize = 24)
        {
            var movieCount = _movieRepository.GetAll().Count();
            var movieCards = _movieRepository.GetAll()
                .Skip((currentPage - 1) * pageSize).Take(pageSize)
                .Select(movie => new MovieCardViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title ?? string.Empty,
                    Price = movie.Price ?? 0,
                    ImageUrl = movie.PosterUrl ?? string.Empty
                });
            var paginationViewModel = new PaginationViewModel()
            {
                CurrentPage = currentPage,
                TotalPages = (int)Math.Ceiling((double)movieCount / pageSize),
            };
            var movieList = new MovieListViewModel()
            {
                Pagination = paginationViewModel,
                MovieCards = movieCards,
            };
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
    }
}
