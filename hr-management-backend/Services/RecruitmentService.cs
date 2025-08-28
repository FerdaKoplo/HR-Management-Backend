using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class RecruitmentService
    {
        private readonly AppDataContext _context;

        public RecruitmentService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Recruitment>> GetAllRecruitments()
        {
            return await _context.Recruitments
                         .Include(j => j.JobTitleId)
                          .ToListAsync();
        }

        public async Task<Recruitment?> GetRecruitmentByIdAsync(int id)
        {
            return await _context.Recruitments
                .Include(r => r.JobTitle)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Recruitment> CreateRecruitmentAsync(Recruitment recruitment)
        {
            _context.Recruitments.Add(recruitment);
            await _context.SaveChangesAsync();
            return recruitment;
        }

        public async Task<Recruitment?> UpdateRecruitmentAsync(int id, Recruitment updatedRecruitment)
        {
            var existing = await _context.Recruitments.FindAsync(id);
            if (existing == null) return null;

            existing.CandidateName = updatedRecruitment.CandidateName;
            existing.JobTitleId = updatedRecruitment.JobTitleId;
            existing.Status = updatedRecruitment.Status;
            existing.AppliedOn = updatedRecruitment.AppliedOn;

            _context.Recruitments.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteRecruitmentAsync(int id)
        {
            var recruitment = await _context.Recruitments.FindAsync(id);
            if (recruitment == null) return false;

            _context.Recruitments.Remove(recruitment);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
