--1--
select Sum([Order Details Extended].ExtendedPrice) from
[Order Details Extended] inner join Orders on Orders.OrderID=[Order Details Extended].OrderID
where Year(Orders.OrderDate)=1997
--each year revenue--
select Sum([Order Details Extended].ExtendedPrice),YEAR(Orders.Orderdate) from
[Order Details Extended] inner join Orders on Orders.OrderID=[Order Details Extended].OrderID
Group by YEAR(Orders.Orderdate)

--2--
Select Sum([Order Details Extended].ExtendedPrice) as total,Orders.CustomerID from
[Order Details Extended] inner join Orders on Orders.OrderID=[Order Details Extended].OrderID
Group by Orders.CustomerID
Order by total desc

--3--
select top 10 Sum(o.ExtendedPrice),o.ProductID,o.ProductName
 from
[Order Details Extended] as o
Group by o.ProductID,o.ProductName
Order by Sum(o.ExtendedPrice) desc
--by quantity--
select top 10 Sum(o.Quantity),o.ProductID,o.ProductName
 from
[Order Details Extended] as o
Group by o.ProductID,o.ProductName
Order by Sum(o.Quantity) desc

--4--
GO
CREATE VIEW Customer_rev AS
select Sum(o.ExtendedPrice) as Rev,Orders.CustomerID  from
[Order Details Extended] as o full join Orders on Orders.OrderID=o.OrderID
Group by orders.CustomerID
go

--5--
select cu.CustomerID,cu.Rev from Customer_rev cu inner join Customers on cu.CustomerID=Customers.CustomerID
where Customers.Country='UK' and cu.Rev>1000
order by cu.rev desc

--6--
select Customers.CustomerID,CompanyName,Country,
ISNULL(Customer_rev.Rev,0) as [Customer's total from all orders],
ISNULL(ord.suma,0)as [Customer's total from 1997 orders]
from Customer_rev full join Customers on Customer_rev.CustomerID=Customers.CustomerID
full join  
    (select Sum([Order Details Extended].ExtendedPrice) suma,Orders.CustomerID from
    [Order Details Extended] inner join Orders on Orders.OrderID=[Order Details Extended].OrderID
    where Year(Orders.OrderDate)=1997
    group by Orders.CustomerID) ord
on ord.CustomerID=Customers.CustomerID

--or by using procedure (if we want to change year)--
go
drop procedure [Total Revenue and by Year]
go
create procedure [Total Revenue and by Year] @Year int as
select Customers.CustomerID,CompanyName,Country,
ISNULL(Rev,0) as [Customer's total from all orders],
ISNULL(ord.suma,0)as [Customer's total from 1997 orders]
from Customer_rev full join Customers on Customer_rev.CustomerID=Customers.CustomerID
full join  
    (select Sum([Order Details Extended].ExtendedPrice) suma,Orders.CustomerID from
    [Order Details Extended] inner join Orders on Orders.OrderID=[Order Details Extended].OrderID
    where Year(Orders.OrderDate) = 1997
    group by Orders.CustomerID) ord
on ord.CustomerID=Customers.CustomerID
go