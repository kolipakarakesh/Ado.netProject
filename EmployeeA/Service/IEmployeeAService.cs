using EmployeeA.Model;
namespace EmployeeA.Service
{
    public interface IEmployeeAService
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee>GetEmployeeById(int id);
        Task<bool>InsertEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
