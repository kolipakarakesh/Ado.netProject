create procedure spgetempbyidRead
@id int
as
begin
select * from EmployeeA where Id=@id;
end
