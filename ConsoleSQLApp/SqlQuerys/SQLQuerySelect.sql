declare @currentMoth int
declare @currentDay int
select @currentMoth = DATEPART(MONTH, GETDATE())
select @currentDay = DATEPART(DAY, GETDATE())
select distinct FIO, Birthday, Gender,
DATEDIFF (YEAR, Persons.Birthday, CAST (GETDATE() as date))  - CASE
WHEN ( MONTH(Persons.Birthday) > @currentMoth OR ( MONTH(Persons.Birthday) = @currentMoth AND DAY(Persons.Birthday) > @currentDay))
THEN 1 ELSE 0 END
AS Age
from Persons
order by FIO