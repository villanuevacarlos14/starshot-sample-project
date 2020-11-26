using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starshot.DTO;
using Starshot.Service;

namespace Starshot.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] string search ="", [FromQuery] int active = 0)
        {
            return Ok(await this._employeeService.Get(search, active));
        }

        [HttpPost()]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            return Ok(await this._employeeService.Save(employeeDTO));
        }

        [HttpPut()]
        public async Task<IActionResult> Put(EmployeeDTO employeeDTO)
        {
            return Ok(await this._employeeService.Save(employeeDTO));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] int Id)
        {
            await this._employeeService.Delete(Id);
            return Ok();
        }

        [HttpPost()]
        [Route("Timein")]
        public async Task<IActionResult> Timein([FromQuery]int employeeId, [FromQuery] DateTime date)
        {
            return Ok(await this._employeeService.TimeIn(employeeId, date));
        }

        [HttpPost()]
        [Route("Timeout")]
        public async Task<IActionResult> Timeout([FromQuery] int employeeId, [FromQuery] DateTime date)
        {
            return Ok(await this._employeeService.TimeOut(employeeId, date));
        }

        [HttpGet()]
        [Route("Attendance")]
        public async Task<IActionResult> Attendance([FromQuery]DateTime date)
        {
            return Ok(await this._employeeService.Attendance(date));
        }

    }
}
