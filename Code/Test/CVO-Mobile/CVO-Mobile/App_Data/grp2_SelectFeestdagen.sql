--BP/JR

use Administratix_cursist  
go 
  
if exists (select 1 from sysobjects where name = 'grp2_SelectFeestdagen' AND type = 'P') -- P = procedure 
  
begin 
drop proc grp2_SelectFeestdagen 
end 
go 
  
create procedure grp2_SelectFeestdagen 
( 
@Date1 datetime, 
@Date2 datetime 
 
) 
  
as 
  
begin 
  
select 
 Id, 
 Convert (nvarchar, Kalender.Datum, 5) as Datum,  
 IdSchooljaar,  
 Omschrijving,  
 IdVerlofdagType 
 --from Kalender where Kalender.Datum >= GETDATE() 
 from Kalender where Kalender.Datum <= @Date2 and Kalender.Datum >= @Date1 
 end
