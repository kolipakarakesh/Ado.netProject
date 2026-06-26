using EmployeeA.Model;
using EmployeeA.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EmployeeA.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeAController : ControllerBase
    {
        private readonly IEmployeeAService _employeeAService;
        public EmployeeAController(IEmployeeAService employeeAService)
        {
            _employeeAService = employeeAService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var res = await _employeeAService.GetAllEmployee();
                return Ok(res);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var res = await _employeeAService.GetEmployeeById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            try
            {
                var res = await _employeeAService.InsertEmployeeAsync(employee);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var response = await _employeeAService.UpdateEmployeeAsync(employee);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var response = await _employeeAService.DeleteEmployeeAsync(id);
                return Ok(response);
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError); }
        }
    }
}
