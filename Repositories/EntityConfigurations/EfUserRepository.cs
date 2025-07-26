using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concretes;

public class EfUserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public EfUserRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}