using System.Text.Json.Serialization;

namespace StudentAttendanceSystem.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum StudentType
	{
		Admin , 
		Student 
	}
}
