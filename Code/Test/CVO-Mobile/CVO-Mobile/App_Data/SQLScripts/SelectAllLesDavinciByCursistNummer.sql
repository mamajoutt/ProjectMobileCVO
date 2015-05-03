-- Mohamed Amajoutt
-- 27/04/2015

use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'SelectAllLesDavinciByCursistNummer' AND type = 'P') -- P = procedure

begin
	drop proc SelectAllLesDavinciByCursistNummer
end
go

create procedure SelectAllLesDavinciByCursistNummer
(
	@CursistNummer int
)

as

begin
select 
	IngerichteModulevariant.CursusNummer as Cursusnummer
	,CONVERT(nvarchar,Datename(dw,LesDavinci.Lesdatum)) as Dag
	,Convert(nvarchar, LesDavinci.Lesdatum, 5) as Datum
	,LesDavinci.IdPersoneel
	,Personeel.Naam + ' ' + Personeel.Voornaam as Docent
	,LesDavinci.IdLesplaats
	,Lesplaats.Naam as Campus
	,IdLokaal
	,LesDavinci.LocatieOmschrijving as Lokaal
	,LesDavinci.IdIngerichteModulevariant
	,IngerichteModulevariant.Naam as Module
	,Convert(nvarchar(5), LesDavinci.Aanvangsdatum, 108) as Van
	,Convert(nvarchar(5), LesDavinci.Einddatum, 108) as Tot
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