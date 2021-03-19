using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedArborTest.Common.DTO;
using RedArborTest.Service;

namespace RedArborTest.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [Route("redarbore/{id}")]
        public IEnumerable<Employee> GetEmployees(int? id)
        {
            return employeeService.GetEmployees(id);
        }

        [HttpGet]
        [Route("redarbor")]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return employeeService.GetEmployees(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("redarbor")]

        public async Task<IActionResult> CreateEmployee(EmployeePost employee)
        {
            try
            {
                employee.EmployeeId = null;
                employeeService.CreateUpdateEmployee(employee);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("redarbor/{id}")]

        public async Task<IActionResult> UpdateEmployee(EmployeePost employee, int id)
        {
            try
            {
                employee.EmployeeId = id;
                employeeService.CreateUpdateEmployee(employee);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("redarbor/{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                employeeService.DeleteEmployee(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
