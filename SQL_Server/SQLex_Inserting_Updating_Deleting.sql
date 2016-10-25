--Inserting Records
insert into Employees(LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,City,Region,
PostalCode,Country,HomePhone,ReportsTo)
values ('Kourtz','Christos','Super Manager','Mr','1988-04-29','2016-10-25','Athens','Attica',
'14561','Greece','210xxxxxx','1')

select * from Employees 

declare @EmployeeID int = SCOPE_IDENTITY();
insert into Orders(CustomerID,EmployeeID,OrderDate,RequiredDate) values('ANATR',@EmployeeID,'2016-10-25','2016-11-25')

select * from Orders

declare @OrderID int = SCOPE_IDENTITY();
insert into [Order Details](OrderID,ProductID,UnitPrice,Quantity,Discount) values
(@OrderID,3,50.5,3,0.30)

select *from [Order Details]

--Updating Records
BEGIN TRANSACTION

update Employees set HomePhone='697xxxxxxx' where Employees.LastName='Kourtz'

update [Order Details] set Quantity=Quantity*2
from [Order Details] join Orders on [Order Details].OrderID=Orders.OrderID
join Employees on Employees.EmployeeID=Orders.EmployeeID
where Employees.LastName='Kourtz'

--Deleting Records
delete [Order Details]
from [Order Details] join Orders on [Order Details].OrderID=Orders.OrderID
join Employees on Employees.EmployeeID=Orders.EmployeeID
where Employees.LastName='Kourtz'

delete Orders
from Orders
join Employees on Employees.EmployeeID=Orders.EmployeeID
where Employees.LastName='Kourtz'

delete Employees from Employees where Employees.LastName='Kourtz'


select *from Employees

