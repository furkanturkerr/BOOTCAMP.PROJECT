using AutoMapper;
using Business.Concretes;
using Business.DTOs.Requests.Applicant;
using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Response.Blacklist;
using Entities;

namespace Business.Profiles;

public class BlacklistProfile:Profile
{
    public BlacklistProfile()
    {
        CreateMap<Blacklist, GetBlacklistResponse>();
        CreateMap<CreateBlacklistRequest, Blacklist>();
        CreateMap<UpdateBlacklistRequest, Blacklist>();
    }
}