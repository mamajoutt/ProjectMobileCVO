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
        public bool CrursistIsIngeschreven { get; set; }
        public double PuntenTotaal { get; set; }
        public string Naam { get; set; }
        public int Lestijden { get; set; }

    }

    /// <summary> 
    /// Class definition Delibiratie 
    /// Used in DAL.DelibiratieDate
    /// </summary> 
    public class DelibiratieDate
    {
        public int Cursusnummer { get; set; }
        public string Module { get; set; }
        public string DeliberatieDatum { get; set; }
        public DateTime TweedeZitDatum { get; set; }
    }

    /// <summary> 
    /// Class definition Evenement 
    /// Used in DAL.Evenement
    /// </summary> 
    public class Evenement
    {
        public string EvenementName { get; set; }
        public DateTime Datum { get; set; }
        public string Locatie { get; set; }
        public string Van { get; set; }
        public string Tot { get; set; }

    }

    /// <summary> 
    /// Class definition LesDavinci 
    /// Used in DAL.LesDavinci
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


}