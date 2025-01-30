using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieDbContext movieDbContext) : base(movieDbContext)
        {
        }
    }
}
