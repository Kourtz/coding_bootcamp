 use sakila

Create View Actor_Sample as
select actor_id,first_name,last_name from
actor;

select * from [Actor_Sample];

/*Per each customer (id) and for its rentals, 
display the total customer’s rentals per month
as percentage of customer’s yearly rentals*/

Create View V1(customer_id,months,rentals) as
select customer_id,Month(rental_date),Count(rental_date) from 
rental
group by customer_id,MONTH(rental_date)

Create View V2(customer_id,rentals) as
select customer_id,count(rental_date) from
rental
group by customer_id

select V1.customer_id,V1.months,Cast(V1.rentals as float)/Cast(V2.rentals as float) from
 V1 inner join V2 on V1.customer_id=V2.customer_id


 /*Per each customer (first name & last name) and for its payments, 
 display the total customer’s payments per month 
 as percentage of customer’s yearly payments*/

Create View V3(customer_id,months,amount) as
select customer_id,Month(payment_date),SUM(amount) from payment
where Year(payment_date)!=2006
group by customer_id,Month(payment_date)

Create View V4(customer_id,total_amount) as
select customer_id,Sum(amount) from payment
where Year(payment_date)!=2006
group by customer_id,YEAR(payment_date)

Create View V5(customer_id,months,percentage) as
select V3.customer_id,V3.months,(V3.amount/V4.total_amount)*100 as percentage from
V3 inner join V4 on V3.customer_id=V4.customer_id

select customer.last_name,customer.first_name,V5.months as month,V5.percentage from
customer inner join V5 on customer.customer_id=V5.customer_id
order by customer.last_name
