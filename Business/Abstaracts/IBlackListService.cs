using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Response.Blacklist;

namespace Business.Abstaracts;

public interface IBlackListService
{
    Task<List<GetBlacklistResponse>> GetAllAsync();
    Task<GetBlacklistResponse> GetByIdAsync(int id);
    Task AddAsync(CreateBlacklistRequest request);
    Task UpdateAsync(UpdateBlacklistRequest request);
    Task DeleteAsync(int id);
    Task<bool> IsApplicantBlacklistedAsync(int applicantId);
}