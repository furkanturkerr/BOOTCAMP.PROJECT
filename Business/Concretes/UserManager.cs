using Business.Abstracts;
using Business.DTOs.Requests.User;
using Business.DTOs.Response.User;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Core.Entities;
using Repositories.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<GetUserListResponse> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        var response = new GetUserListResponse
        {
            Items = users.Select(u => new GetUserResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                DateOfBirth = u.DateOfBirth,
                NationalityIdentity = u.NationalityIdentity,
                Roles = new List<string>()
            }).ToList(),
            Count = users.Count()
        };

        return response;
    }

    public async Task<GetUserResponse> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetAsync(u => u.Id == id, null);

        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        return new GetUserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            NationalityIdentity = user.NationalityIdentity,
            Roles = new List<string>()
        };
    }

    public async Task AddAsync(CreateUserRequest request)
    {
        var isEmailExists = await _userRepository.GetAsync(u => u.Email == request.Email, null);
        if (isEmailExists != null)
            throw new Exception("Bu email adresi zaten kullanılıyor");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            NationalityIdentity = request.NationalityIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(user);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetAsync(u => u.Id == id, null);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        await _userRepository.DeleteAsync(user);
    }
}