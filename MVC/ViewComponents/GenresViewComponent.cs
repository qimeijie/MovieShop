using ApplicationCore.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreRepositoryAsync genreRepository;

        public GenresViewComponent(IGenreRepositoryAsync genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await genreRepository.GetAllAsync();
            return View(genres);
        }
    }
}
