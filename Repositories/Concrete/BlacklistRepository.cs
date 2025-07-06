using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Contexts;

namespace Repositories.Concrete;

public class BlacklistRepository : GenericRepository<Blacklist>, IBlacklistRepository
{
    public BlacklistRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<bool> IsApplicantBlacklistedAsync(int applicantId)
    {
        return await _context.Blacklists
            .AnyAsync(b => b.ApplicantId == applicantId && b.IsActive);
    }
}

