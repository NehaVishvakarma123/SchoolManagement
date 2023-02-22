using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DTO;
using SchoolManagement.Models;
using System.Runtime.InteropServices;

namespace SchoolManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Studentcontroller : ControllerBase
	{
		private readonly StudentContext _db;//database instance
		public Studentcontroller(StudentContext db)
		{
			_db = db;
		}

		[HttpGet("Students")]
		public IActionResult GetAll()
		{
			return Ok(_db.Students);
		}

		[HttpGet("Student{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_db.Students.Find(id));
		}

		[HttpPost]
		public IActionResult AddData(StudentDTO obj)
		{
			if (_db.Students.Any(id => id.StudentId == obj.StudentId))
			{
				return BadRequest("Student Already Exists");
			}
			Student s = new Student();
			s.StudentId = obj.StudentId;
			s.StudentName = obj.StudentName;
			s.FathersName = obj.FathersName;
			s.DateOfBirth = DateTime.Now;
			s.Subject = obj.Subject;
			s.TeacherId = obj.TeacherId;
			_db.Students.Add(s);
			_db.SaveChanges();
			return Ok();

		}
		[HttpPut("Student")]
		public IActionResult UpdateData(int id,StudentDTO student)
		{
			var data = _db.Students.Where(x => x.StudentId == id);
			if(data!=null)
			{
				var b = new Student
				{
					StudentId = student.StudentId,
					StudentName = student.StudentName,
					FathersName = student.FathersName,
					DateOfBirth = student.DateOfBirth,
					Subject = student.Subject
				};
				_db.Students.Update(b);
				_db.SaveChanges();
				return Ok();
			}
			return Ok();
		}

		[HttpDelete("Student")]
		public IActionResult delete(int id)
		{
			var d = _db.Students.FirstOrDefault(x => x.StudentId == id);
			if(d==null)
			{
				return BadRequest("User Not Found");
			}
			_db.Students.Remove(d);
			_db.SaveChanges();
			return Ok();
		}
	}
}
