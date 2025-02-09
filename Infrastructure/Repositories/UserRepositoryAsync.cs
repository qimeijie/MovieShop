using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(MovieDbContext movieDbContext) : base(movieDbContext)
        {
        }
    }
}
