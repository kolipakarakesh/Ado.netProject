create procedure spgetCarDetailsById
@id int
as
begin 
select * from Car where CarId=@id;
end