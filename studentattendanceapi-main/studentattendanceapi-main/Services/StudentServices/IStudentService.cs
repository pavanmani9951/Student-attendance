using StudentAttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.StudentServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(string studentId);
        Task<Student> UpdateStudent(Student studentObj);
        Task<Student> CreateStudent(Student studentObj);
        Task<Student> DeleteStudent(string studentId);
    }
}
