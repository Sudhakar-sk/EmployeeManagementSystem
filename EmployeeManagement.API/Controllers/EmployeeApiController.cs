using EmployeeManagement.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        readonly IEmployeeService _IEmployeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            _IEmployeeService = employeeService;
        }
        [HttpGet]
        public ActionResult EmployeeDashboard()
        {
            var EmployeeList = _IEmployeeService.GetEmployeeDetails();
          
            return Ok(EmployeeList);
        }

    }
}
