-- 16/05/2015
-- Vanden Broek Nikos
 
-- stored procedure Cursist Email
-- Geeft het email van een crusist terug adhv zijn cursistnummer (nodig voor moodle deadlines)
 
use Administratix_cursist 
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectCursistEmailByCursistNummer' AND type = 'P') -- P = procedure
 
begin
	drop proc grp2_SelectCursistEmailByCursistNummer
end
go
 
create procedure grp2_SelectCursistEmailByCursistNummer
(
	@CursistNummer int
)
 
as
 
begin
 
select Email from Cursist
where Cursist.Cursistnummer = @CursistNummer
end
