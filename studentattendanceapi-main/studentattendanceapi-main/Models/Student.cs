using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentAttendanceSystem.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentGender { get; set; }

        public string StudentEmail { get; set; }
       
        public double StudentContact { get; set; }
              
        public string StudentUsername { get; set; }

        public string StudentPassword { get; set; }

		public StudentType StudentType { get; set; }

	}
}