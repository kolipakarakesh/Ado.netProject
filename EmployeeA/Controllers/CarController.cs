using EmployeeA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var response = await _carService.GetAllCarsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
                }
            }
        }

        [HttpGet]
        [Route("GetCarDetailsById")]
        public async Task<IActionResult> GetCarDetailsById(int id)
        {
            try
            {
                var res = await _carService.GetCarDetailsByIdAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        [Route("CreateCarDetails")]
        public async Task<IActionResult> CreteCarDetailsAsync(Model.Car car)
        {
            try
            {
                var res = await _carService.InsertCarDetailsAsync(car);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPut]
        [Route("UpdateCarDetails")]
        public async Task<IActionResult> UpdatecarDetails(Model.Car car)
        {
            try
            {
                var response = await _carService.UpdateCarDetailsAsync(car);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete]
        [Route("DeleteCarDetails")]
        public async Task<IActionResult> DeleteCarDetails(int id)
        {
            try
            {
                var res = await _carService.DeleteCarDetailsAsync(id); return Ok(res);
            }
            catch (Exception ex) 
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
