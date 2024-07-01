create view Employer_Order_Count as
select E.EmployeeID,( E.FirstName+ E.LastName) as 'Employe fullname',Count(*) as 'Count of Orders'  from  Employees as E
join Orders as O
on E.EmployeeID=O.EmployeeID
group by E.EmployeeID, E.FirstName, E.LastName

select P.ProductName, O.OrderID, (P.Price*O.Quantity) as 'Total Price'from OrderDetails as O
join Products as P
on O.ProductID=P.ProductID


select  O.OrderID, SUM(P.Price*O.Quantity)as 'Total Price' from OrderDetails as O
join Products as P
on O.ProductID=P.ProductID
group by  O.OrderID

select E.EmployeeID,( E.FirstName+' '+ E.LastName) as 'Employe fullname', Sum(P.Price*OD.Quantity) as 'Total Sale Price'  from Employees as E
join Orders as O
on O.EmployeeID=E.EmployeeID
join OrderDetails as OD
on OD.OrderID=O.OrderID
join Products as P
on OD.ProductID=P.ProductID
group by E.EmployeeID,( E.FirstName+' '+ E.LastName)

select top 5 P.ProductName, sum(O.Quantity) from Products as P
join OrderDetails as O
on O.ProductID=P.ProductID
group by P.ProductName
order by sum(O.Quantity) desc

select C.CustomerName, sum(OD.Quantity*P.Price) from Customers as C
join Orders as O
on C.CustomerID=O.CustomerID
join OrderDetails as OD
on O.OrderID=OD.OrderID
join Products as P
on P.ProductID=OD.ProductID
group by C.CustomerName
having sum(OD.Quantity*P.Price)>20000

select C.CustomerName, sum(OD.Quantity) from Customers as C
join Orders as O
on C.CustomerID=O.CustomerID
join OrderDetails as OD
on O.OrderID=OD.OrderID
group by C.CustomerName
having sum(OD.Quantity)>=1


select C.CustomerName from Customers as C
left join Orders as O
on C.CustomerID=O.CustomerID
where O.OrderID is null
