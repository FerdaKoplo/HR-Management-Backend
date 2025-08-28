using AutoMapper;
using hr_management_backend.DTOs.Evaluation;
using hr_management_backend.Models;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hr_management_backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EvaluationService _evaluationService;
    
        public EvaluationController(IMapper mapper, EvaluationService evaluationService)
        {
            _mapper = mapper;
            _evaluationService = evaluationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluations = await _evaluationService.GetAllEvaluationsAsync();
            var dto = _mapper.Map<List<EvaluationDetailDTO>>(evaluations);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null) return NotFound();

            var dto = _mapper.Map<EvaluationDetailDTO>(evaluation);
            return Ok(dto);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            var evaluations = await _evaluationService.GetEvaluationsByEmployeeAsync(employeeId);
            var dto = _mapper.Map<List<EvaluationDetailDTO>>(evaluations);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluationDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var evaluation = _mapper.Map<Evaluation>(dto);
            var created = await _evaluationService.CreateEvaluationAsync(evaluation);

            var result = _mapper.Map<EvaluationDetailDTO>(created);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvaluationDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var evaluation = _mapper.Map<Evaluation>(dto);
            var updated = await _evaluationService.UpdateEvaluationAsync(id, evaluation);

            if (updated == null) return NotFound();

            var result = _mapper.Map<EvaluationDetailDTO>(updated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _evaluationService.DeleteEvaluationAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
