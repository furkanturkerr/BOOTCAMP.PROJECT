using AutoMapper;
using Business.Abstaracts;
using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Response.Bootcamp;
using Core.Exceptions;
using Entities;
using Repositories.Abstracts;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;
    private IBootcampService _bootcampServiceImplementation;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public async Task<List<GetBootcampResponse>> GetAllAsync()
    {
        var bootcamps = await _bootcampRepository.GetAllAsync();
        return _mapper.Map<List<GetBootcampResponse>>(bootcamps);
    }

    public async Task<GetBootcampResponse> GetByIdAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(id);
        if (bootcamp == null)
            throw new NotFoundException("Bootcamp bulunamadı");
        return _mapper.Map<GetBootcampResponse>(bootcamp);
    }

    public async Task AddAsync(CreateBootcampRequest request)
    {
        var bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);
    }

    public Task Update(CreateBootcampRequest request)
    {
        return _bootcampServiceImplementation.Update(request);
    }

    public async Task UpdateAsync(UpdateBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(request.Id);
        if (bootcamp == null)
            throw new NotFoundException("Bootcamp bulunamadı");

        _mapper.Map(request, bootcamp);
        await _bootcampRepository.UpdateAsync(bootcamp);
    }

    public async Task DeleteAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(id);
        if (bootcamp == null)
            throw new NotFoundException("Bootcamp bulunamadı");

        await _bootcampRepository.DeleteAsync(bootcamp);
    }
}
