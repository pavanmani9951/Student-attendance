using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(e => e.AdminId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AdminUsername).IsRequired().HasMaxLength(20);
            builder.Property(e => e.AdminPassword).IsRequired().HasMaxLength(20);
        }
    }
}
