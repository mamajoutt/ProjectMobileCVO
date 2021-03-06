--Mohamed Amajooutt
--10/05/2015
--Lijst geven van alle evenementen vanaf huidige datum gesorteerd op datum
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectAllEvenement' AND type = 'P') -- P = procedure
 
begin
	drop proc grp2_SelectAllEvenement
end
go
 
create procedure grp2_SelectAllEvenement
as
begin
select 
	Id
	,Naam
	,Evenement.Datum as Datum
	,Locatie
	,Evenement.StartUur as StartUur
	,Evenement.EindUur as EindUur
	from Evenement where Evenement.Datum >= GETDATE() 
	order by StartUur

end