select * from Customers
select * from Orders
select * from Suppliers

Select ContactName,Country from Customers order by ContactName  

Select ContactName,Country from Customers order by Country,ContactName

Select * from orders order by OrderDate 

select count(OrderDate) from Orders where Year(OrderDate)=1997 

select ContactName from Customers where ContactTitle like ('%Manager%')

select * from orders where Year(OrderDate)=1997 and Month(OrderDate)=05 and Day(OrderDate)=19

select * from orders where OrderDate='1997-05-19'