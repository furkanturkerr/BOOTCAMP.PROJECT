using Business.Abstaracts;
using Business.DTOs.Requests.Applicant;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantService _applicantService;

    public ApplicantController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var applicants = await _applicantService.GetAllAsync();
        return Ok(applicants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var applicant = await _applicantService.GetByIdAsync(id);
        if (applicant == null)
            return NotFound();
        return Ok(applicant);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _applicantService.DeleteAsync(id);
        return NoContent();
    }
}