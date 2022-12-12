using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Models
{
    public class Attendance
    {
        [Key]
        public string AttendanceId { get; set; }

        public string AttendanceStatus { get; set; }

        public DateTime AttendanceDate { get; set; }

        //Foreign Key
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public virtual Student Students { get; set; }
    }
}