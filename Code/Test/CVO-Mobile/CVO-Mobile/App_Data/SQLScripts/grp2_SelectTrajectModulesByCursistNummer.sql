--3/05/2015
--SVR
 
--stored procedure
--module status / inschrijfbaar
 
use Administratix_cursist 
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectTrajectModulesByCursistNummer' AND type = 'P') -- P = procedure
 
begin
	drop proc grp2_SelectTrajectModulesByCursistNummer
	end
go
 
create procedure grp2_SelectTrajectModulesByCursistNummer
(
	@CursistNummer int
)
 
as
 
begin
select
	CursusNummer as Cursusnummer 
	,Naam as Module
	,Convert(nvarchar, AanvangsDatum, 5) as Start
	,MaximumCapaciteit as AantalPlaatsen
	,IsInschrijfbaar as Inschrijfbaar    
from IngerichteModulevariant
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id 
left join PlaatsingResultaat on Plaatsing.IdPlaatsingResultaat = PlaatsingResultaat.Id 
inner join Cursist on Plaatsing.IdCursist = Cursist.Id 
where Cursist.CursistNummer = @CursistNummer
order by Start 
end
