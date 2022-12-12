using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(e => e.AttendanceId).IsRequired().HasMaxLength(10);
            builder.Property(e => e.AttendanceDate).IsRequired();
            builder.Property(e => e.AttendanceStatus).IsRequired().HasMaxLength(7);
        }
    }
}
