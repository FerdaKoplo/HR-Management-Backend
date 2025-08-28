using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class EvaluationService
    {
        private readonly AppDataContext _context;

        public EvaluationService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Evaluation>> GetAllEvaluationsAsync()
        {
            return await _context.Evaluations
                .Include(e => e.Employee)
                .ToListAsync();
        }

        public async Task<Evaluation?> GetEvaluationByIdAsync(int id)
        {
            return await _context.Evaluations
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Evaluation>> GetEvaluationsByEmployeeAsync(int employeeId)
        {
            return await _context.Evaluations
                .Where(e => e.EmployeeId == employeeId)
                .Include(e => e.Employee)
                .ToListAsync();
        }

        public async Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }

        public async Task<Evaluation?> UpdateEvaluationAsync(int id, Evaluation updatedEvaluation)
        {
            var existing = await _context.Evaluations.FindAsync(id);
            if (existing == null) return null;

            existing.Comments = updatedEvaluation.Comments;
            existing.Score = updatedEvaluation.Score;
            existing.Date = updatedEvaluation.Date;

            _context.Evaluations.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteEvaluationAsync(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null) return false;

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
