--author Nikos
--updated SVR 3/05/2015
--updated Mohamed Amajoutt 24/05/2015
 
--stored procedure
--resultaten overzicht
 
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectAllPlaatsingResultaatByCursistNummer' AND type = 'P') -- P = procedure 
begin
	drop proc grp2_SelectAllPlaatsingResultaatByCursistNummer
end
go
 
create procedure grp2_SelectAllPlaatsingResultaatByCursistNummer
(
	@CursistNummer int
)
 
as 
begin
 
select 
	IngerichteModulevariant.Id as IdIngerichteModulevariant
	,IngerichteModulevariant.CursusNummer as Cursusnummer
	,IngerichteModulevariant.Naam as Module
	,PlaatsingResultaat.PuntenTotaal as PuntenTotaal
	,PlaatsingResultaat.PuntenPermanenteEvaluatie as PuntenPermanenteEvaluatie
	,PlaatsingResultaat.PuntenEersteZit as PuntenEersteZit
	,PlaatsingResultaat.OpmerkingNaDeliberatieEersteZit as OpmerkingNaDeliberatieEersteZit
	,PlaatsingResultaat.grp2_IdTweedeZit as IdTweedeZit
	,PlaatsingResultaat.PuntenTweedeZit as PuntenTweedeZit
	,PlaatsingResultaat.OpmerkingNaDeliberatieTweedeZit as OpmerkingNaDeliberatieTweedeZit
from IngerichteModulevariant
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id
left join PlaatsingResultaat on Plaatsing.IdPlaatsingResultaat = PlaatsingResultaat.Id
inner join Cursist on Plaatsing.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer
order by IngerichteModulevariant.EindDatum
end
