--Mohamed Amajooutt
--17/05/2015

--Lijst geven van alle feestdagen vanaf huidige datum gesorteerd op datum
use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'grp2_SelectFeestdagenVersieMo' AND type = 'P') -- P = procedure

begin
	drop proc grp2_SelectFeestdagenVersieMo
end
go

create procedure grp2_SelectFeestdagenVersieMo
as
begin
select 
	Kalender.Id
	,Schooljaar.Omschrijving as Schooljaar
	,Kalender.Datum as Datum
	,Kalender.Omschrijving as Omschrijving
	from Kalender
	inner join Schooljaar on Kalender.IdSchooljaar = Schooljaar.Id
	where Kalender.Datum >=GETDATE() 
	order by Kalender.Datum 
end