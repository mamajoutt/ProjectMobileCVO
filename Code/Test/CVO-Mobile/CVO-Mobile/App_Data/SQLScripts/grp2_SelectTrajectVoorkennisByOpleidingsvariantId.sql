-- 15/05/2015
-- Vanden Broek Nikos
 
-- stored procedure trajectvoorkennis
-- Geeft een lijst terug met alle modules in een traject waar een cursist is ingeschreven
 
use Administratix_cursist 
go
 
if exists (select 1 from sysobjects where name = 'grp2_SelectTrajectVoorkennisByOpleidingsvariantId' AND type = 'P') -- P = procedure
 
begin
	drop proc grp2_SelectTrajectVoorkennisByOpleidingsvariantId
end
go
 
create procedure grp2_SelectTrajectVoorkennisByOpleidingsvariantId
(
	@OpleidingsvariantId int
)
 
as
 
 
begin
 
select 
	ModulevariantId
	,VoorkennisModulevariantId
from ModulevariantTrajectVoorkennis
where OpleidingsvariantId = @OpleidingsvariantId
 
end
