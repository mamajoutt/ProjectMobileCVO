--author Nikos
--updated SVR 3/05/2015
 
--stored procedure
--resultaten overzicht
 
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectAllResultatenByCursistNummer' AND type = 'P') -- P = procedure 
begin
	drop proc grp2_SelectAllResultatenByCursistNummer
end
go
 
create procedure grp2_SelectAllResultatenByCursistNummer
(
	@CursistNummer int
)
 
as 
begin
 
select 
	IngerichteModulevariant.Id
	,IngerichteModulevariant.CursusNummer as Cursusnummer
	,IngerichteModulevariant.Naam as Module
	,Convert(nvarchar, AanvangsDatum, 5) as AanvangsDatum
	,Convert(nvarchar, EindDatum, 5) as EindDatum
	,PlaatsingResultaat.PuntenTotaal
	,PlaatsingResultaat.PuntenPermanenteEvaluatie
	,PlaatsingResultaat.PuntenEersteZit
	,PlaatsingResultaat.PuntenTweedeZit
from IngerichteModulevariant
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id
left join PlaatsingResultaat on Plaatsing.IdPlaatsingResultaat = PlaatsingResultaat.Id
inner join Cursist on Plaatsing.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer
order by IngerichteModulevariant.CursusNummer 
end
