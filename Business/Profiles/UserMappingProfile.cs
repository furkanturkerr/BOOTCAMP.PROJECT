using AutoMapper;
using Business.DTOs.Requests.User;
using Core.Entities;

namespace Business.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, GetUserResponse>();
        CreateMap<GetUserResponse, User>(); 
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

    }
}