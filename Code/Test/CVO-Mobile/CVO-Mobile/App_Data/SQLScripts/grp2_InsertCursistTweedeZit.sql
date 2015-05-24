--Mohamed Amajoutt
--22/05/2015
 
 
--Stored procedure insert voor de tabel grp2_TweedeZitInschrijving
--Cursist inschrijven voor 2de zit
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_InsertCursistTweedeZit' AND type = 'P') -- P = procedure
begin
	drop proc grp2_InsertCursistTweedeZit
end
go
 
-- aanmaken van de procedure
create procedure grp2_InsertCursistTweedeZit
(
	@CursistNummer int,
	@Grp2_IdTweedeZit int,
	@Reservatiedatum datetime,
	-- out omdat de waarde naar de calling
	-- programma geretourneerd moet worden
	@Id int out
)
as
begin
declare @CurrentId int
--omzetten van cursistnummer naar idCursist
declare @CursistId int
select @CursistId = Id from Cursist where CursistNummer = @CursistNummer
--check doen of cursist al ingeschreven is voor 2de zit
select @CurrentId = Id from grp2_TweedeZitInschrijving where IdCursist = @CursistId and Grp2_IdTweedeZit = @Grp2_IdTweedeZit

if @CurrentId is not null
begin 
	--cursist is al ingeschreven voor deze tweedezit
	set @Id = -100
	return
end
 
--Cursist is nog niet ingeschreven voor tweedezit
insert into grp2_TweedeZitInschrijving
(
	Reservatiedatum,
	IdCursist,
	Grp2_IdTweedeZit
)
values
(
	@Reservatiedatum,
	@CursistId,
	@Grp2_IdTweedeZit
)
 
-- Retourneert de Id van de nieuw toegevoegde rij.
set @Id = SCOPE_IDENTITY()
return
end
 
 
