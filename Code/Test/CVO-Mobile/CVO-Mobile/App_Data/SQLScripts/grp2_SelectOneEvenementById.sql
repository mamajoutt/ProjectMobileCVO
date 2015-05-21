-- Mohamed Amajoutt
-- 17/05/2015

use Administratix_cursist
go

if exists (select 1 from sysobjects where name = 'grp2_SelectOneEvenementById' AND type = 'P') -- P = procedure

begin
	drop proc grp2_SelectOneEvenementById
end
go

create procedure grp2_SelectOneEvenementById
(
	@Id int
)

as

begin
select
	Id
	,Naam
	,CONVERT(nvarchar, Evenement.Datum, 5) as Datum
	,Locatie
	,CONVERT(nvarchar(5), Evenement.StartUur, 108) as StartUur
	,CONVERT(nvarchar(5), Evenement.EindUur, 108) as EindUur
	from Evenement where Id = @Id
end