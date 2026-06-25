
create procedure spupdateemployeea
@id int,@name nvarchar(55),@address nvarchar(122)
as
begin
update EmployeeA 
set
Name=@name,
Address=@address
where Id=@id
end