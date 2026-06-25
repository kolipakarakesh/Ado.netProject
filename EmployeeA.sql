create table EmployeeA
(
 Id int primary key identity(101,1),
 Name nvarchar(33) not null,
 Address nvarchar(99) null,
 CreatedBy nvarchar(22) default 'System',
 CreatedOn datetime default getdate(),
 ModifiedBy nvarchar(22) default 'System',
 ModifiedOn datetime default getdate(),
 IsActive bit default 1
)