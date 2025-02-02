using ApplicationCore.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private IMovieRepository _movieRepository;
        public UserController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        private int testUserId = 48994; // 29 purhcases
        [HttpGet]
        public IActionResult Movies(int currentPage = 1, int pageSize = 24)
        {
            var totalMovies = _movieRepository.GetMoviesCountPurchasedByUser(testUserId);
            var movies = _movieRepository.GetMoviesPurchasedByUser(testUserId, currentPage, pageSize);
            var movieCards = movies.Select(m =>
            {
                var purchase = m.Purchases.FirstOrDefault(p => p.UserId == testUserId);
                return new MovieCardViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.PosterUrl,
                    PurchaseId = purchase?.PurchaseNumber,
                    PurchasedDate = purchase?.PurchaseDateTime,
                    PurchasedPrice = purchase?.TotalPrice
                };
            });
            var model = new MovieListViewModel()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
                MovieCards = movieCards,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Favorites()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Movie");
        }
    }
}
