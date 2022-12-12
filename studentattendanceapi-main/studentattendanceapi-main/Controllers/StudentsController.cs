using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using StudentAttendanceSystem.Services.StudentServices;
using Microsoft.AspNetCore.Authorization;

namespace StudentAttendanceSystem.Controllers
{
	
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentsController(IStudentService studentService)
		{
			_studentService =studentService;
		}


		[HttpGet]
		[Route("api/[controller]/GetStudents")]
		public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
		{
			return Ok(await _studentService.GetStudents());
		}

		[HttpGet]
		[Route("api/[controller]/GetStudent/{id}")]
		public async Task<ActionResult<Student>> GetStudentById(string id)
		{
			var result = await _studentService.GetStudentById(id);
			return Ok(result);
		}

		[HttpPost]
		[Route("api/[controller]/CreateStudent")]
		public async Task<ActionResult<Student>> CreateStudent(Student studentObj)
		{
			var createStudent = await _studentService.CreateStudent(studentObj);
			return Ok(createStudent);
		}

		[HttpPut]
		[Route("api/[controller]/UpdateStudent")]
		public async Task<ActionResult<Student>> UpdateStudent(Student studentObj)
		{
			var studentUpdate = await _studentService.UpdateStudent(studentObj);
			return Ok(studentUpdate);
		}

		[HttpDelete]
		[Route("api/[controller]/DeleteStudent/{id}")]
		public async Task<ActionResult<Student>> DeleteStudent(string id)
		{
			var studentDelete = await _studentService.DeleteStudent(id);
			return Ok(studentDelete);
		}
		


	}
}
