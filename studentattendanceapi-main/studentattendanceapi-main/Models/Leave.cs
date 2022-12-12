using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAttendanceSystem.Models
{
    public class Leave
    {
        [Key]
        public string LeaveId { get; set; }

        public DateTime LeaveApplyDate { get; set; }

        public DateTime LeaveStartDate { get; set; }

        public DateTime LeaveEndDate { get; set; }

        public string LeaveReason { get; set; }

        //Foreign Key
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public virtual Student Students { get; set; }

    }
}