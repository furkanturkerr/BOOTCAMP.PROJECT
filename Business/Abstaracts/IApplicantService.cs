using Business.Concretes;
using Business.DTOs.Requests.Applicant;
using Business.DTOs.Requests.Application;
using Business.DTOs.Response.Application;

namespace Business.Abstaracts;

public interface IApplicantService
{
    Task AddAsync(CreateApplicantRequests request);
    Task<List<ApplicantManager.GetApplicantResponse>> GetAllAsync();
    Task<ApplicantManager.GetApplicantResponse> GetByIdAsync(int id);
    Task UpdateAsync(UpdateApplicantRequests request);
    Task DeleteAsync(int request);
}