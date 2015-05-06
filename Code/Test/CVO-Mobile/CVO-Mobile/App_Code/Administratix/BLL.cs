using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administratix.BLL
{
    public class CursusResultaat
    {
        public int CursusNummer { get; set; }
        public string CursusNaam { get; set; }
        public double PuntenTotaal { get; set; }
        public double PuntenPermanenteEvaluatie { get; set; }
        public double PuntenEersteZit { get; set; }
        public double PuntenTweedeZit { get; set; }
    }


    public class TweedezitResultaat
    {
        public string Module { get; set; }
        public DateTime Datum { get; set; }
        public string Lokaal { get; set; }
        public string Van { get; set; }
        public string Tot { get; set; }
    }

    public class StatusTraject
    {
        public int Cursusnummer { get; set; }
        public string Module { get; set; }
        public string Start { get; set; }
        public int AantalPlaatsen { get; set; }
        public bool Inschrijfbaar { get; set; }  
    }

    public class TrajectOverzicht
    {

        public string Code { get; set; }
        public string Module { get; set; }
        public int Lestijden { get; set; }
    }

    public class DelibiratieDate
    {
        public int Cursusnummer { get; set; }
        public string Module { get; set; }
        public DateTime DeliberatieDatum { get; set; }
        public DateTime TweedeZitDatum { get; set; }
    }

    public class Evenement
    {
        public string Evenement { get; set; }
        public DateTime Datum { get; set; }
        public string Locatie { get; set; }
        public string Van { get; set; }
        public string Tot { get; set; }

    }






    /// <summary> 
    /// Class definition Cursist 
    /// </summary> 
    public class Cursist
    {
        public int Id { get; set; }
        public string CursistNummer { get; set; }
        public string Familienaam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
        public string Tel1 { get; set; }

    }

    /// <summary> 
    /// Class definition Docent/Trajectbeg 
    /// </summary> 
    public class Personeel
    {
        public int Id { get; set; }
        public int Personeelnummer { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string UserName { get; set; }
        public string EmailCentrum { get; set; }
        public string Stamboeknummer { get; set; }
        public string Geslacht { get; set; }
        public string GSM { get; set; }
        public string TEL { get; set; }

    }

    /// <summary> 
    /// Class definition Schooljaar 
    /// </summary> 
    public class Schooljaar
    {
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public DateTime AanvangsDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool IsHuidig { get; set; }

    }

    /// <summary> 
    /// Class definition Kalender 
    /// </summary> 
    public class Kalender
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int IdSchooljaar { get; set; }
        public string Omschrijving { get; set; }
        public int IdVerlofdagType { get; set; }

    }


    /// <summary> 
    /// Class definition Module 
    /// </summary> 
    public class Module
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public int Code { get; set; }
        public DateTime Aanvangsdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int IdModuletype { get; set; }


    }

    /// <summary> 
    /// Class definition IngerichteModulevariant 
    /// </summary> 
    public class IngerichteModulevariant
    {
        public int Id { get; set; }
        public string CursusNummer { get; set; }
        public DateTime AanvangsDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int LestijdenAfstandsonderwijs { get; set; }
        public int MaximumCapaciteti { get; set; }
        public DateTime RegistratieMoment { get; set; }
        public int IdModuleVariant { get; set; }
        public int IdLesPlaats { get; set; }
        public bool IsInschrijfbaar { get; set; }
        public int IdSchooljaar { get; set; }
        public string MoodleCursusNaam { get; set; }
        public decimal MaxScoreTotaal { get; set; }
        public decimal MaxScorePermanenteEvaluatie { get; set; }
        public decimal MaxScoreEersteZit { get; set; }
        public DateTime DeliberatieDatum { get; set; }
        public DateTime DatumTweedeZit { get; set; }
        public string Naam { get; set; }
        public string CursusCodeIntern { get; set; }
        public DateTime DatumBijkomendeProef { get; set; }
        public string InfoPersoneel { get; set; }
        public string InfoLokaal { get; set; }
        public string InfoLessen { get; set; }
        public int IdOpleidingsVariant { get; set; }
        public int LestijdenOrganisatie { get; set; }

    }

    /// <summary> 
    /// Class definition ingeschreven module 
    /// </summary> 
    public class Plaatsing
    {
        public int Id { get; set; }
        public DateTime Inschrijvingsdatum { get; set; }
        public int Plaatsingsstatus { get; set; }
        public DateTime Reservatiedatum { get; set; }
        public DateTime Resultaatdatum { get; set; }
        public DateTime Stopzettingsdatum { get; set; }
        public DateTime Toewijzingsdatum { get; set; }
        public DateTime Uitschrijvingsdatum { get; set; }
        public int IdCursist { get; set; }
        public int IdIngerichteModulevariant { get; set; }
        public int IdIngerichteOpleidingsvariant { get; set; }
        public int IdPersoneel { get; set; }
        public int IdPlaatsingResultaat { get; set; }
        public DateTime InstapDatum { get; set; }

    }

    /// <summary> 
    /// Class definition Les 
    /// </summary> 
    public class LesDavinci
    {
        public string Cursusnummer { get; set; }
        public string Dag { get; set; }
        public string Datum { get; set; }
        public int IdLesplaats { get; set; }
        public string Campus { get; set; }
        public int IdIngerichteModulevariant { get; set; }
        public string Module { get; set; }
        public int IdPersoneel { get; set; }
        public string Docent { get; set; }
        public int IdLokaal { get; set; }
        public string Lokaal { get; set; }
        public string Aanvangsdatum { get; set; }
        public string Einddatum { get; set; }

    }

    /// <summary> 
    /// Class definition Lokaal 
    /// </summary> 
    public class Lokaal
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int AantalPlaatsen { get; set; }
        public int AantalComputersCursist { get; set; }

    }

    /// <summary> 
    /// Class definition module resultaat 
    /// </summary> 
    public class PlaatsingResultaat
    {
        public int Id { get; set; }
        public decimal PuntenTotaal { get; set; }
        public decimal PuntenPermanenteEvaluatie { get; set; }
        public decimal PuntenPermanenteEvaluatieNaDeliberatie { get; set; }
        public decimal PuntenEersteZit { get; set; }
        public decimal PuntenEersteZitNaDeliberatie { get; set; }
        public decimal PuntenTweedeZit { get; set; }
        public decimal PuntenTweedeZitNaDeliberatie { get; set; }
        public string OpmerkingPunten { get; set; }
        public string OpmerkingNaDeliberatieEersteZit { get; set; }
        public string OpmerkingNaDeliberatieTweedeZit { get; set; }
        public DateTime DatumUitgesteldeProef1 { get; set; }
        public DateTime DatumuitgesteldeProef2 { get; set; }
        public DateTime DatumBijkomendeProef { get; set; }

    }

    /// <summary> 
    /// Class definition Attest 
    /// </summary> 
    public class Attest
    {
        public int Id { get; set; }
        public string AttestBeschikbaar { get; set; }

    }

    /// <summary> 
    /// Class definition TweedeZit 
    /// </summary> 
    public class TweedeZit
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Omschrijving { get; set; }
        public decimal Resultaat { get; set; }

    }

}