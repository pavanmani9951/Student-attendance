using StudentAttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.AttendanceServices
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAttendances();
        Task<Attendance> GetAttendanceById(string attendanceId);
        Task<Attendance> UpdateAttendance(Attendance attendanceObj);
        Task<Attendance> CreateAttendance(Attendance attendanceObj);
        Task<Attendance> DeleteAttendance(string attendanceId);
    }
}
