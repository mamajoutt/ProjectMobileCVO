-- Mohamed Amajoutt
-- 27/04/2015

use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'grp2_SelectAllLesDavinciByCursistNummer' AND type = 'P') -- P = procedure

begin
	drop proc grp2_SelectAllLesDavinciByCursistNummer
end
go

create procedure grp2_SelectAllLesDavinciByCursistNummer
(
	@CursistNummer int
)

as
begin
select 
	IngerichteModulevariant.CursusNummer as Cursusnummer
	,LesDavinci.Lesdatum as Datum
	,Personeel.Naam + ' ' + Personeel.Voornaam as Docent
	,Lesplaats.Naam as Campus
	,LesDavinci.LocatieOmschrijving as Lokaal
	,IngerichteModulevariant.Naam as Module
	,LesDavinci.AanvangsDatum as Van
	,LesDavinci.Einddatum as Tot
from LesDavinci 
inner join IngerichteModulevariant on LesDavinci.IdIngerichteModulevariant = IngerichteModulevariant.Id
inner join Lesplaats on LesDavinci.IdLesplaats = LesPlaats.Id
inner join Personeel on IdPersoneel = Personeel.Id
inner join Lokaal on IdLokaal = Lokaal.Id
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id
inner join Cursist on Plaatsing.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer and LesDavinci.Aanvangsdatum >= GETDATE()
order by LesDavinci.Lesdatum, LesDavinci.Aanvangsdatum
end