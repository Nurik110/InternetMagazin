create database Nurik_102;
USE Nurik_102;--drop table KazakhBest
create table category( 
	id int primary key identity(1,1),
	name_product nvarchar(50)
)
insert into category values('smartphones_gadgets');
insert into category values('laptops_computers');
insert into category values('appliances');

create table KazakhBest(
	id_product int primary key identity(1,1),
	name nvarchar(50),
	name_product nvarchar(50),
	salary bigint,
	photo text,
	category_id integer not null, 
	foreign key (category_id) references category(id)
)
create table History(
	id int primary key identity(1,1),
	id_product int,
    operation nvarchar(50),
    createat datetime not null default getdate()
)
create trigger KazakhBest_insert
on KazakhBest
after insert
as
insert into History( id_product , operation)
select id_product, 'Добавлен товар ' + name 
from inserted

create trigger KazakhBest_delete
on KazakhBest
after delete
as
insert into History(id_product, operation)
select id_product, 'Удален товар ' + name
from deleted

create trigger KazakhBest_update
on KazakhBest
after update
as
insert into History(id_product, operation)
select id_product, 'Обновлен товар ' + name
from inserted
select * from History
select * from KazakhBest

insert into KazakhBest values('Smartphones','Samsung Galaxy S20 Plus', 447900, 'https://static.shop.kz/upload/iblock/66a/145276_1.jpg', 1); --, 447900
insert into KazakhBest values('Freezers','Skyworth BD-400', 169990, 'https://static.shop.kz/upload/iblock/f16/148591_1.JPG', 3 ); --, 169990
insert into KazakhBest values('Push-button telephone','Nokia 230 DS', 28400, 'https://static.shop.kz/upload/iblock/5e4/142306_7.jpg', 1 ); --, 28400
insert into KazakhBest values('Tablets','Apple iPad Pro A2229', 894900, 'https://static.shop.kz/upload/iblock/00f/150481_1.jpg', 1 ); --, 894900
insert into KazakhBest values('Smart watch','Apple Watch Series 6', 249900, 'https://static.shop.kz/upload/iblock/efd/134802_1_1.jpg', 1); --, 249900
insert into KazakhBest values('Refrigerators','SHARP SJXE55PMBE', 499990, 'https://static.shop.kz/upload/iblock/6ea/147135_01.jpg', 3); --, 499990
insert into KazakhBest values('Laptops','DELL XPS 15', 1790900, 'https://static.shop.kz/upload/iblock/053/151581_1.jpg', 2); --, 1790900
insert into KazakhBest values('Ultrabooks','Lenovo Yoga Slim 9', 969900, 'https://static.shop.kz/upload/iblock/0d2/151859_1.jpg', 2); --, 969900
insert into KazakhBest values('Slabs','Gefest ЭПНД 6140-02 0001', 167990, 'https://static.shop.kz/upload/iblock/c17/315/1.jpg', 3); --, 167990
insert into KazakhBest values('Desktop computers','HP EliteDesk 800 G5 TWR', 399900, 'https://static.shop.kz/upload/iblock/103/143714_1.jpg', 2); --, 399900

insert into KazakhBest values('Smartphones','Xiaomi Redmi Note 9', 89990,'https://static.shop.kz/upload/iblock/600/152089_02.jpg', 1 ); --, 89990 Смартфон
insert into KazakhBest values('Tablets','Apple iPad Pro A2232', 877800, 'https://static.shop.kz/upload/iblock/e3e/151513_1.jpg', 1 ); --, 877800 Планшет 
insert into KazakhBest values('Smartphones','Apple iPhone 11', 387900, 'https://static.shop.kz/upload/iblock/669/152126_1.jpg', 1 ); --, 387900 Смартфон
insert into KazakhBest values('Smart watch','Apple Watch SE', 176900, 'https://static.shop.kz/upload/iblock/0f9/151516_2.jpg', 1 ); --, 176900 Смарт-часы
insert into KazakhBest values('Laptops','HP 15-dw1002ur', 189990, 'https://static.shop.kz/upload/iblock/e1e/152093_1.jpg', 2 ); --, 189990 Ноутбук
insert into KazakhBest values('Smartphones','Samsung Galaxy A12', 68590, 'https://static.shop.kz/upload/iblock/0a9/151871_1.jpg', 1); --, 68590 Смартфон
insert into KazakhBest values('Ultrabooks','HP All-in-One 24-df0033ur', 204100,'https://static.shop.kz/upload/iblock/041/151937_1.jpg', 2); --, 204100 Моноблок
insert into KazakhBest values('Desktop computers','HP ProDesk 600 G5 MT', 385300, 'https://static.shop.kz/upload/iblock/fea/148520_1.jpg', 2); --, 385300 Компьютер
insert into KazakhBest values('Desktop computers','Acer Nitro N50-610', 451100, 'https://static.shop.kz/upload/iblock/4f6/149908_1.jpg', 2); --, 451100 Компьютер
insert into KazakhBest values('Antivirus','Kaspersky 2021', 9890, 'https://static.shop.kz/upload/iblock/97c/151091_1.jpg', 2); --, 9890 Антивирус

