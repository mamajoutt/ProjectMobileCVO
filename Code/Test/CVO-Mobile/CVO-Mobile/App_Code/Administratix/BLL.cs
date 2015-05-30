using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administratix.BLL
{
    ///<summary>
    ///Class definition IngerichteModulevariant PlaatsingResultaat Grp2_TweedeZit
    /// Used in DAL.CursusResultaat
    /// </summary>
    public class CursusResultaat
    {
        public int IdIngerichteModulevariant { get; set; }
        public int IdModuleVariant { get; set; }
        public string CursusNummer { get; set; }
        public string Module { get; set; }
        public double PuntenTotaal { get; set; }
        public double PuntenPermanenteEvaluatie { get; set; }
        public double PuntenEersteZit { get; set; }
        public string OpmerkingNaDeliberatieEersteZit { get; set; }
        public int IdTweedeZit { get; set; }
        public double PuntenTweedeZit { get; set; }
        public string OpmerkingNaDeliberatieTweedeZit { get; set; }
    }

    ///<summary>
    ///Class definition IngerichteModulevariant
    /// Used in DAL.ModuleExamenData
    /// </summary>
    public class ModuleExamenData
    {
        public string CursusNummer { get; set; }
        public DateTime AanvangsDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public string Naam { get; set; }
        public DateTime ExamenDatum { get; set; }
        public DateTime DeliberatieDatum { get; set; }
        public DateTime DatumTweedeZit { get; set; }
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
        public int IdTweedeZit { get; set; }
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
    /// Class definition Evenement 
    /// Used in DAL.Evenement
    /// </summary> 
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public string Locatie { get; set; }
        public DateTime Start { get; set; }
        public DateTime Eind { get; set; }

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
        public int IdEvenement { get; set;}
        public string Naam { get; set; }
        public DateTime Datum { get; set; }
        public string Locatie { get; set; }
        public DateTime StartUur { get; set; }
        public DateTime EindUur { get; set; }
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
    /// Used in DAL.Kalender and DAL.Feesten
    /// </summary> 

    public class Kalender
    {
        public List<BLL.KalenderDag> Dagen { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public Kalender()
        {
            Dagen = new List<KalenderDag>();
        }

        public void CreerDagen(DateTime startDatum, DateTime eindDatum)
        {
            this.StartDatum = new DateTime();
            this.EindDatum = new DateTime();
            Dagen = new List<KalenderDag>();

            this.StartDatum = startDatum;
            this.EindDatum = eindDatum;

            while (startDatum.Date <= eindDatum.Date)
            {
                BLL.KalenderDag dag = new BLL.KalenderDag();
                dag.Datum = startDatum;
                Dagen.Add(dag);

                startDatum = startDatum.AddDays(1);
            }

        }

        public void VoegFeestenToe(List<BLL.KalenderDag> feestDagen)
        {
            foreach (BLL.KalenderDag dag in feestDagen)
            {
                //tel dagen van begin = dag in lijst
                int nr = (dag.Datum - StartDatum).Days;

                //safeguard
                if (nr >= 0 && nr <= Dagen.Count)
                {
                    Dagen[nr].Feesten.Add(dag);
                }
                
            }
        }
    }

    public class KalenderDag
    {
        public DateTime Datum { get; set; }
        public List<BLL.LesDavinci> Lessen { get; set; }
        public List<BLL.KalenderDag> Feesten { get; set; }
        public int IdSchooljaar { get; set; }
        public string Schooljaar { get; set; }
        public string Omschrijving { get; set; }
        //public int IdVerlofdagtype { get; set; }

        public KalenderDag()
        {
            Lessen = new List<LesDavinci>();
            Feesten = new List<KalenderDag>();
        }
    }

    public class Lessenrooster
    {
        public static bool FeestdagenTonen { get; set; }
        public static bool Compact { get; set; }
    }

}