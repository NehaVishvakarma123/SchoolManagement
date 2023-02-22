using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DTO;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		public readonly StudentContext _db;
		public TeacherController(StudentContext db)
		{
			_db = db;
		}
		[HttpGet("Teacher")]
		public IActionResult GetAll()
		{
			return Ok(_db.Teachers);
		}

		[HttpGet("Teacher{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_db.Teachers.Find(id));
		}

		[HttpPost]
		public IActionResult AddData(TeacherDTO obj)
		{
			if (_db.Teachers.Any(id => id.TeacherId == obj.TeacherId))
			{
				return BadRequest("Teacher Already Exists");
			}
			Teacher s = new Teacher();
			s.TeacherId = obj.TeacherId;
			s.TeacherName = obj.TeacherName;
			s.ContactNo=obj.ContactNo;
			_db.Teachers.Add(s);
			_db.SaveChanges();
			return Ok();

		}

		[HttpPut("Teacher")]
		public IActionResult UpdateData(int id, TeacherDTO teacher)
		{
			var data = _db.Teachers.Where(x => x.TeacherId == id);
			if (data != null)
			{
				var b = new Teacher
				{
					TeacherId = teacher.TeacherId,
					TeacherName = teacher.TeacherName,
					ContactNo=teacher.ContactNo
				};
				_db.Teachers.Update(b);
				_db.SaveChanges();
				return Ok();
			}
			return Ok();
		}

		[HttpDelete("Teacher")]
		public IActionResult delete(int id)
		{
			var d = _db.Teachers.FirstOrDefault(x => x.TeacherId == id);
			if (d == null)
			{
				return BadRequest("User Not Found");
			}
			_db.Teachers.Remove(d);
			_db.SaveChanges();
			return Ok();
		}
	}
}
