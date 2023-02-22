using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
	public class Teacher
	{
		[Key]
		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
		public long ContactNo { get;set; }

		public string? Role { get; set; } = "Teacher";


		public ICollection<Student> Students { get; set; }

		
	}
}
