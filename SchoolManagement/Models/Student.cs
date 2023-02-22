using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolManagement.Models
{
	public class Student
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string FathersName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Subject { get; set; }

		public string? Role { get; set; } = "Student";





		[ForeignKey("TeacherId")]
		public int TeacherId { get; set; }
		[JsonIgnore]
		public Teacher Teacher { get; set; }
	}
}
