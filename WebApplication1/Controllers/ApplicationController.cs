using Business.Abstaracts;
using Business.DTOs.Requests.Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var applications = await _applicationService.GetAllAsync();
        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);
        if (application == null)
            return NotFound();
        return Ok(application);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateApplicationRequest request)
    {
        await _applicationService.AddAsync(request);
        return StatusCode(201);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateApplicationRequest request)
    {
        await _applicationService.UpdateAsync(request);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteApplicationRequest request)
    {
        await _applicationService.DeleteAsync(request);
        return NoContent();
    }
}
