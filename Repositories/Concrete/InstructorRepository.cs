using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
{
    public InstructorRepository(BaseDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Bootcamp>> GetBootcampsAsync(int instructorId)
    {
        return await _context.Bootcamps
            .Where(b => b.InstructorId == instructorId)
            .ToListAsync();
    }

}