using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly StudentAttendanceSystemContext _context;

        public AttendanceService(StudentAttendanceSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            return await _context.Attendances.ToListAsync();
        }
        public async Task<Attendance> GetAttendanceById(string attendanceId)
        {
            var result =  await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceId);
            return result;
        }

        public async Task<Attendance> CreateAttendance(Attendance attendanceObj)
        {
            var result = await _context.Attendances.AddAsync(attendanceObj);
           
            await _context.SaveChangesAsync();
            return attendanceObj;
        }

        public async Task<Attendance> DeleteAttendance(string attendanceId)
        {
            var result = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceId);
            if (result != null)
            {
                _context.Attendances.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        
        public async Task<Attendance> UpdateAttendance(Attendance attendanceObj)
        {
            var result = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == attendanceObj.AttendanceId);

            if (result != null)
            {
                result.AttendanceId = attendanceObj.AttendanceId;
                result.AttendanceStatus = attendanceObj.AttendanceStatus;
                result.AttendanceDate = attendanceObj.AttendanceDate;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
