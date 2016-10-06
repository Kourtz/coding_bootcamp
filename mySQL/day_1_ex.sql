insert into students values (1,'Christos','Kourtzis','1988-04-29');

#exercise 2#
SELECT * from students

#exercise 3#
insert into students values (2,'Christos','Tade','1989-04-29');
insert into students values (3,'Tade2','Tade','1990-04-29');
select distinct Fname from students 

#exercise 4#
insert into courses values (1,'SQL','AG','BN','2','2016-10-21');
insert into courses values (2,'JAVA','VS','BN','3','2016-10-25');
insert into courses values (3,'R','KP','TT','4','2016-11-09');
insert into courses values (4,'PYTHON','KK','DD','5','2016-11-09');

#exercise 5#
select count(*) from students 

#exercise 6#
select count(*) from courses where `duration(days)`>3

#exercise 7#
select * from students where year(curdate())-year(date_b)>17

#exercise 8#
select month(start_date) from courses where courses.name="SQL" 

#exercise 9#
select * from courses where `duration(days)`>2 and  month(start_date)=10

#exercise 10#
select name_of_the_lecturer,sum(`duration(days)`) from courses group by name_of_the_lecturer
select name_of_the_lecturer,sum(`duration(days)`) from courses group by name_of_the_lecturer having sum(`duration(days)`)>2 

#exercise 11#



