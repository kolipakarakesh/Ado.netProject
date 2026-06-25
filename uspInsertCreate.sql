create procedure spinsertcreate
@name nvarchar(33),
@address nvarchar(99)
as
begin
insert into EmployeeA
(
 Name, Address
)
values(
@name, @address
)
end