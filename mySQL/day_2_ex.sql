#exercise 3#
insert into rate values ('10',1,1);
insert into rate values ('9',2,1);
insert into rate values ('8',3,1);
insert into rate values ('7',4,1);

insert into rate values ('6',1,2);
insert into rate values ('5',2,2);
insert into rate values ('7',3,2);
insert into rate values ('4',4,2);

#exercise 4#
Select * from students where Stid in (select stid from rate) 

#exercise 5#
select * from students inner join rate on students.Stid=rate.stid

#exercise 6#
select avg(rates) from rate group by stid

#exercise 7#
Select Fname,Lname from students where Stid in (select stid from rate group by stid having avg(rates)>=5)

#exercise 8#
select avg(rates) from rate group by `course id`

#exercise 9#
Select * from students inner join rate on students.Stid=rate.stid 
inner join courses on rate.`course id`=courses.`course id` 
where courses.name="SQL"

#exercise 10#
Select * from students inner join rate on students.Stid=rate.stid 
inner join courses on rate.`course id`=courses.`course id` 
where courses.name="SQL" having max(rates)>=5




