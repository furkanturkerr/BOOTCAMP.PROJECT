using DataAccess.Abstracts;
using Entities;
using Repositories.Contexts;

namespace Repositories.EntityConfigurations;

public class EfRoleRepository : EfRepositoryBase<Role, BaseDbContext>, IRoleRepository
{
    public EfRoleRepository(BaseDbContext context) : base(context)
    {
    }
}
