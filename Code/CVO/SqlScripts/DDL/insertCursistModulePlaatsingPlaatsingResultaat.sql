/**Created by Mohamed Amajoutt on 10/04/2015**/

use Administratix_cursist
go

--Cursist toevoegen
insert into Cursist(
CursistNummer,
INSZ,
Geslacht,
Familienaam,
Voornaam,
Straat,
HuisNr,
GeboortePlaats,
IdGeboorteLand,
IdDomicilieLand,
IdPostcode,
IdNationaliteitType,
Email,
GSM,
GeboorteJaar,
GeboorteMaand,
GeboorteDag,
IsBlokkering,
IsAdresOngeldig,
IdWerksituatie,
IdHoogstBehaaldeDiploma,
IsSynchroCursadminix,
IsKBI,
IsGeannuleerd,
UniekPersoonGekoppeld)
values
(
/**CursistNummer**/
43703,
/**Rijksregisternummer**/
'93032722368',
/**Geslacht**/
'M',
/**Familienaam**/
'Amajoutt',
/**Voornaam**/
'Mohamed',
/**Straat**/
'Kapelstraat',
/**Huisnummer**/
'274',
/**GeboortePlaats**/
'Wilrijk',
/**IdGeboorteLand wijzig enkel naam**/
(select Id from Land where Naam = 'België'),
/**IdDomicilieLand wijzig enkel naam**/
(select Id from Land where Naam = 'België'),
/**IdPostcode wijzig enkel gemeente**/
(select Id from Postcode where Gemeente = 'Hoboken'),
/**IdNationaliteitType wijzig enkel omschrijving**/
(select Id from NationaliteitType where Omschrijving = 'België'),
'mo26602011@hotmail.com',
'0485029340',
1993,
3,
27,
/**IsBlokkering**/
0,
/**IsAdresOngeldig**/
0,
/**IdWerkSituatie**/
1,
/**IdHoogstBehaaldeDiploma**/
1,
/**IsSynchroCursadminix**/
0,
/**IsKBI**/
0,
/**IsGeannuleerd**/
0,
/**UniekPersoonGekoppeld**/
0
)




--Module toevoegen
insert into IngerichteModulevariant(
CursusNummer,
AanvangsDatum,
EindDatum,
IdFinancieringsBron,
KostprijsCursusMateriaal,
LestijdenAfstandsonderwijs,
LestijdenDeliberatie,
LestijdenIndividueleArbeidservaring,
MaximumCapaciteit,
PlaatsenVoorDerden,
RegistratieMoment,
IdVerificatieStatus,
VerificatieStatusDatum,
IdModuleVariant,
IdLesPlaats,
IsInschrijfbaar,
IdSchooljaar,
Aanspreekpunt,
IsDavinci,
IsGeannuleerd,
ModifDate,
ModifUser,
IsPlanningVrijgegeven,
IdOpleidingsVerantwoordelijke,
DatumMoodleCSV,
MaxScoreTotaal,
MaxScorePermanenteEvaluatie,
MaxScoreEersteZit,
BeideGeslaagd,
DeliberatieDatum,
DatumTweedeZit,
Naam,
InfoPersoneel,
InfoLokaal,
InfoLessen,
IdOpleidingsvariant,
LestijdenOrganisatie)
values
(
--CursusNummer
'110000',
--AanvangsDatum yyyy-mm--dd
'2015-01-05',
--EindDatum
'2015-06-21',
--IdFinancieringsBron
1,
--KostprijsCursusMateriaal
6,
--LestijdenAfstandsonderwijs
0,
--LestijdenDeliberatie
0,
--LestijdenIndividueleArbeidservaring
0,
--MaximumCapaciteit
20,
--PlaatsenVoorDerden,
0,
--RegistratieMoment yyyy-mm--dd
'2014-09-22',
--IdVerificatieStatus,
4,
--VerificatieStatusDatum,
'2014-10-23',
--IdModuleVariant
(select Id from ModuleVariant where Naam = 'Analyse TV'),
--IdLesPlaats
(select Id from Lesplaats where Straat = 'Distelvinklaan' and Naam='Hoboken'),
--IsInschrijfbaar
1,
--IdSchooljaar
(select Id from Schooljaar where Omschrijving = '2014-2015'),
--Aanspreekpunt,
'Verbesselt Tom',
--IsDavinci,
1,
--IsGeannuleerd,
0,
--ModifDate,
(select GETDATE()),
--ModifUser,
'Mohamed Amajoutt',
--IsPlanningVrijgegeven
1,
--IdOpleidingsVerantwoordelijke
2,
--DatumMoodleCSV yyyy-mm-dd
'2014-07-02',
--MaxScoreTotaal
60,
--MaxScorePermanenteEvaluatie,
18,
--MaxScoreEersteZit,
42,
--BeideGeslaagd
0,
--DeliberatieDatum yyyy-mm--dd
2015-06-29,
--DatumTweedeZit,
'2015-08-28 13:15:00:00',
--Naam
'Analyse TV',
--InfoPersoneel,
'Tom Verbesselt',
--InfoLokaal,
'A19, B10, B11',
--InfoLessen,
'MA NM, WO VM',
--IdOpleidingsvariant
(select Id from Opleidingsvariant where Naam = 'Informatica' and AantalLestijden > 0),
--LestijdenOrganisatie
60
)


--Cursist inschrijven/plaatsen voor module
insert into Plaatsing ( 
IsBetaaldEducatiefVerlof 
,IdPlaatsingsstatus 
,Reservatiedatum 
,IdCursist 
,IdIngerichteModulevariant 
,IdIngerichteOpleidingsvariant 
,IsSynchroCursadminix 
,IsDavinci 
,IsInschrijvingsdatumManueel 
,IsGeannuleerd 
,GevalideerdDoorCentrum 
,GecontroleerdDoorCentrum 
) 
values( 
'0' 
,(select Id from PlaatsingsStatusType where Code = 'INGESCHREVEN') 
,(select GETDATE()) 
,(select Id from Cursist where CursistNummer = '43703') 
,(select Id from IngerichteModulevariant where CursusNummer = '11618') 
,1 
,'1' 
,'1' 
,'0' 
,'0' 
,'1' 
,'1' 
) 
  
go 

--Resultaat ingeven
insert into PlaatsingResultaat ( 
PuntenTotaal,
PuntenPermanenteEvaluatie,
--PuntenPermanenteEvaluatieNaDeliberatie,
PuntenEersteZit
--PuntenEersteZitNaDeliberatie
--PuntenTweedeZit,
--PuntenTweedeZitNaDeliberatie,
--OpmerkingPunten,
--OpmerkingNaDeliberatieEersteZit,
--OpmerkingNaDeliberatieTweedeZit,
--AdviesNaEvaluatie,
--ModifBy,
--ModifDate,
--IdRedenUitstelExamen,
--NietDeelgenomen,
--NietDeelgenomenExamen,
--DatumUitgesteldeProef1,
--DatumUitgesteldeProef2,
--DatumBijkomendeProef,
--PvAfdrukDatum,
--IdEvaluatieResultaatDocent,
--NietDeelgenomenBijkomendeProef,
) 
values( 
'48',
'10',
'38' 
) 
  
go 