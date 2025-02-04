using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public AdminController(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository) {
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Insert(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        [HttpGet]
        public IActionResult TopMovies(int currentPage = 1, int pageSize = 30, DateTime? startDate = null, DateTime? endDate = null)
        {
            var movies = _purchaseRepository.GetMoviesOrderedByPurchaseCount(currentPage, pageSize, startDate, endDate);
            var totalCount = _purchaseRepository.GetTotalMoviesCount(startDate, endDate);
            var model = new TopMoviesViewModel()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                StartDate = startDate,
                EndDate = endDate,
                Movies = movies,
            };
            return View(model);
        }
    }
}
