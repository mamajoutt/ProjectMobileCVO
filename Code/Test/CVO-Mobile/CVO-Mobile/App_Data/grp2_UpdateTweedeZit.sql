--author Benjamin Peeters

--Cursist inschrijven voor 2dezit
--status veranderen naar ingeschreven

use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_UpdateTweedeZit' AND type = 'P') -- P = procedure
begin
	drop proc grp2_UpdateTweedeZit
end
go
 
create procedure grp2_UpdateTweedeZit
(
@CursistNummer int,
@CursusNummer int
)

as

Begin
 
Update TweedeZit
set Ingeschreven = 1
 
from TweedeZit
inner join PlaatsingResultaat as PlaatsingResultaat on TweedeZit.Id = PlaatsingResultaat.IdTweedeZit
inner join Plaatsing as Plaatsing on PlaatsingResultaat.Id = Plaatsing.IdPlaatsingResultaat
inner join Cursist as Cursist on Cursist.Id = Plaatsing.IdCursist
inner join IngerichteModulevariant as IngerichteModulevariant on IngerichteModuleVariant.Id = plaatsing.IdIngerichteModuleVariant
where Cursist.CursistNummer = @CursistNummer
and 
IngerichteModulevariant.CursusNummer = @CursusNummer
end
 
 
 
