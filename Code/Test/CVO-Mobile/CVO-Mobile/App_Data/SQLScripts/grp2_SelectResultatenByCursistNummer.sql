--author Nikos
--updated SVR 3/05/2015
 
--stored procedure
--resultaten overzicht
 
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectResultatenByCursistNummer' AND type = 'P') -- P = procedure 
begin
	drop proc grp2_SelectResultatenByCursistNummer
end
go
 
create procedure grp2_SelectResultatenByCursistNummer
(
	@CursistNummer int
)
 
as 
begin
 
select 
	IngerichteModulevariant.CursusNummer as Cursusnummer
	,IngerichteModulevariant.Naam as Module
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
