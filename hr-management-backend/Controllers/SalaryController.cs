using AutoMapper;
using hr_management_backend.DTOs.Recruitment;
using hr_management_backend.DTOs.Salary;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hr_management_backend.Controllers
{
    
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SalaryService _salaryService;

        public SalaryController(SalaryService salaryService, IMapper mapper)
        {
            _mapper = mapper;
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaries = await _salaryService.GetSalariesAsync();
            var dto = _mapper.Map<List<SalaryDTO>>(salaries);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var salary = await _salaryService.GetSalaryByIdAsync(id);
            if (salary == null) return NotFound();

            var dto = _mapper.Map<SalaryDetailDTO>(salary);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalaryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var salary = _mapper.Map<Salary>(dto);
            var created = await _salaryService.CreateSalaryAsync(salary);

            var result = _mapper.Map<SalaryDetailDTO>(created);
            return CreatedAtAction(nameof(GetSalaryById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalaryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var salary = _mapper.Map<Salary>(dto);
            var updated = await _salaryService.UpdateSalaryAsync(id, salary);

            if (salary == null) return NotFound();

            var result = _mapper.Map<SalaryDetailDTO>(updated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _salaryService.DeleteSalaryAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

    }
}
