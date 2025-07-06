using Entities;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}