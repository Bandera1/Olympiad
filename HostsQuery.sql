SELECT TOP 1 Countries.Name as 'Country',Count(*) as 'Count'
FROM OlympResults
inner join People on People.ID = OlympResults.PersonID
inner join Countries on Countries.ID = People.CountryID
Group by Countries.Name
Order by Count(*) desc


SELECT * FROM SportTypes