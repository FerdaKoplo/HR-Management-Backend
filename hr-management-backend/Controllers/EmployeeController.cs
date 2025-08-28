using AutoMapper;
using hr_management_backend.DTOs.Employee;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;

namespace hr_management_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var dto = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();

            var dto = _mapper.Map<EmployeeDetailDTO>(employee);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = _mapper.Map<Employee>(dto);
            var created = await _employeeService.CreateEmployeeAsync(employee);

            var result = _mapper.Map<EmployeeDetailDTO>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var employee = _mapper.Map<Employee>(dto);
            var updated = await _employeeService.UpdateEmployeeAsync(id, employee);

            if (updated == null) return NotFound();

            var results = _mapper.Map<EmployeeDetailDTO>(updated);

            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/salaries")]
        public async Task<IActionResult> GetEmployeeSalaries(int id)
        {
            var employees = await _employeeService.GetSalariesByEmployeeAsync(id);
            var dto = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(dto);
        }
    }
}
