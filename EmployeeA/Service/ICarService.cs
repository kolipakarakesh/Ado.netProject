using EmployeeA.Model;
namespace EmployeeA.Service
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car>GetCarDetailsByIdAsync(int CarId);
        Task<bool>InsertCarDetailsAsync(Car car);
        Task<bool>UpdateCarDetailsAsync(Car car);
        Task<bool> DeleteCarDetailsAsync(int CarId);
    }
}
