using EmployeeA.Model;

namespace EmployeeA.Service
{
    public class EmployeeAService : IEmployeeAService
    {
        public Task<bool> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
