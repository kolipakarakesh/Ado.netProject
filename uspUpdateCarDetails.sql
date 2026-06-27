create procedure spUpdateDetailsOfCar
@id int,@carname nvarchar(99),@brand nvarchar(99),@model nvarchar(99),@varient nvarchar(99),@fueltype nvarchar(99),@transmission nvarchar(99),
@seatingcapacity int,@enginecc int,@mileage decimal,@color nvarchar(33),@price decimal,@manufactureryear int
as
begin 
update Car
set
CarName=@carname,Brand=@brand,Model=@model,Variant=@varient,FuelType=@fueltype,Transmission=@transmission,SeatingCapacity=@seatingcapacity,
EngineCC=@enginecc,Mileage=@mileage,Color=@color,Price=@price,ManufacturerYear=@manufactureryear where CarId=@id
end