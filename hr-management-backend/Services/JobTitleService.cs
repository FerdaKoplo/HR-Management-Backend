using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class JobTitleService
    {
        private readonly AppDataContext _context;

        public JobTitleService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<(List<JobTitle> Items, int TotalCount)> GetJobTitlesPaginatedAsync(int page = 1, int pageSize = 10)
        {
            var totalCount = await _context.JobTitles.CountAsync();

            var items = await _context.JobTitles
                .Include(j => j.Employees)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task<JobTitle?> GetJobTitleByIdAsync(int id)
        {
            return await _context.JobTitles
                .Include(j => j.Employees)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<List<Employee>> GetEmployeesByJobTitleAsync(int jobTitleId)
        {
            var jobTitle = await _context.JobTitles
                .Include(j => j.Employees)
                .FirstOrDefaultAsync(j => j.Id == jobTitleId);

            return jobTitle?.Employees.ToList() ?? new List<Employee>();
        }

        public async Task<List<Recruitment>> GetRecruitmentsByJobTitleAsync(int jobTitleId)
        {
            var jobTitle = await _context.JobTitles
                .Include(j => j.Recruitments)
                .FirstOrDefaultAsync(j => j.Id == jobTitleId);

            return jobTitle?.Recruitments.ToList() ?? new List<Recruitment>();
        }

        public async Task<JobTitle> CreateJobTitleAsync(JobTitle jobTitle)
        {
            _context.JobTitles.Add(jobTitle);
            await _context.SaveChangesAsync();
            return jobTitle;
        }


        public async Task<JobTitle?> UpdateJobTitleAsync(int id, JobTitle updatedJobTitle)
        {
            var existing = await _context.JobTitles.FindAsync(id);
            if (existing == null) return null;

            existing.Title = updatedJobTitle.Title;

            _context.JobTitles.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<bool> DeleteJobTitleAsync(int id)
        {
            var jobTitle = await _context.JobTitles.FindAsync(id);
            if (jobTitle == null)
                return false;

            _context.JobTitles.Remove(jobTitle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignEmployeeToJobTitleAsync(int jobTitleId, int employeeId)
        {
            var jobTitle = await _context.JobTitles.FindAsync(jobTitleId);
            var employee = await _context.Employees.FindAsync(employeeId);

            if (jobTitle == null || employee == null) return false;

            employee.JobTitleId = jobTitleId;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveEmployeeFromJobTitleAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null || employee.JobTitleId == null) return false;

            employee.JobTitleId = null;
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
