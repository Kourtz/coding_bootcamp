---HAVING

--1--
select Orders.OrderID,Employees.LastName from Orders inner join Employees 
on Employees.EmployeeID=Orders.EmployeeID 
where DATEDIFF(DAY,Orders.ShippedDate,Orders.RequiredDate)<0

select Orders.OrderID,Employees.LastName from Orders inner join Employees 
on Employees.EmployeeID=Orders.EmployeeID 
group by Orders.OrderID,Employees.LastName,Employees.EmployeeID,Orders.ShippedDate,Orders.RequiredDate
having DATEDIFF(DAY,Orders.ShippedDate,Orders.RequiredDate)<0

--2--
select Sum([Order Details].Quantity) as Quantity,[Order Details].ProductID from [Order Details]
Group by [Order Details].ProductID
having Sum([Order Details].Quantity)<200 

--3--
select Orders.CustomerID,Count(Orders.OrderDate) as orders from Orders
where YEAR(Orders.OrderDate)>1996
Group by Orders.CustomerID
having Count(Orders.OrderID)>15
order by orders desc


