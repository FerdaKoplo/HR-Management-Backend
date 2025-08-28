using AutoMapper;
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
    public class RecruitmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RecruitmentService _recruitmentService;

        public RecruitmentController(IMapper mapper, RecruitmentService recruitmentService)
        {
            _mapper = mapper;
            _recruitmentService = recruitmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecruitments()
        {
            var recruitmnets = await _recruitmentService.GetAllRecruitments();
            var dto = _mapper.Map<List<RecruitmentDTO>>(recruitmnets);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruitmentById(int id)
        {
            var recruitment = await _recruitmentService.GetRecruitmentByIdAsync(id);
            if (recruitment == null) return NotFound();

            var dto = _mapper.Map<RecruitmentDetailDTO>(recruitment);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecruitmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var recruitment = _mapper.Map<Recruitment>(dto);
            var created = await _recruitmentService.CreateRecruitmentAsync(recruitment);

            var result = _mapper.Map<RecruitmentDetailDTO>(created);
            return CreatedAtAction(nameof(GetRecruitmentById), new { id = created.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRecruitmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var recruitment = _mapper.Map<Recruitment>(dto);
            var updated = await _recruitmentService.UpdateRecruitmentAsync(id, recruitment);

            if (updated == null) return NotFound();

            var result = _mapper.Map<RecruitmentDetailDTO>(updated);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _recruitmentService.DeleteRecruitmentAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

    }
}
