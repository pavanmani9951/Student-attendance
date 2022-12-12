using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.StudentId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.StudentName).IsRequired().HasMaxLength(25);
            builder.Property(e => e.StudentGender).IsRequired().HasMaxLength(6);
            builder.Property(e => e.StudentContact).IsRequired().HasMaxLength(10);
            builder.Property(e => e.StudentUsername).IsRequired().HasMaxLength(20);
            builder.Property(e => e.StudentPassword).IsRequired();
        }
    }
}
