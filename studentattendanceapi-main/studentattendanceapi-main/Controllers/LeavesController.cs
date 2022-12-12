using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Models;
using StudentAttendanceSystem.Services.LeaveServices;

namespace StudentAttendanceSystem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeavesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }


        [HttpGet]
        [Route("api/[controller]/GetLeaves")]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            return Ok(await _leaveService.GetLeaves());
        }

        [HttpGet]
        [Route("api/[controller]/GetLeave/{id}")]
        public async Task<ActionResult<Leave>> GetLeaveById(string id)
        {
            var result = await _leaveService.GetLeaveById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/CreateLeave")]
        public async Task<ActionResult<Leave>> CreateLeave(Leave leaveObj)
        {
            var leaveCreate = await _leaveService.CreateLeave(leaveObj);
            return Ok(leaveCreate);
        }

        [HttpPut]
        [Route("api/[controller]/UpdateLeave")]
        public async Task<ActionResult<Leave>> UpdateLeave(Leave leaveObj)
        {
            var leaveUpdate = await _leaveService.UpdateLeave(leaveObj);
            return Ok(leaveUpdate);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteLeave/{id}")]
        public async Task<ActionResult<Leave>> DeleteLeave(string id)
        {
            var leavedelete = await _leaveService.DeleteLeave(id);
            return Ok(leavedelete);
        }
    }
}
