using AutoMapper;
using hr_management_backend.DTOs.Department;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.DTOs.Training;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hr_management_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly TrainingService _trainingService;
        private readonly IMapper _mapper;

        public TrainingController(TrainingService trainingService, IMapper mapper)
        {
            _trainingService = trainingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _trainingService.GetAllTrainingsAsync();
            var dto = _mapper.Map<List<TrainingDTO>>(trainings);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var training = await _trainingService.GetTrainingByIdAsync(id);
            if (training == null) return NotFound();

            var dto = _mapper.Map<TrainingDetailDTO>(training);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var training = _mapper.Map<Training>(dto);
            var created = await _trainingService.CreateTrainingAsync(training);

            var result = _mapper.Map<TrainingDetailDTO>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTrainingDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var training = _mapper.Map<Training>(dto);
            var updated = await _trainingService.UpdateTrainingAsync(id, training);

            if (updated == null) return NotFound();

            var result = _mapper.Map<TrainingDetailDTO>(updated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _trainingService.DeleteTrainingAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/assign-employee")]
        public async Task<IActionResult> AssignEmployee(int id, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _trainingService.AssignEmployeeAsync(id, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/remove-employee")]
        public async Task<IActionResult> RemoveEmployee(int id, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _trainingService.RemoveEmployeeAsync(id, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var employees = await _trainingService.GetEmployeesByTrainingAsync(id);
            var dto = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(dto);
        }

    }
}
