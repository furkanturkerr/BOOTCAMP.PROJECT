using Business.Abstaracts;
using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Response.Blacklist;
using Core.Exceptions;
using Entities;
using AutoMapper;
using Repositories.Abstracts;

namespace Business.Concretes;

public class BlacklistManager : IBlackListService
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IMapper _mapper;

    public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
    {
        _blacklistRepository = blacklistRepository;
        _mapper = mapper;
    }

    public async Task<List<GetBlacklistResponse>> GetAllAsync()
    {
        var blacklists = await _blacklistRepository.GetAllAsync();
        if (blacklists == null)
            throw new NotFoundException("Kara liste bulunamadı");
        return _mapper.Map<List<GetBlacklistResponse>>(blacklists);
    }

    public async Task<GetBlacklistResponse> GetByIdAsync(int id)
    {
        var blacklist = await _blacklistRepository.GetByIdAsync(id);
        if (blacklist == null)
            throw new NotFoundException("Kara liste kaydı bulunamadı");
        return _mapper.Map<GetBlacklistResponse>(blacklist);
    }

    public async Task AddAsync(CreateBlacklistRequest request)
    {
        var blacklist = _mapper.Map<Blacklist>(request);
        await _blacklistRepository.AddAsync(blacklist);
    }

    public async Task UpdateAsync(UpdateBlacklistRequest request)
    {
        var blacklist = await _blacklistRepository.GetByIdAsync(request.Id);
        if (blacklist == null)
            throw new NotFoundException("Kara liste kaydı bulunamadı");

        _mapper.Map(request, blacklist);
        await _blacklistRepository.UpdateAsync(blacklist);
    }

    public async Task DeleteAsync(int id)
    {
        var blacklist = await _blacklistRepository.GetByIdAsync(id);
        if (blacklist == null)
            throw new NotFoundException("Kara liste kaydı bulunamadı");

        await _blacklistRepository.DeleteAsync(blacklist);
    }

    public async Task<bool> IsApplicantBlacklistedAsync(int applicantId)
    {
        return await _blacklistRepository.IsApplicantBlacklistedAsync(applicantId);
    }

}