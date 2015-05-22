--author SVR 3/05/2015
--updated JR on 8/05/2015
 
--stored procedure 
--overzicht examen/deliberatie/2dezit datums

use Administratix_cursist  
go 

if exists (select 1 from sysobjects where name = 'grp2_SelectExDel2deZitDateByCursistNummer' AND type = 'P') -- P = procedure 
begin 
	drop proc grp2_SelectExDel2deZitDateByCursistNummer
end 
go 

create procedure grp2_SelectExDel2deZitDateByCursistNummer
( 
	@CursistNummer int
)
 
as 
begin 
 
select  
CursusNummer as Cursusnummer 
,Naam as Module
,Convert(nvarchar, AanvangsDatum, 5) as AanvangsDatum
,Convert(nvarchar, EindDatum, 5) as EindDatum
,Convert(nvarchar, ExamenDatum, 5) as ExamenDatum
,Convert(nvarchar, DeliberatieDatum, 5) as DeliberatieDatum 
,Convert(nvarchar, DatumTweedeZit, 5) as DatumTweedeZit
from IngerichteModulevariant 
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id 
inner join Cursist on Plaatsing.IdCursist = Cursist.Id 
where Cursist.CursistNummer = @CursistNummer 
order by ExamenDatum

end