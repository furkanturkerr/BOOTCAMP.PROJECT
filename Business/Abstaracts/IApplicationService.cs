using Business.DTOs.Requests.Application;
using Business.DTOs.Response.Application;

namespace Business.Abstaracts;

public interface IApplicationService
{
    Task<List<GetApplicationResponse >> GetAllAsync();
    Task<GetApplicationResponse> GetByIdAsync(int id);
    Task AddAsync(CreateApplicationRequest request);
    Task UpdateAsync(UpdateApplicationRequest request);
    Task DeleteAsync(DeleteApplicationRequest request);
}