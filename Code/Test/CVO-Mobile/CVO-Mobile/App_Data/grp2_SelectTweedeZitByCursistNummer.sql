--author SVR 3/05/2015
--updated JR on 9/05/2015
 
--stored procedure
--TweedeZit opvragen
 
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectTweedeZitByCursistNummer' AND type = 'P') -- P = procedure
begin
	drop proc grp2_SelectTweedeZitByCursistNummer
end
go
 
create procedure grp2_SelectTweedeZitByCursistNummer
(
@CursistNummer int
)
 
as
begin 
 
select 
Datum as Datum,
IngerichteModulevariant.Naam as Module,
StartUur as Van,
EindUur as Tot,
Lokaal.naam as Lokaal,
PlaatsingResultaat.PuntenTotaal as Punten,
Ingeschreven
from TweedeZit
inner join PlaatsingResultaat as PlaatsingResultaat on PlaatsingResultaat.IdTweedeZit = TweedeZit.Id
inner join Plaatsing as Plaatsing on Plaatsing.IdPlaatsingResultaat = PlaatsingResultaat.Id
inner join Cursist as Cursist on Plaatsing.IdCursist = Cursist.Id
inner join IngerichteModulevariant as IngerichteModulevariant on IngerichteModuleVariant.Id = plaatsing.IdIngerichteModuleVariant
inner join Lokaal as Lokaal on Lokaal.Id = TweedeZit.IdLokaal
where Cursist.CursistNummer = @CursistNummer
end