create database DemoApp
create table Countries(
Id int identity primary key,
Name nvarchar(100),
Area decimal(18,2)
)
create table Cities(
Id int identity primary key,
Name nvarchar(100),
Area decimal(18,2),
CountryId int foreign key references Countries(Id)
)
create table People
(Id int identity primary key,
Name nvarchar(50),
Surname nvarchar(50),
PhoneNumber nvarchar(100),
Email nvarchar(100),
Age int,
Gender nvarchar(10),
HasCitizenShip bit not null,
CityId int foreign key references Cities(Id)
)

create view Person_City_Country as
select P.Name, P.Age,P.Gender,P.Email,P.PhoneNumber, P.HasCitizenShip, C.Name as 'City Name', CT.Name as 'Country Name' from People as P
join Cities as C
on P.CityId=C.Id
join Countries as CT
on C.CountryId=CT.Id

alter table People
drop column Gender
alter table People
add
Gender char check(Gender='M' or Gender= 'F')

alter table People
drop column PhoneNumber

alter table People
add
PhoneNumber nvarchar(100) default('**************')

select * from Countries
order by Area
select * from People
order by Name

select count(*) as 'Count' from Countries as  C
where C.Area>20.0000

select count(*) as 'Count' from Countries as  C
where C.name like 'A%'

select C.Id, C.Name, C.Area from Countries as C
union
select CT.Id,CT.Name, CT.Area from Cities as CT


SELECT C.Name, Count(*)
FROM People as P
join Cities as C
on P.CityId=C.Id
GROUP BY C.Name

SELECT C.Name, Count(*)
FROM Cities as C
join People as P
on P.CityId=C.Id
GROUP BY C.Name
having count(*)>=1
