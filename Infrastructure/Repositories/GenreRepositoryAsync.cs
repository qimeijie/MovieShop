using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenreRepositoryAsync : BaseRepositoryAsync<Genre>, IGenreRepositoryAsync
    {
        public GenreRepositoryAsync(MovieDbContext movieDbContext) : base(movieDbContext)
        {
        }
    }
}
