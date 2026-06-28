using Microsoft.AspNetCore.Http.HttpResults;
using System.IO.Pipes;

namespace EmployeeA.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; } = string.Empty;
        public string FuelType { get; set; }
        public string Transmission {  get; set; }
        public int SeatingCapacity { get; set; }
        public int EngineCC { get; set; }
        public decimal Mileage { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerYear { get; set; }
        public string CreatedBy { get; set; }= "System";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; }="System";
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public bool IsAvailable { get; set; }=true;
    }
}




