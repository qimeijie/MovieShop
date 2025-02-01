using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public GenreRepository(MovieDbContext movieDbContext) : base(movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Genre? GetByIdWithMovie(int id)
        {
            return _movieDbContext.Set<Genre>().Include(g=>g.MovieGenres).ThenInclude(mg=>mg.Movie).FirstOrDefault(g=>g.Id == id);
        }
    }
}
