using EmployeeA.Service;
using Microsoft.AspNetCore.Mvc;

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
                var response = await _employeeAService.GetAllEmployee();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id) 
        {
            try {
            var res=await _employeeAService.GetEmployeeById(id);
                return Ok(res);

            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee() {
            return null;
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult>UpdateEmployee(int id)
        {
            return null;
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteEmployee(int id) 
        {
            return null;
        }
    }
}