insert into KazakhBest values('Antivirus','ESET NOD32', 5990, 'https://static.shop.kz/upload/iblock/040/151099_1.jpg', 2 ); --, 5990 Антивирус
insert into KazakhBest values('Microwaves','Samsung MG23K3575AK/BW', 60800, 'https://static.shop.kz/upload/iblock/098/120888_01.jpg', 3 ); --, 60800 Микроволновка
insert into KazakhBest values('Slabs','Bosch HGA22B120Q', 153700, 'https://static.shop.kz/upload/iblock/1ab/mcsa00946665_1.jpg' , 3 ); --, 153700 плита
insert into KazakhBest values('Refrigerators','Ardesto DNF-M295W188', 149900, 'https://static.shop.kz/upload/iblock/ac1/150116_10.JPG' ,3 ); --, 149900 Холодильник
insert into KazakhBest values('Refrigerators','SHARP SJXE55PMBE', 499990 , 'https://static.shop.kz/upload/iblock/6ea/147135_01.jpg' ,3); --, 499990 Холодильник
insert into KazakhBest values('Freezers','Бирюса 155КХ', 83200, 'https://static.shop.kz/upload/iblock/581/141915_1.jpg', 3); --, 83200 Морозильник


create table Samsung_Galaxy_S20_Plus(	
	id_product int primary key identity(1,1),
	cod_product int,
	KazakhBest_id integer not null, 
	foreign key (KazakhBest_id) references KazakhBest(id_product),
	bought bit default '1'
)
create trigger KazakhBest_Samsung_Galaxy_S20_Plus
on Samsung_Galaxy_S20_Plus
instead of delete
as
update Samsung_Galaxy_S20_Plus
set bought = 0
where id_product = (select id_product from deleted)

declare @cod_random_id1 int, @cod_count_id1 int
set @cod_count_id1 = 50;
set @cod_random_id1 = 12304;
while @cod_count_id1 > 0
	begin 
		insert into Samsung_Galaxy_S20_Plus(cod_product,KazakhBest_id) values(@cod_random_id1, 1)
		set @cod_count_id1 = @cod_count_id1 - 1
		set @cod_random_id1 = FLOOR(RAND()*(1000000-5)+5);
	end;
select Samsung_Galaxy_S20_Plus.id_product, Samsung_Galaxy_S20_Plus.cod_product, KazakhBest.name, Samsung_Galaxy_S20_Plus.bought
from Samsung_Galaxy_S20_Plus
join KazakhBest on KazakhBest.id_product = Samsung_Galaxy_S20_Plus.KazakhBest_id
--SELECT COUNT (bought) as lef_t
--FROM Samsung_Galaxy_S20_Plus
--where bought = '1';
--DELETE FROM Samsung_Galaxy_S20_Plus
--WHERE id_product = 4 ; 
create table Skyworth_BD_400(	
	id_product int primary key identity(1,1),
	cod_product int,
	KazakhBest_id integer not null, 
	foreign key (KazakhBest_id) references KazakhBest(id_product),
	bought bit default '1'
)
create trigger KazakhBest_Skyworth_BD_400
on Skyworth_BD_400
instead of delete
as
update Skyworth_BD_400
set bought = 0
where id_product = (select id_product from deleted)

declare @cod_random_id2 int, @cod_count_id2 int
set @cod_count_id2 = 20;
set @cod_random_id2 = 13134;
while @cod_count_id2 > 0
	begin 
		insert into Skyworth_BD_400(cod_product,KazakhBest_id) values(@cod_random_id2, 2)
		set @cod_count_id2 = @cod_count_id2 - 1
		set @cod_random_id2 = FLOOR(RAND()*(1000000-5)+5);
	end;
