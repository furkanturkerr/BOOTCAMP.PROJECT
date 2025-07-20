using Business.Abstaracts;
using Business.DTOs.Requests.Bootcamp;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bootcamps = await _bootcampService.GetAllAsync();
            return Ok(bootcamps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bootcamp = await _bootcampService.GetByIdAsync(id);
            if (bootcamp == null)
                return NotFound();
            return Ok(bootcamp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBootcampRequest request)
        {
            await _bootcampService.AddAsync(request);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateBootcampRequest request)
        {
            await _bootcampService.Update(request);
            return NoContent();
        }
    }
}