using AutoMapper;
using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Response.Bootcamp;
using Entities;

namespace Business.Profiles;

public class BootcampProfile:Profile
{
    public BootcampProfile()
    {
        CreateMap<Bootcamp, GetBootcampResponse>();
        CreateMap<CreateBootcampRequest, Bootcamp>();
        CreateMap<UpdateBootcampRequest, Bootcamp>();
    }
}