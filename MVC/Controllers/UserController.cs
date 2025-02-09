using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Dtos;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IPurchaseRepositoryAsync purchaseRepository;

        public UserController(IPurchaseRepositoryAsync purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }
        private int testUserId = 48994; // 29 purhcases
        [HttpGet]
        public async Task<IActionResult> Movies(int currentPage = 1, int pageSize = 24)
        {
            var totalMovies = await purchaseRepository.GetTotalMoviesCountAsync(null, null, testUserId);
            var movies = await purchaseRepository.GetMoviesPurchasedByUserAsync(testUserId, currentPage, pageSize);
            var paginatedResultSet = new PaginatedResultSet<PurchaseWithMovieInfoDto>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalMovies / pageSize),
                Movies = movies,
            };
            return View(paginatedResultSet);
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
