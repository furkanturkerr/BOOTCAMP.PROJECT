using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Response.Bootcamp;

namespace Business.Abstaracts;

public interface IBootcampService
{
    Task<List<GetBootcampResponse>> GetAllAsync();
    Task<GetBootcampResponse> GetByIdAsync(int id);
    Task AddAsync(CreateBootcampRequest request);
    Task Update(CreateBootcampRequest request);
}