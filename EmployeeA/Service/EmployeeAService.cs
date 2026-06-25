using EmployeeA.Model;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeA.Service
{
    public class EmployeeAService : IEmployeeAService
    {
        private readonly string connectionString;
        public EmployeeAService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> getallemployees=new List<Employee>();
            Employee getemployee=null;
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetallRead]",connection);
            sqlCommand.CommandType= CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(sqlCommand);
            DataTable dt=new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    getemployee = new Employee();
                    getemployee.Id = Convert.ToInt32(item["Id"]);
                    getemployee.Name = item["Name"].ToString();
                    getemployee.Address = item["Address"].ToString();
                    getemployee.CreatedOn = Convert.ToDateTime(item["CreatedOn"]);
                    getemployee.CreatedBy = item["CreatedBy"].ToString();
                    getemployee.ModifiedOn = Convert.ToDateTime(item["ModifiedOn"]);
                    getemployee.ModifiedBy = item["ModifiedBy"].ToString();
                    getemployee.IsActive = Convert.ToBoolean(item["IsActive"]);
                    getallemployees.Add(getemployee);
                }
            }
            return getallemployees;
         }

        public Task<Employee> GetEmployeeById(int id)
        {
            Employee emp = null;
            SqlConnection connection=new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetempbyidRead]", connection);
            sqlCommand.CommandType=CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id",id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt=new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    emp= new Employee();
                    emp.Id = Convert.ToInt32(item["Id"]);
                    emp.Name = item["Name"].ToString();
                    emp.Address = item["Address"].ToString();
                    emp.CreatedOn = Convert.ToDateTime(item["CreatedOn"]);
                    emp.CreatedBy = item["CreatedBy"].ToString();
                    emp.ModifiedOn = Convert.ToDateTime(item["ModifiedOn"]);
                    emp.ModifiedBy = item["ModifiedBy"].ToString();
                    emp.IsActive = Convert.ToBoolean(item["IsActive"]);
                }
            }
            return Task.FromResult(emp);
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
