using AutoMapper;
using Business.DTOs.Requests.Application;
using Business.DTOs.Response.Application;
using Entities;

namespace Business.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Application, GetApplicationResponse>();
        CreateMap<CreateApplicationRequest, Application>();
        CreateMap<UpdateApplicationRequest, Application>();
    }

}