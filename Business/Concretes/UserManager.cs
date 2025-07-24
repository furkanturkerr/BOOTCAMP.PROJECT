using AutoMapper;
using Business.Abstaracts;
using Business.DTOs.Requests.User;
using Business.DTOs.Response.User;
using Core.Entities;
using Core.Security.Hashing;
using Repositories.Abstracts;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<GetUserResponse>>(users);
    }

    public async Task<GetUserResponse> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");
            
        return _mapper.Map<GetUserResponse>(user);
    }

    public async Task<GetUserResponse> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");
            
        return _mapper.Map<GetUserResponse>(user);
    }

    public async Task<GetUserResponse> AddAsync(CreateUserRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new Exception("Bu email adresi zaten kayıtlı");

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var user = _mapper.Map<User>(request);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<GetUserResponse>(createdUser);
    }

    public async Task<GetUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        if (!string.IsNullOrEmpty(request.Email) && request.Email != user.Email)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("Bu email adresi zaten kayıtlı");
        }

        _mapper.Map(request, user);
        var updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<GetUserResponse>(updatedUser);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");
            
        await _userRepository.DeleteAsync(user);
    }
}