use sakila
/* Exercise 1:Create and execute a procedure that displays
the first and the last name from table actors.*/

Create procedure show_name
as
begin 
select first_name,last_name from actor
end

exec show_name

/* Exercise 2:Create a procedure to display everything
 from table actor with id=58*/
Create procedure actor_id @ida int
as
begin
select * from actor where actor_id=@ida
end

exec actor_id 58;

/* Exercise 3:Create a procedure that receives as input a payment amount and a date
and returns those payments (table=payment) that exceed this amount 
for the days after the given day.
Then execute the procedure for amount=1, and date = '2004-05-25 11:30:37‘.*/
create procedure payments_ex @amount decimal, @date date
as begin
select * from payment
where amount>@amount and payment_date>@date
end

exec payments_ex 1,'2004-05-25 11:30:37'


/* Exercise 4:In the previous procedure also count the number of distinct dates
that satisfy the following restriction
(amount=1, and date = '2004-05-25 11:30:37‘).*/
create procedure payments_ex2 @amount decimal, @date date,@num int out
as begin
set @num=(Select Count(*) from payment
where amount>@amount and payment_date>@date)
end

declare @num int
exec payments_ex2 1,'2004-05-25 11:30:37',@num out
select @num 

drop procedure payments_ex2 