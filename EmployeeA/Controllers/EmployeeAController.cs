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
        public async Task<IActionResult> GetAllEmployee()
        {
            return null;
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetEmployeeById(int id) 
        {
            return null;
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
