using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Application>> GetApplicationsByBootcampAsync(int bootcampId)
    {
        return await _context.Applications
            .Where(a => a.BootcampId == bootcampId)
            .Include(a => a.Applicant)
            .ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetApplicationsByApplicantAsync(int applicantId)
    {
        return await _context.Applications
            .Where(a => a.ApplicantId == applicantId)
            .Include(a => a.Bootcamp)
            .ToListAsync();
    }
}
