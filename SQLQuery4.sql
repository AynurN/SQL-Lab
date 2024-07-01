create database AcademyData
use AcademyData
create table Academies(
Id int identity primary key,
Name nvarchar(50)
)
create table Groups(
Id int identity primary key,
Name nvarchar(50),
AcademyId int foreign key references Academies(Id),
)
create table Students (
Id int identity primary key,
Name nvarchar(50),
Surname nvarchar(70),
 Age int,
Adulthood bit,
GroupId int foreign key references Groups(Id)
)
create table DeletedStudents(
Id int identity primary key,
Name nvarchar(50),
Surname nvarchar(70),
GroupId int
)
create table DeletedGroups(
Id int identity primary key,
Name nvarchar(50),
AcademyId int
)
alter table Students
add isDeleted bit

create view Academy_Data as
select * from Academies
create view Group_Data as
select * from Groups
create view Student_Data as
select * from Students


create procedure USP_Bring_Group_By_Name @name nvarchar(50)
as
select * from Groups
where Name=@name

create procedure USP_Brig_Students_Older @age int
as
select * from Students
where Age>@age

create procedure USP_Brig_Students_Younger @age int
as
select * from Students
where Age<@age

drop trigger TR_Check_Before_Insert
create trigger TR_Check_Before_Insert on Students
after insert
as
begin 
  update Students
  set Adulthood= case when Age>=18 then 1 else 0 end
end


create trigger  TR_Add_Deleted_Students on Students
after delete
as
begin 
 insert into DeletedStudents
 select Name, Surname, GroupId from deleted
end

create trigger  TR_Add_Deleted_Groups on Groups
after delete
as
begin 
 insert into DeletedGroups
 select Name,AcademyId from deleted
end
 
drop  trigger TR_IDeleted_Students 
create  trigger TR_IDeleted_Students on Students
instead of delete
as
begin
 update Students
 set isDeleted=1
 where id= (select id from deleted)
end
drop  trigger TR_Change_Age_Students
create trigger TR_Change_Age_Students on Students
instead of update 
as
begin
 update Students
  set Adulthood= case when Age>=18 then 1 else 0 end
end
delete from Students
insert into Students
values 
('Aynur', 'Nazarfli', 16, 1, 1, 0)