using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly StudentAttendanceSystemContext _context;
		private readonly IConfiguration _configuration;

		public StudentService(StudentAttendanceSystemContext context,IConfiguration configuration)
        {
            _context = context;
			this._configuration = configuration;
		}
        private void CreatePasswordHash(string password, out string passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
				
				hmac.Key = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Encryption:SHAKEY").Value);
                passwordHash = BitConverter.ToString(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }


        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(string studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);
        }

        public async Task<Student> CreateStudent(Student studentObj)
        {
            string password = null;
            this.CreatePasswordHash(studentObj.StudentPassword, out password);
            studentObj.StudentPassword = password;
            var result = await _context.Students.AddAsync(studentObj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> DeleteStudent(string studentId)
        {
            var result = await _context.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);
            if (result != null)
            {
                _context.Students.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Student> UpdateStudent(Student studentObj)
        {
            var result = await _context.Students.FirstOrDefaultAsync(a => a.StudentId == studentObj.StudentId);

            if (result != null)
            {
                result.StudentName = studentObj.StudentName;
                result.StudentGender = studentObj.StudentGender;
                result.StudentEmail = studentObj.StudentEmail;
                result.StudentContact = studentObj.StudentContact;
                result.StudentUsername = studentObj.StudentUsername;
                
                string password = null;
                this.CreatePasswordHash(studentObj.StudentPassword, out password);
                studentObj.StudentPassword = password;

                result.StudentPassword = password;
                _context.Students.Update(result);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
