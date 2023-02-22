﻿using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Models
{
	public class StudentContext:DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> options):base(options)
		{

		}
		public DbSet<Student> Students { get;set; }
		public DbSet<Teacher> Teachers { get;set; }

	}
}
