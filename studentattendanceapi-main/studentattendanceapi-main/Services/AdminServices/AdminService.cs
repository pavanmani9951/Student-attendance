using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly StudentAttendanceSystemContext _context;

        public AdminService(StudentAttendanceSystemContext context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAdmin(Admin adminObj)
        {
            var result = await _context.Admins.AddAsync(adminObj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Admin> DeleteAdmin(string adminId)
        {
            var result = await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == adminId);
            if (result != null)
            {
                _context.Admins.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Admin> GetAdminById(string adminId)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == adminId);
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> UpdateAdmin(Admin adminObj)
        {
            var result = await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == adminObj.AdminId);

            if (result != null)
            {
                result.AdminUsername = adminObj.AdminUsername;
                result.AdminPassword = adminObj.AdminPassword;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
