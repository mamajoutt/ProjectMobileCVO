-- Mohamed Amajoutt
-- 26/05/2015

--SP toont persoonlijke lijst voor welke 2de zit u bent ingeschreven adhv het cursistnummer

use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'grp2_SelectAllTweedeZitInschrijvingByCursistNummer' AND type = 'P') -- P = procedure

begin
	drop proc grp2_SelectAllTweedeZitInschrijvingByCursistNummer
end
go

create procedure grp2_SelectAllTweedeZitInschrijvingByCursistNummer
(
	@CursistNummer int
)
as
begin
select 
	grp2_TweedeZitInschrijving.Reservatiedatum
	,IngerichteModulevariant.CursusNummer as CursusNummer
	,IngerichteModulevariant.Naam as Module
	,grp2_TweedeZit.Datum as Datum
	,grp2_TweedeZit.Datum as StartUur
	,grp2_TweedeZit.EindUur as EindUur
	,Lokaal.Naam as Lokaal
	,grp2_TweedeZit.Opmerkingen as Opmerkingen
from grp2_TweedeZitInschrijving
inner join IngerichteModulevariant on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.Id
inner join grp2_TweedeZit on grp2_TweedeZitInschrijving.IdTweedeZit = grp2_TweedeZit.Id
inner join Lokaal on grp2_TweedeZit.IdLokaal = Lokaal.Id
inner join Cursist on grp2_TweedeZitInschrijving.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer and grp2_TweedeZit.Datum >= GETDATE()
order by grp2_TweedeZit.Datum, grp2_TweedeZit.StartUur
end