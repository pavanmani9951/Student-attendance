using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.LeaveServices
{
    public class LeaveService : ILeaveService
    {
        private readonly StudentAttendanceSystemContext _context;

        public LeaveService(StudentAttendanceSystemContext context)
        {
            _context = context;
        }

        public async Task<Leave> CreateLeave(Leave leaveObj)
        {
            var result = await _context.Leaves.AddAsync(leaveObj);
            await _context.SaveChangesAsync();
            return (leaveObj);
        }

        public async Task<Leave> DeleteLeave(string leaveId)
        {
            var result = await _context.Leaves.FirstOrDefaultAsync(a => a.LeaveId == leaveId);
            if (result != null)
            {
                _context.Leaves.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Leave> GetLeaveById(string leaveId)
        {
            return await _context.Leaves.Include(e=>e.Students).FirstOrDefaultAsync(a => a.LeaveId == leaveId);
        }

        public async Task<IEnumerable<Leave>> GetLeaves()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<Leave> UpdateLeave(Leave leaveObj)
        {
            var result = await _context.Leaves.FirstOrDefaultAsync(a => a.LeaveId == leaveObj.LeaveId);

            if (result != null)
            {
                result.LeaveId = leaveObj.LeaveId;
                result.LeaveReason = leaveObj.LeaveReason;
                result.LeaveApplyDate = leaveObj.LeaveApplyDate;
                result.LeaveStartDate = leaveObj.LeaveStartDate;
                result.LeaveEndDate = leaveObj.LeaveEndDate;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
