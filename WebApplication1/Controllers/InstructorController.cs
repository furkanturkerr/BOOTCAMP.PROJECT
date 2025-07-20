using Business.Abstaracts;
using Business.DTOs.Requests.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var instructors = await _instructorService.GetAllAsync();
        return Ok(instructors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var instructor = await _instructorService.GetByIdAsync(id);
        if (instructor == null)
            return NotFound();
        return Ok(instructor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInstructorRequest request)
    {
        await _instructorService.AddAsync(request);
        return StatusCode(201);
    }
}
