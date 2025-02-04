using ApplicationCore.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public UserController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        private int testUserId = 48994; // 29 purhcases
        [HttpGet]
        public IActionResult Movies(int currentPage = 1, int pageSize = 24)
        {
            var totalMovies = _purchaseRepository.GetTotalMoviesCount(null, null, testUserId);
            var movies = _purchaseRepository.GetMoviesPurchasedByUser(testUserId, currentPage, pageSize);
            var model = new PurchasedMovieListViewModel()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
                MovieCards = movies,
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
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Movie");
        }
    }
}
