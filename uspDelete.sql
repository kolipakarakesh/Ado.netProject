create procedure spdelete
@id int
as
begin
delete from EmployeeA where Id=@id
end