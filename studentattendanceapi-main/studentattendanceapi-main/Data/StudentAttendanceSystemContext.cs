using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Models;
using StudentAttendanceSystem.Configurations;

namespace StudentAttendanceSystem.Data
{
    public class StudentAttendanceSystemContext : DbContext
    {
        public StudentAttendanceSystemContext (DbContextOptions<StudentAttendanceSystemContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Leave> Leaves { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new AttendanceConfiguration());
            builder.ApplyConfiguration(new LeaveConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
        }

        
    }
}
