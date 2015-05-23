using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administratix.BLL
{
    /// <summary> 
    /// Class definition CursusResultaat 
    /// Used in DAL.CursusResultaat
    /// </summary> 
    public class CursusResultaat
    {
        public int CursusNummer { get; set; }
        public int IdModuleVariant { get; set; }
        public string CursusNaam { get; set; }
        public double PuntenTotaal { get; set; }
        public double PuntenPermanenteEvaluatie { get; set; }
        public double PuntenEersteZit { get; set; }
        public double PuntenTweedeZit { get; set; }
    }

    /// <summary> 
    /// Class definition Tweedezit 
    /// Used in DAL.TweedezitResultaat
    /// </summary> 
    public class TweedezitResultaat
    {
        public string Module { get; set; }
        public DateTime Datum { get; set; }
        public string Lokaal { get; set; }
        public string Van { get; set; }
        public string Tot { get; set; }
        public bool Ingeschreven { get; set; }
        public double Punten { get; set; }

    }

    /// <summary> 
    /// Class definition StatusTraject 
    /// Used in DAL.StatusTraject
    /// </summary> 
    public class StatusTraject
    {
        
        public int Cursusnummer { get; set; }
        public string Module { get; set; }
        public string Start { get; set; }
        public int AantalPlaatsen { get; set; }
        public bool Inschrijfbaar { get; set; }  
    }

    /// <summary> 
    /// Class definition Traject 
    /// Used in DAL.Module
    /// </summary> 
    public class Module
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool CursistIsIngeschreven { get; set; }
        public bool CursistIsGeslaagd { get; set; }
        public bool CursistHeeftVoorkennis { get; set; }
        public double PuntenTotaal { get; set; }
        public string Naam { get; set; }
        public int Lestijden { get; set; }
        public List<Module> VoorkennisModules { get; set; }

        public Module()
        {
            VoorkennisModules = new List<Module>();
        }
    }

    /// <summary> 
    /// Class definition ExDel2deZitDate 
    /// Used in DAL.ExDel2deZitDate
    /// </summary> 
    public class ExDel2deZitDate
    {
        public string Cursusnummer { get; set; }
        public string Module { get; set; }
        public string AanvangsDatum { get; set; }
        public string EindDatum { get; set; }
        public string ExamenDatum { get; set; }
        public string DeliberatieDatum { get; set; }
        public string DatumTweedeZit { get; set; }
    }

    /// <summary> 
    /// Class definition Evenement 
    /// Used in DAL.Evenement
    /// </summary> 
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Datum { get; set; }
        public string Locatie { get; set; }
        public string Start { get; set; }
        public string Eind { get; set; }

    }

    public class EvenementInschrijving
    {
        public int Id { get; set; }
        public DateTime ReservatieDatum { get; set; }
        public int IdCursist { get; set; }
        public string CursistNummer { get; set; }
        public int IdEvenement { get; set; }
        public string Opmerkingen { get; set; }
    }

    /// <summary> 
    /// Class definition LesDavinci 
    /// Used in DAL.LesDavinci
    /// </summary> 
    public class LesDavinci
    {
        public string Cursusnummer { get; set; }
        public string Dag { get; set; }
        public DateTime Datum { get; set; }
        public int IdLesplaats { get; set; }
        public string Campus { get; set; }
        public int IdIngerichteModulevariant { get; set; }
        public string Module { get; set; }
        public int IdPersoneel { get; set; }
        public string Docent { get; set; }
        public int IdLokaal { get; set; }
        public string Lokaal { get; set; }
        public DateTime Aanvangsdatum { get; set; }
        public DateTime Einddatum { get; set; }

    }

    public class Kalender
    {
        public int Id { get; set; }
        public string Datum { get; set; }
        public int IdSchooljaar { get; set; }
        public string Omschrijving { get; set; }
        //public int IdVerlofdagtype { get; set; }
    }

}