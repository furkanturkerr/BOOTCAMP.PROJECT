using AutoMapper;
using Business.DTOs.Requests.User;
using Core.Entities;

namespace Business.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserResponse>();
        CreateMap<UpdateUserRequest, User>();
    }
}