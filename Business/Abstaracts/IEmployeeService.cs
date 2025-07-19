using Business.DTOs.Requests.Employee;
using Business.DTOs.Response.Employee;

namespace Business.Abstaracts;

public interface IEmployeeService
{
    Task<List<GetEmployeeResponse>> GetAllAsync();
    Task<GetEmployeeResponse> GetByIdAsync(int id);
    Task AddAsync(CreateEmployeeRequest request);
    Task Update(CreateEmployeeRequest request);
}