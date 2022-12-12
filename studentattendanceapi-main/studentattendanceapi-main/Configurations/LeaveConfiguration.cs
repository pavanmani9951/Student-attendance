using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Configurations
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.Property(e => e.LeaveId).IsRequired().HasMaxLength(10);
            builder.Property(e => e.LeaveReason).IsRequired().HasMaxLength(150);
            builder.Property(e => e.LeaveApplyDate).IsRequired();
            builder.Property(e => e.LeaveStartDate).IsRequired();
            builder.Property(e => e.LeaveEndDate).IsRequired();
        }
    }
}
