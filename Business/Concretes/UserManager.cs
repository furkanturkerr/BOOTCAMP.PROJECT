using AutoMapper;
using Business.Abstaracts;
using Business.DTOs.Requests.User;
using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private IUserService _userServiceImplementation;
    public Task GetAllAsync()
    {
        return _userServiceImplementation.GetAllAsync();
    }

    public Task GetByIdAsync(int id)
    {
        return _userServiceImplementation.GetByIdAsync(id);
    }

    public Task DeleteAsync(int id)
    {
        return _userServiceImplementation.DeleteAsync(id);
    }

    public Task<GetUserResponse> GetByEmailAsync(string email)
    {
        return _userServiceImplementation.GetByEmailAsync(email);
    }

    public Task UpdateAsync(UpdateUserRequest request)
    {
        return _userServiceImplementation.UpdateAsync(request);
    }
}

