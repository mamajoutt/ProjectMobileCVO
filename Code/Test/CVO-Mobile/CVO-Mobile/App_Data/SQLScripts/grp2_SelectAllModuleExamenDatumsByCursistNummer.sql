--author SVR 3/05/2015
--updated JR on 8/05/2015
--updated MA on 27/05/2015
 
--stored procedure  (SP)
--SP overzicht examen/deliberatie/2dezit datums adhv ingegeven cursistnummer

use Administratix_cursist  
go 

if exists (select 1 from sysobjects where name = 'grp2_SelectAllModuleExamenDatumsByCursistNummer' AND type = 'P') -- P = procedure 
begin 
	drop proc grp2_SelectAllModuleExamenDatumsByCursistNummer
end 
go 

create procedure grp2_SelectAllModuleExamenDatumsByCursistNummer
( 
	@CursistNummer int
)
 
as 
begin 
 
select  
CursusNummer
,AanvangsDatum
,EindDatum
,Naam
,ExamenDatum
,DeliberatieDatum 
,DatumTweedeZit
from IngerichteModulevariant 
inner join Plaatsing on Plaatsing.IdIngerichteModulevariant = IngerichteModulevariant.id 
inner join Cursist on Plaatsing.IdCursist = Cursist.Id 
where Cursist.CursistNummer = @CursistNummer 
order by EindDatum, ExamenDatum

end