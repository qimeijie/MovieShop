using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieRepositoryAsync movieRepository;
        private readonly IPurchaseRepositoryAsync purchaseRepository;
        public AdminController(IMovieRepositoryAsync movieRepository, IPurchaseRepositoryAsync purchaseRepository) {
            this.movieRepository = movieRepository;
            this.purchaseRepository = purchaseRepository;
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
                movieRepository.InsertAsync(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        [HttpGet]
        public async Task<IActionResult> TopMovies(int currentPage = 1, int pageSize = 30, DateTime? startDate = null, DateTime? endDate = null)
        {
            var movies = await purchaseRepository.GetMoviesOrderedByPurchaseCountAsync(currentPage, pageSize, startDate, endDate);
            var totalCount = await purchaseRepository.GetTotalMoviesCountAsync(startDate, endDate);
            var paginatedResultSet = new PaginatedResultSet<MoviePurchaseCountDto>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                Movies = movies,
            };
            var model = new TopMoviesViewModel()
            {
                PaginatedResultSet = paginatedResultSet,
                StartDate = startDate,
                EndDate = endDate,
                
            };
            return View(model);
        }
    }
}
