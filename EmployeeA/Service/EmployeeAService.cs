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

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id != 0)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spdelete]", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                return true;
            }
            return false;
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> getallemployees = new List<Employee>();
            Employee getemployee = null;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetallRead]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count > 0)
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
            Employee employee = null;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetempbyidRead]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    employee = new Employee();
                    employee.Id = Convert.ToInt32(item["id"]);
                    employee.Name = item["Name"].ToString();
                    employee.Address = item["Address"].ToString();
                    employee.CreatedBy = item["CreatedBy"].ToString();
                    employee.ModifiedBy = item["ModifiedBy"].ToString();
                    employee.CreatedOn = Convert.ToDateTime(item["CreatedOn"]);
                    employee.ModifiedOn = Convert.ToDateTime(item["ModifiedOn"]);
                    employee.IsActive = Convert.ToBoolean(item["IsActive"]);
                }

            }
            return Task.FromResult(employee);
        }

        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spinsertcreate]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@address", employee.Address);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spupdateemployeea]", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@address", employee.Address);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            return false;
        }
    }
}
