using Business.DTOs.Requests.Instructor;
using Business.DTOs.Response.Instructor;

namespace Business.Abstaracts;

public interface IInstructorService
{
    Task<List<GetInstructorResponse>> GetAllAsync();
    Task<GetInstructorResponse> GetByIdAsync(int id);
    Task AddAsync(CreateInstructorRequest request);
    Task Update(CreateInstructorRequest request);
}