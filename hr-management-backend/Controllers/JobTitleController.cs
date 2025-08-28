using AutoMapper;
using hr_management_backend.DTOs.Department;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.DTOs.JobTitle;
using hr_management_backend.DTOs.Recruitment;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hr_management_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class JobTitleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly JobTitleService _jobTitleService;

        public JobTitleController(JobTitleService jobTitleService, IMapper mapper)
        {
            _mapper = mapper;
            _jobTitleService = jobTitleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobTitle()
        {
            var jobTitle = await _jobTitleService.GetJobTitlesAsync();
            var dto = _mapper.Map<List<JobTitleDTO>>(jobTitle);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobTitleById(int id)
        {
            var jobTitle = await _jobTitleService.GetJobTitleByIdAsync(id);
            if (jobTitle == null) return NotFound();

            var dto = _mapper.Map<JobTitleDetailDTO>(jobTitle);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobTitleDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobTitle = _mapper.Map<JobTitle>(dto);
            var created = await _jobTitleService.CreateJobTitleAsync(jobTitle);

            var result = _mapper.Map<JobTitleDetailDTO>(created);
            return CreatedAtAction(nameof(GetJobTitleById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobTitleDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobTitle = _mapper.Map<JobTitle>(dto);
            var updated = await _jobTitleService.UpdateJobTitleAsync(id, jobTitle);

            if (updated == null) return NotFound();

            var result = _mapper.Map<JobTitleDetailDTO>(updated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _jobTitleService.DeleteJobTitleAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpPost("{jobTitleId}/assign-employee")]
        public async Task<IActionResult> AssignEmployee(int jobTitleId, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _jobTitleService.AssignEmployeeToJobTitleAsync(jobTitleId, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpPost("remove-employee")]
        public async Task<IActionResult> RemoveEmployee([FromBody] AssignEmployeeDTO dto)
        {
            var success = await _jobTitleService.RemoveEmployeeFromJobTitleAsync(dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var employees = await _jobTitleService.GetEmployeesByJobTitleAsync(id);
            var dto = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(dto);
        }

        [HttpGet("{id}/recruitments")]
        public async Task<IActionResult> GetRecruitments(int id)
        {
            var recruitments = await _jobTitleService.GetRecruitmentsByJobTitleAsync(id);
            var dto = _mapper.Map<List<RecruitmentDTO>>(recruitments);
            return Ok(dto);
        }


    }
}
