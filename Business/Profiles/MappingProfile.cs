using AutoMapper;
using Business.DTOs.Requests.User;
using Business.DTOs.Response.User;
using Core.Entities;

namespace Business.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, GetUserResponse>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<GetUserResponse, User>();
    }
}