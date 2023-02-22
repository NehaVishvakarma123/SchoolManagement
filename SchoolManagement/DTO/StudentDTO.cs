using SchoolManagement.Models;

namespace SchoolManagement.DTO
{
	public class StudentDTO
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string FathersName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Subject { get; set; }
		public int TeacherId { get; set; }
		//public Teacher Teacher { get; set; }
	}
}
