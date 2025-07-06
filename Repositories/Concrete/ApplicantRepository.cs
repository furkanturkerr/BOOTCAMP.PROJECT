using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
{
    public ApplicantRepository(BaseDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Application>> GetApplicationsAsync(int applicantId)
    {
        return await _context.Applications
            .Where(a => a.ApplicantId == applicantId)
            .Include(a => a.Bootcamp)
            .ToListAsync();
    }

}