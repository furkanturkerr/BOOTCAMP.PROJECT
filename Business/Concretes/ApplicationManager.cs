using Business.Abstaracts;
using Business.DTOs.Requests.Application;
using Business.DTOs.Response.Application;
using Core.Exceptions;
using Entities;
using AutoMapper;
using Repositories.Abstracts;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<List<GetApplicationResponse>> GetAllAsync()
    {
        var applications = await _applicationRepository.GetAllAsync();
        return _mapper.Map<List<GetApplicationResponse>>(applications);
    }

    public async Task<GetApplicationResponse> GetByIdAsync(int id)
    {
        var application = await _applicationRepository.GetByIdAsync(id);
        if (application == null)
            throw new NotFoundException("Başvuru bulunamadı");
        return _mapper.Map<GetApplicationResponse>(application);
    }

    public async Task AddAsync(CreateApplicationRequest request)
    {
        var application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);
    }

    public async Task UpdateAsync(UpdateApplicationRequest request)
    {
        var application = await _applicationRepository.GetByIdAsync(request.Id);
        if (application == null)
            throw new NotFoundException("Başvuru bulunamadı");

        _mapper.Map(request, application);
        await _applicationRepository.UpdateAsync(application);
    }

    public async Task DeleteAsync(DeleteApplicationRequest request)
    {
        var application = await _applicationRepository.GetByIdAsync(request.Id);
        if (application == null)
            throw new NotFoundException("Başvuru bulunamadı");

        await _applicationRepository.DeleteAsync(application);
    }
}