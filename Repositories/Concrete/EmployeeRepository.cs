using Entities;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(BaseDbContext context) : base(context)
    {
    }
}