using AutoMapper;
using hr_management_backend.DTOs.Department;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hr_management_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(DepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var dto = _mapper.Map<List<DepartmentDTO>>(departments);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();

            var dto = _mapper.Map<DepartmentDetailDTO>(department);
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var department = _mapper.Map<Department>(dto);
            var created = await _departmentService.CreateDepartmentAsync(department);

            var result = _mapper.Map<DepartmentDetailDTO>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var department = _mapper.Map<Department>(dto);
            var updated = await _departmentService.UpdateDepartmentAsync(id, department);

            if (updated == null) return NotFound();

            var results = _mapper.Map<DepartmentDetailDTO>(updated);

            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _departmentService.DeleteDepartmentAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/assign-employee")]
        public async Task<IActionResult> AssignEmployee(int id, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _departmentService.AssignEmployeeToDepartmentAsync(id, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpPost("{id}/remove-employee")]
        public async Task<IActionResult> RemoveEmployee(int id, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _departmentService.RemoveEmployeeInDepartment(id, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }


        [HttpPost("{id}/assign-manager")]
        public async Task<IActionResult> AssignManager(int id, [FromBody] AssignEmployeeDTO dto)
        {
            var success = await _departmentService.AssignManagerAsync(id, dto.EmployeeId);
            if (!success) return NotFound();

            return NoContent();
        }


    }
}
