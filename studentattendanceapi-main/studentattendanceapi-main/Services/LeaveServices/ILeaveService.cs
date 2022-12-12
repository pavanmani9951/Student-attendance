using StudentAttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.LeaveServices
{
    public interface ILeaveService
    {
        Task<IEnumerable<Leave>> GetLeaves();
        Task<Leave> GetLeaveById(string leaveId);
        Task<Leave> UpdateLeave(Leave leaveObj);
        Task<Leave> CreateLeave(Leave leaveObj);
        Task<Leave> DeleteLeave(string leaveId);
    }
}
