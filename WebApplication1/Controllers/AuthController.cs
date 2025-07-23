using Core.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Business.Abstaracts;
using Microsoft.AspNetCore.Identity.Data;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController<IAuthService> : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenHelper _tokenHelper;

    public AuthController(IAuthService authService, ITokenHelper tokenHelper)
    {
        _authService = authService;
        _tokenHelper = tokenHelper;
    }
}