select Skyworth_BD_400.id_product, Skyworth_BD_400.cod_product, KazakhBest.name, Skyworth_BD_400.bought
from Skyworth_BD_400
join KazakhBest on KazakhBest.id_product = Skyworth_BD_400.KazakhBest_id
--SELECT COUNT (bought) as lef_t
--FROM Skyworth_BD_400
--where bought = '1';
--DELETE FROM Skyworth_BD_400
--WHERE id_product = 4 ; 
create table Nokia_230_DS(	
	id_product int primary key identity(1,1),
	cod_product int,
	KazakhBest_id integer not null, 
	foreign key (KazakhBest_id) references KazakhBest(id_product),
	bought bit default '1'
)
create trigger KazakhBest_Nokia_230_DS
on Nokia_230_DS
instead of delete
as
update Nokia_230_DS
set bought = 0
where id_product = (select id_product from deleted)

declare @cod_random_id3 int, @cod_count_id3 int
set @cod_count_id3 = 30;
set @cod_random_id3 = 13233;
while @cod_count_id3 > 0
	begin 
		insert into Nokia_230_DS(cod_product,KazakhBest_id) values(@cod_random_id3, 3)
		set @cod_count_id3 = @cod_count_id3 - 1
		set @cod_random_id3 = FLOOR(RAND()*(1000000-5)+5);
	end;
select Nokia_230_DS.id_product, Nokia_230_DS.cod_product, KazakhBest.name, Nokia_230_DS.bought
from Nokia_230_DS
join KazakhBest on KazakhBest.id_product = Nokia_230_DS.KazakhBest_id
--SELECT COUNT (bought) as lef_t
--FROM Nokia_230_DS
--where bought = '1';
--DELETE FROM Nokia_230_DS
--WHERE id_product = 1 ; 
create table Apple_iPad_Pro_A2229(	
	id_product int primary key identity(1,1),
	cod_product int,
	KazakhBest_id integer not null, 
	foreign key (KazakhBest_id) references KazakhBest(id_product),
	bought bit default '1'
)
create trigger KazakhBest_Apple_iPad_Pro_A2229
on Apple_iPad_Pro_A2229
instead of delete
as
update Apple_iPad_Pro_A2229
set bought = 0
where id_product = (select id_product from deleted)

declare @cod_random_id4 int, @cod_count_id4 int
set @cod_count_id4 = 50;
set @cod_random_id4 = 123004;
while @cod_count_id4 > 0
	begin 
		insert into Apple_iPad_Pro_A2229(cod_product,KazakhBest_id) values(@cod_random_id4, 4)
		set @cod_count_id4 = @cod_count_id4 - 1
		set @cod_random_id4 = FLOOR(RAND()*(1000000-5)+5);
	end;
select Apple_iPad_Pro_A2229.id_product, Apple_iPad_Pro_A2229.cod_product, KazakhBest.name, Apple_iPad_Pro_A2229.bought
from Apple_iPad_Pro_A2229
join KazakhBest on KazakhBest.id_product = Apple_iPad_Pro_A2229.KazakhBest_id
--SELECT COUNT (bought) as lef_t
--FROM Apple_iPad_Pro_A2229
--where bought = '1';
--DELETE FROM Apple_iPad_Pro_A2229
--WHERE id_product = 1 ; 
create table Apple_Watch_Series_6(	
	id_product int primary key identity(1,1),
	cod_product int,
	KazakhBest_id integer not null, 
	foreign key (KazakhBest_id) references KazakhBest(id_product),
	bought bit default '1'
)
create trigger KazakhBest_Apple_Watch_Series_6
on Apple_Watch_Series_6
instead of delete
as
update Apple_Watch_Series_6
set bought = 0
where id_product = (select id_product from deleted)

declare @cod_random_id5 int, @cod_count_id5 int
set @cod_count_id5 = 50;
set @cod_random_id5 = 123224;
while @cod_count_id5 > 0
	begin 
		insert into Apple_Watch_Series_6(cod_product,KazakhBest_id) values(@cod_random_id5, 5)
		set @cod_count_id5 = @cod_count_id5 - 1
		set @cod_random_id5 = FLOOR(RAND()*(1000000-5)+5);
	end;
select Apple_Watch_Series_6.id_product, Apple_Watch_Series_6.cod_product, KazakhBest.name, Apple_Watch_Series_6.bought
from Apple_Watch_Series_6
join KazakhBest on KazakhBest.id_product = Apple_Watch_Series_6.KazakhBest_id
--SELECT COUNT (bought) as lef_t
--FROM Apple_Watch_Series_6
--where bought = '1';
--DELETE FROM Apple_Watch_Series_6
--WHERE id_product = 1 ; 
