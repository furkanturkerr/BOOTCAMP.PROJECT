using Entities;

namespace Repositories.Abstracts;

public interface IBlacklistRepository : IGenericRepository<Blacklist>
{
    Task<bool> IsApplicantBlacklistedAsync(int applicantId);
}