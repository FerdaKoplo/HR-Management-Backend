using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace hr_management_backend.Services
{
    public class DepartmentService
    {
        private readonly AppDataContext _context;

        public DepartmentService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Include(e => e.Employees)
                .Include(e => e.Manager)
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }


        public async Task<Department?> UpdateDepartmentAsync(int id, Department updatedDepartment)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null) return null;

            existingDepartment.Name = updatedDepartment.Name;
            existingDepartment.ManagerId = updatedDepartment.ManagerId;

            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();

            return existingDepartment;
        }


        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignEmployeeToDepartmentAsync(int departmentId, int employeeId)
        {
            // get detail of department
            var department = await _context.Departments
                             .Include(d => d.Employees) 
                             .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null) return false;

            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return false;

            if (!department.Employees.Contains(employee))
            {
                department.Employees.Add(employee);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveEmployeeInDepartment(int departmentId, int employeeId)
        {
            // get detail of department
            var department = await _context.Departments
                                 .FirstOrDefaultAsync(e => e.Id == employeeId && e.Id == departmentId);

            if (department == null) return false;

            var employee = await _context.Employees.FindAsync(employeeId);
            // Remove the association
            employee.DepartmentId = null;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignManagerAsync(int departmentId, int managerId)
        {
            // just need the entity to update so find async is enough
            var department = await _context.Departments.FindAsync(departmentId);
            var manager = await _context.Employees.FindAsync(managerId);

            if (department == null || manager == null) return false;

            department.ManagerId = managerId;
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Department>> SearchDepartmentsAsync(string keyword)
        {
            return await _context.Departments
                .Where(d => d.Name.Contains(keyword))
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .ToListAsync();
        }

    }
}
