using Entities;

namespace Repositories.Abstracts;

public interface IApplicationRepository : IGenericRepository<Application>
{
    Task<IEnumerable<Application>> GetApplicationsByBootcampAsync(int bootcampId);
    Task<IEnumerable<Application>> GetApplicationsByApplicantAsync(int applicantId);

}