using EmployeeA.Model;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeA.Service
{
    public class CarService : ICarService
    {
        private readonly string connectionString;
        public CarService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> DeleteCarDetailsAsync(int CarId)
        {
            if (CarId != 0)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spDeleteDetailsOfCar]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("id", CarId);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            List<Car> cars = new List<Car>();
            Car car = null;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetallCars]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    car = new Car();
                    car.CarId = Convert.ToInt32(item["CarId"]);
                    car.CarName = item["CarName"].ToString();
                    car.Brand = item["Brand"].ToString();
                    car.Model = item["Model"].ToString();
                    car.Variant = item["Variant"].ToString();
                    car.FuelType = item["FuelType"].ToString();
                    car.Transmission = item["Transmission"].ToString();
                    car.SeatingCapacity = Convert.ToInt32(item["SeatingCapacity"]);
                    car.EngineCC = Convert.ToInt32(item["EngineCC"]);
                    car.Mileage = Convert.ToDecimal(item["Mileage"]);
                    car.Color = item["Color"].ToString();
                    car.Price = Convert.ToDecimal(item["Price"]);
                    car.ManufacturerYear = Convert.ToInt32(item["ManufacturerYear"]);
                    car.CreatedBy = item["CreatedBy"].ToString();
                    car.CreatedOn = Convert.ToDateTime(item["CreatedOn"]);
                    car.ModifiedBy = item["ModifiedBy"].ToString();
                    car.ModifiedOn = Convert.ToDateTime(item["ModifiedOn"]);
                    car.IsAvailable = Convert.ToBoolean(item["IsAvailable"]);
                    cars.Add(car);

                }

            }
            return cars;

        }
      
        public async Task<Car> GetCarDetailsByIdAsync(int CarId)
        {
            Car car = null;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("[dbo].[spgetCarDetailsById]", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", CarId);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt=new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    car = new Car();
                    car.CarId = Convert.ToInt32(item["CarId"]);
                    car.CarName = item["CarName"].ToString();
                    car.Brand = item["Brand"].ToString();
                    car.Model = item["Model"].ToString();
                    car.Variant = item["Variant"].ToString();
                    car.FuelType = item["FuelType"].ToString();
                    car.Transmission = item["Transmission"].ToString();
                    car.SeatingCapacity = Convert.ToInt32(item["SeatingCapacity"]);
                    car.EngineCC = Convert.ToInt32(item["EngineCC"]);
                    car.Mileage = Convert.ToDecimal(item["Mileage"]);
                    car.Color = item["Color"].ToString();
                    car.Price = Convert.ToDecimal(item["Price"]);
                    car.ManufacturerYear = Convert.ToInt32(item["ManufacturerYear"]);
                    car.CreatedBy = item["CreatedBy"].ToString();
                    car.CreatedOn = Convert.ToDateTime(item["CreatedOn"]);
                    car.ModifiedBy = item["ModifiedBy"].ToString();
                    car.ModifiedOn = Convert.ToDateTime(item["ModifiedOn"]);
                    car.IsAvailable = Convert.ToBoolean(item["IsAvailable"]);
                    
                }
            }
            return car;
        }

        public async Task<bool> InsertCarDetailsAsync(Car car)
        {
            if (car != null)
            {
              SqlConnection connection=new SqlConnection(connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spInsertDetailsOfCar]", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@carname",car.CarName);
                sqlCommand.Parameters.AddWithValue("@brand", car.Brand);
                sqlCommand.Parameters.AddWithValue("@model", car.Model);
                sqlCommand.Parameters.AddWithValue("@varient", car.Variant);
                sqlCommand.Parameters.AddWithValue("@fueltype", car.FuelType);
                sqlCommand.Parameters.AddWithValue("@transmission", car.Transmission);
                sqlCommand.Parameters.AddWithValue("@seatingcapacity", car.SeatingCapacity);
                sqlCommand.Parameters.AddWithValue("@enginecc", car.EngineCC);
                sqlCommand.Parameters.AddWithValue("@mileage", car.Mileage);
                sqlCommand.Parameters.AddWithValue("@color", car.Color);
                sqlCommand.Parameters.AddWithValue("@price", car.Price);
                sqlCommand.Parameters.AddWithValue("@manufactureryear", car.ManufacturerYear);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
       
        public async Task<bool> UpdateCarDetailsAsync(Car car)
        {
            if (car != null)
            {
                SqlConnection con=new SqlConnection(connectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[spUpdateDetailsOfCar]", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", car.CarId);
                sqlCommand.Parameters.AddWithValue("@carname", car.CarName);
                sqlCommand.Parameters.AddWithValue("@brand", car.Brand);
                sqlCommand.Parameters.AddWithValue("@model", car.Model);
                sqlCommand.Parameters.AddWithValue("@varient", car.Variant);
                sqlCommand.Parameters.AddWithValue("@fueltype", car.FuelType);
                sqlCommand.Parameters.AddWithValue("@transmission", car.Transmission);
                sqlCommand.Parameters.AddWithValue("@seatingcapacity", car.SeatingCapacity);
                sqlCommand.Parameters.AddWithValue("@enginecc", car.EngineCC);
                sqlCommand.Parameters.AddWithValue("@mileage", car.Mileage);
                sqlCommand.Parameters.AddWithValue("@color", car.Color);
                sqlCommand.Parameters.AddWithValue("@price", car.Price);
                sqlCommand.Parameters.AddWithValue("@manufactureryear", car.ManufacturerYear);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                return true;
            }
            return false;
        }
        
    }
}
