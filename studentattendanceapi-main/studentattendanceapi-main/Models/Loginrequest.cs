﻿namespace StudentAttendanceSystem.Models
{
	public class Loginrequest
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public StudentType StudentType { get; set; }
	}
}
