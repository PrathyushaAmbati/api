using BAL.Services;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {

        private EmployeeService _employService;
        private readonly ILogger<EmployController> _logger;
        public EmployController(ILogger<EmployController> logger,EmployeeService employService)
        {
            _employService = employService;
            _logger = logger;
        }
        [HttpPost("AddEmploy")]
        public IActionResult AddEmploy([FromBody] EmployDetails employDetails)
        {
            _employService.AddEmploy(employDetails);
            return Ok("Inserted Successfully");
        }
        [HttpPut("UpdateEmploy")]
        public IActionResult UpdateEmploy([FromBody] EmployDetails employDetails)
        {
            _employService.UpdateEmploy(employDetails);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteEmploy")]
        public IActionResult DeleteEmploy(int EmpID)
        {
            _employService.DeleteEmploy(EmpID);
            return Ok("Deleted Successfully");
        }
        [HttpGet("GetEmployDetails")]
        public IEnumerable<EmployDetails> GetEmployDetails()
        {
            _logger.LogWarning("This is demo warning");
            _logger.LogError(new Exception(), "demo exception");
            _logger.LogInformation($"Controller action excecuted on:{DateTime.Now.TimeOfDay}");
            var result = _employService.GetEmpDetails();
            _logger.LogInformation($"We got {result.ToList()} from service");
            return result;
        }
        [HttpGet("GetEmployDetailsByID")]
        public EmployDetails GetEmployDetailsByID(int EmpID)
        {
            return _employService.GetEmpDetailsByID(EmpID);
        }
    }
}
