--Mohamed Amajoutt
--10/05/2015
 
 
--Stored procedure insert voor de tabel grp2_EvenementInschrijving
--Cursist inschrijven voor evenement
use Administratix_cursist
go
 
if exists (select 1 from sysobjects where name = 'grp2_InsertCursistEvenement' AND type = 'P') -- P = procedure
begin
	drop proc grp2_InsertCursistEvenement
end
go
 
-- aanmaken van de procedure
create procedure grp2_InsertCursistEvenement
(
	@Reservatiedatum datetime,
	@IdCursist int,
	@IdEvenement int,
	@Opmerkingen nvarchar(255),
	-- out omdat de waarde naar de calling
	-- programma geretourneerd moet worden
	@Id int out
)
as
 
declare @CurrentId int
select @CurrentId = Id from grp2_EvenementInschrijving where IdCursist = @IdCursist and IdEvenement = @IdEvenement
 
if @CurrentId is not null
begin 
	--cursist is al ingeschreven voor evenement
	set @Id = -100
	return
end
 
--Cursist is nog niet ingeschreven voor evenement
insert into grp2_EvenementInschrijving
(
	Reservatiedatum,
	IdCursist,
	IdEvenement,
	Opmerkingen
)
values
(
	@Reservatiedatum,
	@IdCursist,
	@IdEvenement,
	@Opmerkingen
)
 
-- Retourneert de Id van de nieuw toegevoegde rij.
set @Id = SCOPE_IDENTITY()
return
 
 
 
