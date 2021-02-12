create table dress (
	id int primary key identity(1,1),
	name nvarchar(50)
)
create table employes(
	id int primary key identity(1,1),
	name nvarchar(50),
	salary bigint,
	dress_id int not null,
	foreign key (dress_id) references dress(id)
)
create table sale(
	id int primary key identity(1,1),
	quantity int, 
	employes_id int not null,
	foreign key (employes_id) references employes(id),
	dress_id int not null,
	foreign key (dress_id) references dress(id)
)
create table bonus(
	id int primary key identity(1,1),
	quantity int, 
	percents int
)
insert into dress values('A1');
insert into dress values('A2');
insert into dress values('A3');

insert into employes values('Nursultan', 500000,1);
insert into employes values('Rustem', 450000,1);
insert into employes values('Kanat', 300000,2);
insert into employes values('Arup', 350000,2);
insert into employes values('Nikita', 400000,3);
insert into employes values('Ramazan', 420000,3);

insert into sale values(50000,1,1);
insert into sale values(30000,2,1);
insert into sale values(40000,3,2);
insert into sale values(30000,4,2);
insert into sale values(25000,5,3);
insert into sale values(20000,6,3);

insert into bonus values (10, 40000);

select * from employes

declare @percents int, @quantity int
set @percents = 10;
set @quantity = 40000;
if @quantity < (select sum(quantity) from sale where dress_id = 1)
	begin 
		update employes set salary = salary + (salary * @percents)/100 where dress_id = 1;
		select * from employes where dress_id = 1;
	end
if @quantity < (select sum(quantity) from sale where dress_id = 2)
	begin 
		update employes set salary = salary + (salary * @percents)/100 where dress_id = 2;
		select * from employes where dress_id = 2;
	end
if @quantity < (select sum(quantity) from sale where dress_id = 3)
	begin 
		update employes set salary = salary + (salary * @percents)/100 where dress_id = 3;
		select * from employes where dress_id = 3;
	end
else 
	print 'No bonus'
