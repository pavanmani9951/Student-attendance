using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using StudentAttendanceSystem.Services.AdminServices;
using Microsoft.AspNetCore.Authorization;

namespace StudentAttendanceSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpGet]
        [Route("api/[controller]/GetAdmins")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return (await _adminService.GetAdmins()).ToList();
        }

        [HttpGet]
        [Route("api/[controller]/GetAdmin/{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(string id)
        {
            var result = await _adminService.GetAdminById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/CreateAdmin")]
        public async Task<ActionResult<Admin>> CreateAdmin(Admin adminObj)
        {
            var createAdmin = await _adminService.CreateAdmin(adminObj);
            return Ok(createAdmin);
        }

        [HttpPut]
        [Route("api/[controller]/UpdateAdmin")]
        public async Task<ActionResult<Admin>> UpdateAdmin(Admin adminObj)
        {
            var AdminUpdate = await _adminService.UpdateAdmin(adminObj);
            return Ok(AdminUpdate);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteAdmin/{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(string id)
        {
            var AdminDelete = await _adminService.DeleteAdmin(id);
            return Ok(AdminDelete);
        }
    }
}
