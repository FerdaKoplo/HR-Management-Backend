using hr_management_backend.Data;
using hr_management_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Services
{
    public class AttendanceService
    {
        private readonly AppDataContext _context;

        public AttendanceService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances
                .Include(a => a.Employee)
                .ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Attendance>> GetAttendancesByEmployeeAsync(int employeeId)
        {
            return await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .Include(a => a.Employee)
                .ToListAsync();
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance?> UpdateAttendanceAsync(int id, DateTime? checkIn, DateTime? checkOut)
        {
            var existing = await _context.Attendances.FindAsync(id);
            if (existing == null) return null;

            existing.CheckIn = checkIn ?? existing.CheckIn;
            existing.CheckOut = checkOut ?? existing.CheckOut;

            _context.Attendances.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return false;

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Attendance>> GetAttendancesByDateAsync(DateTime date)
        {
            return await _context.Attendances
                .Where(a => a.Date.Date == date.Date)
                .Include(a => a.Employee)
                .ToListAsync();
        }

    }
}
