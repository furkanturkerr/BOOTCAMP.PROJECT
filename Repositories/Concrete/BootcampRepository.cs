using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class BootcampRepository : GenericRepository<Bootcamp>, IBootcampRepository
{
    public BootcampRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bootcamp>> GetBootcampsByInstructorAsync(int instructorId)
    {
        return await _context.Bootcamps
            .Where(b => b.InstructorId == instructorId)
            .Include(b => b.Applications)
            .ToListAsync();
    }

}