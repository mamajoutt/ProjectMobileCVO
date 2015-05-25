﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administratix.BLL
{
    ///<summary>
    ///Class definition IngerichteModulevariant CursusResultaat
    /// Used in DAL.CursusResultaat
    /// </summary>
    public class CursusResultaat
    {
        public int Id { get; set; }
        public int IdModuleVariant { get; set; }
        public string CursusNummer { get; set; }
        public string Module { get; set; }
        public string AanvangsDatum { get; set; }
        public string EindDatum { get; set; }
        public double PuntenTotaal { get; set; }
        public double PuntenPermanenteEvaluatie { get; set; }
        public double PuntenEersteZit { get; set; }
        public int Grp2_IdTweedeZit { get; set; }
        public double PuntenTweedeZit { get; set; }
        public string OpmerkingNaDeliberatieEersteZit { get; set; }
    }

    public class Cursist
    {
        public int CursistNummer { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Email { get; set; }
    }

    /// <summary> 
    /// Class definition TweedeZitInschrijving
    /// Used in DAL.TweedeZitInschrijving
    /// </summary> 
    public class TweedeZitInschrijving
    {
        public int Id { get; set; }
        public DateTime ReservatieDatum { get; set; }
        public int IdCursist { get; set; }
        public int Grp2_IdTweedeZit { get; set; }
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
        public DateTime AanvangsDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public DateTime ExamenDatum { get; set; }
        public DateTime DeliberatieDatum { get; set; }
        public DateTime DatumTweedeZit { get; set; }
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

    /// <summary> 
    /// Class definition EvenementInschrijving
    /// Used in DAL.EvenementInschrijving
    /// </summary> 
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
        public DateTime Datum { get; set; }
        public string Campus { get; set; }
        public string Module { get; set; }
        public string Docent { get; set; }
        public string Lokaal { get; set; }
        public DateTime Aanvangsdatum { get; set; }
        public DateTime Einddatum { get; set; }

    }

    /// <summary> 
    /// Class definition Kalender 
    /// Used in DAL.Kalender and DAL.Feestdagen
    /// </summary> 
    public class Kalender
    {
        public int Id { get; set; }
        public int IdSchooljaar { get; set; }
        public string Schooljaar { get; set; }
        public DateTime Datum { get; set; }
        public string Omschrijving { get; set; }
        //public int IdVerlofdagtype { get; set; }
    }

}