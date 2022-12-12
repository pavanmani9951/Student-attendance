using StudentAttendanceSystem.Models;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Services.AccountServices
{
	public interface IAccountService
	{
		public  Task<LoginResponse> Login(Loginrequest user);
	}
}
