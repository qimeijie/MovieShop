using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 24)
        {
            var count = _movieRepository.GetAll().Count();
            int pageCount = (int)Math.Ceiling(count * 1.0 / pageSize);
            IEnumerable<Movie> movies = _movieRepository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            ViewData["PageCount"] = pageCount;
            return View(movies);
        }
    }
}
