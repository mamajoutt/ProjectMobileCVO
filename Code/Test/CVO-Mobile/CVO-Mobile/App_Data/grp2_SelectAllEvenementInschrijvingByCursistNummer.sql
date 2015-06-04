-- Mohamed Amajoutt
-- 26/05/2015

--SP toont persoonlijke lijst voor welke evenementen u bent ingeschreven adhv het cursistnummer

use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'grp2_SelectAllEvenementInschrijvingByCursistNummer' AND type = 'P') -- P = procedure

begin
	drop proc grp2_SelectAllEvenementInschrijvingByCursistNummer
end
go

create procedure grp2_SelectAllEvenementInschrijvingByCursistNummer
(
	@CursistNummer int
)
as
begin
select 
	Reservatiedatum
	, Evenement.Naam as Naam
	, Evenement.Datum as Datum
	, Evenement.Locatie as Locatie
	, Evenement.StartUur as StartUur
	, Evenement.EindUur as EindUur
	, Opmerkingen
from grp2_EvenementInschrijving
inner join Evenement on grp2_EvenementInschrijving.IdEvenement = Evenement.Id
inner join Cursist on grp2_EvenementInschrijving.IdCursist = Cursist.Id
where Cursist.CursistNummer = @CursistNummer and Evenement.Datum >= GETDATE()
order by Evenement.Datum, Evenement.StartUur
end