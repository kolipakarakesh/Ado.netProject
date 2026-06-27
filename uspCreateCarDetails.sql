create procedure spInsertDetailsOfCar
(
@carname nvarchar(99),@brand nvarchar(99),@model nvarchar(99),@varient nvarchar(99),@fueltype nvarchar(99),@transmission nvarchar(99),
@seatingcapacity int,@enginecc int,@mileage decimal,@color nvarchar(33),@price decimal,@manufactureryear int
)
as
begin 
insert into Car
(
 CarName,Brand,Model,Variant,FuelType,Transmission,SeatingCapacity,EngineCC,Mileage,Color,Price,ManufacturerYear
)
values
(
 @carname,@brand,@model,@varient,@fueltype,@transmission,@seatingcapacity,@enginecc,@mileage,@color,@price,@manufactureryear
)
end