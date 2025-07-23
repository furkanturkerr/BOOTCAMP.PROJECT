using Business.Abstaracts;
using Business.DTOs.Requests.Applicant;
using Core.Exceptions;
using Entities;
using AutoMapper;
using Repositories.Abstracts;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;
    private IApplicantService _applicantServiceImplementation;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
    }

    public async Task<List<GetApplicantResponse>> GetAllAsync()
    {
        var applicants = await _applicantRepository.GetAllAsync();
        return _mapper.Map<List<GetApplicantResponse>>(applicants);
    }

    public class GetApplicantResponse
    {
    }

    public async Task<GetApplicantResponse> GetByIdAsync(int id)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
            throw new NotFoundException("Başvuran bulunamadı");
        return _mapper.Map<GetApplicantResponse>(applicant);
    }

    public async Task AddAsync(CreateApplicantRequests request)
    {
        var applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
    }

    public async Task UpdateAsync(UpdateApplicantRequests request)
    {
        var applicant = await _applicantRepository.GetByIdAsync(request.UserId);
        if (applicant == null)
            throw new NotFoundException("Başvuran bulunamadı");

        _mapper.Map(request, applicant);
        await _applicantRepository.UpdateAsync(applicant);
    }

    public Task DeleteAsync(int request)
    {
        throw new NotImplementedException();
    }
}