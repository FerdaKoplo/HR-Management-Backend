using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class SalaryService
    {
        private readonly AppDataContext _context;

        public SalaryService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Salary>> GetSalariesAsync()
        {
            return await _context.Salaries
                .Include(j => j.Employee)
                .ToListAsync();
        }

        public async Task<Salary?> GetSalaryByIdAsync(int id)
        {
            return await _context.Salaries
                .Include(j => j.Employee)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Employee?> GetEmployeeBySalaryAsync(int salaryId)
        {
            var salary = await _context.Salaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == salaryId);

            return salary?.Employee;
        }

        public async Task<Salary> CreateSalaryAsync(Salary salary)
        {
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary?> UpdateSalaryAsync(int id, Salary updatedSalary)
        {
            var existing = await _context.Salaries.FindAsync(id);
            if (existing == null) return null;

            existing.Amount = updatedSalary.Amount;
            existing.EffectiveDate = updatedSalary.EffectiveDate;

            _context.Salaries.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null) return false;

            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
