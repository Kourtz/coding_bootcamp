--JOINS
--1--
select Orders.CustomerID,Orders.OrderID from Orders where Year(OrderDate)=1996  
--or
Select Customers.CustomerID,Orders.OrderID from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID
where Year(OrderDate)=1996 

--2--
Select Employees.City,COUNT(distinct Employees.EmployeeID) as Employees,
COUNT(distinct Customers.CustomerID) as Customers  
from Employees left join Customers on Employees.City = Customers.City
Group by Employees.City

--3--
Select Customers.City,COUNT(distinct Customers.CustomerID) as Employees,
COUNT(distinct Customers.CustomerID) as Customers  
from Customers left join Employees on Employees.City = Customers.City
Group by Customers.City

--4--
Select Employees.City as City_Emp,
Customers.City as City_Cu,
COUNT(distinct Customers.CustomerID) as Customers,
COUNT(distinct Employees.EmployeeID) as Employees
from Customers full join Employees on Employees.City = Customers.City
Group by Customers.City, Employees.City


