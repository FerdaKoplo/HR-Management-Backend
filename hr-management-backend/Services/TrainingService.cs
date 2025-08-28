using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{

    public class TrainingService
    {
        private readonly AppDataContext _context;

        public TrainingService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            return await _context.Training
                .ToListAsync();
        }

        public async Task<Training?> GetTrainingByIdAsync(int id)
        {
            return await _context.Training
                .Include(t => t.EmployeeTrainings)
                    .ThenInclude(et => et.Employee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Training> CreateTrainingAsync(Training training)
        {
            _context.Training.Add(training);
            await _context.SaveChangesAsync();
            return training;
        }

        public async Task<Training?> UpdateTrainingAsync(int id, Training updatedTraining)
        {
            var existing = await _context.Training.FindAsync(id);
            if (existing == null) return null;

            existing.Title = updatedTraining.Title;

            _context.Training.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteTrainingAsync(int id)
        {
            var training = await _context.Training.FindAsync(id);
            if (training == null) return false;

            _context.Training.Remove(training);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignEmployeeAsync(int trainingId, int employeeId)
        {
            var training = await _context.Training
                .Include(t => t.EmployeeTrainings)
                .FirstOrDefaultAsync(t => t.Id == trainingId);

            var employee = await _context.Employees.FindAsync(employeeId);

            if (training == null || employee == null) return false;

            // Prevent duplicates
            if (!training.EmployeeTrainings.Any(et => et.EmployeeId == employeeId))
            {
                training.EmployeeTrainings.Add(new EmployeeTraining
                {
                    TrainingId = trainingId,
                    EmployeeId = employeeId
                });
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> RemoveEmployeeAsync(int trainingId, int employeeId)
        {
            var trainingEmployee = await _context.EmployeeTraining
                .FirstOrDefaultAsync(et => et.TrainingId == trainingId && et.EmployeeId == employeeId);

            if (trainingEmployee == null) return false;

            _context.EmployeeTraining.Remove(trainingEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetEmployeesByTrainingAsync(int trainingId)
        {
            var training = await _context.Training
                .Include(t => t.EmployeeTrainings)
                    .ThenInclude(et => et.Employee)
                .FirstOrDefaultAsync(t => t.Id == trainingId);

            return training?.EmployeeTrainings.Select(et => et.Employee).ToList() ?? new List<Employee>();
        }



    }
}
