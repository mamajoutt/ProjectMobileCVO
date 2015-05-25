--author Nikos
--updated SVR 3/05/2015
--updated Mohamed Amajoutt 24/05/2015
 
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
	IngerichteModulevariant.Id as Id
	,IngerichteModulevariant.CursusNummer as Cursusnummer
	,IngerichteModulevariant.Naam as Module
	,Convert(nvarchar, AanvangsDatum, 5) as AanvangsDatum
	,Convert(nvarchar, EindDatum, 5) as EindDatum
	,PlaatsingResultaat.PuntenTotaal as PuntenTotaal
	,PlaatsingResultaat.PuntenPermanenteEvaluatie as PuntenPermanenteEvaluatie
	,PlaatsingResultaat.PuntenEersteZit as PuntenEersteZit
	,PlaatsingResultaat.grp2_IdTweedeZit as grp2_IdTweedeZit
	,PlaatsingResultaat.PuntenTweedeZit as PuntenTweedeZit
	,PlaatsingResultaat.OpmerkingNaDeliberatieEersteZit as OpmerkingNaDeliberatieEersteZit
from IngerichteModulevariant
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id
left join PlaatsingResultaat on Plaatsing.IdPlaatsingResultaat = PlaatsingResultaat.Id
inner join Cursist on Plaatsing.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer
order by IngerichteModulevariant.EindDatum
end
