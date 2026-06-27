create procedure spDeleteDetailsOfCar
@id int
as
begin
delete from Car where CarId=@id
end