using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class EmployeeService
    {
        private readonly AppDataContext _context;

        public EmployeeService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.JobTitle)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.JobTitle)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null) return null;

            // update field
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.DepartmentId = updatedEmployee.DepartmentId;
            existingEmployee.JobTitleId = updatedEmployee.JobTitleId;

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        // search or filter

        public async Task<List<Employee>> SearchEmployeesAsync(string keyword)
        {
            return await _context.Employees
                .Where(e => e.Name.Contains(keyword) || e.Email.Contains(keyword))
                .Include(e => e.Department)
                .Include(e => e.JobTitle)
                .ToListAsync();
        }

   
    }
}
