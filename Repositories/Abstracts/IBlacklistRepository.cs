namespace Repositories.Abstracts;

public interface IBlacklistRepository
{
    Task<bool> IsApplicantBlacklistedAsync(int applicantId);
}