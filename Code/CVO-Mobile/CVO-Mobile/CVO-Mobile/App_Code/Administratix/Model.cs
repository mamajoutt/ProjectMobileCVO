using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administratix
{
    public class Model
    {

        public class LesDavinci
        {
            public static List<BLL.LesDavinci> LesDavinciSelectAllByCursistNummer(int cursistNummer)
            {
                return DAL.LesDavinci.SelectAllByCursistNummer(cursistNummer);
            }

            public static List<BLL.LesDavinci> LesDavinciSelectAllByCursistNummerAndDates(int cursistNummer, DateTime begin, DateTime einde)
            {
                return DAL.LesDavinci.SelectAllByCursistNummerAndDates(cursistNummer, begin, einde);
            }

        }

        public class Evenement
        {
            public static List<BLL.Evenement> EvenementSelectAll()
            {
                Administratix.DAL.Evenement dal = new DAL.Evenement();
                return dal.SelectAll();
            }

        }

        public class EvenementInschrijving
        {
            public static string EvenementInschrijvingInsert(int idCursist, string idEvenement, string opmerkingen)
            {
                Administratix.BLL.EvenementInschrijving evenementInschrijving = new BLL.EvenementInschrijving();
                evenementInschrijving.IdCursist = Convert.ToInt32(idCursist);
                evenementInschrijving.IdEvenement = Convert.ToInt32(idEvenement);
                evenementInschrijving.Opmerkingen = opmerkingen;
                Administratix.DAL.EvenementInschrijving dal = new DAL.EvenementInschrijving();
                dal.Insert(evenementInschrijving);
                return dal.Message;
            }

            public static List<Administratix.BLL.EvenementInschrijving> evenementInschrijvingSelectAllByCursistNummer(int cursistNummer)
            {
                Administratix.DAL.EvenementInschrijving dal = new DAL.EvenementInschrijving();
                return dal.SelectAllByCursistNummer(cursistNummer);
            }

        }

        public class CursusResultaat
        {
            public static List<BLL.CursusResultaat> CursusResultaatSelectAllByCursistNummer(int cursistNummer)
            {
                Administratix.DAL.CursusResultaat dal = new DAL.CursusResultaat();
                return dal.SelectAllByCursistNummer(cursistNummer);
            }
        }

        public class TweedeZitInschrijving
        {
            public static string TweedeZitInschrijvingInsert(int idCursist, int grp2_IdTweedeZit)
            {
                Administratix.BLL.TweedeZitInschrijving tweedeZitInschrijving = new BLL.TweedeZitInschrijving();
                tweedeZitInschrijving.IdCursist = idCursist;
                tweedeZitInschrijving.IdTweedeZit = grp2_IdTweedeZit;
                Administratix.DAL.TweedeZitInschrijving dal = new DAL.TweedeZitInschrijving();
                dal.Insert(tweedeZitInschrijving);
                return dal.Message;
            }
        }

        public class TrajectOverzicht
        {
            public static List<KeyValuePair<int, int>> SelectVoorkennisIdsByOpleidingsvariantId(int id)
            {
                return DAL.TrajectOverzicht.SelectVoorkennisIdsByOpleidingsvariantId(id);
            }

            public static List<BLL.Module> SelectTrajectModulesByCursistNummer(int cursistNummer)
            {
                return DAL.TrajectOverzicht.SelectTrajectModulesByCursistNummer(cursistNummer);
            }
        }

        public class ModuleExamenData
        {
            public static List<Administratix.BLL.ModuleExamenData> ModuleExamenDatumsSelectAllByCursistNummer(int cursistNummer)
            {
                Administratix.DAL.ModuleExamenData dal = new DAL.ModuleExamenData();
                return dal.SelectAllByCursistNummer(cursistNummer);
            }
        }

        public class Cursist
        {
            public static BLL.Cursist CursistSelectAllByCursistNummer(int cursistNummer)
            {
                return DAL.Cursist.SelectCursistByCursistNummer(cursistNummer);
            }

            public static BLL.Cursist Login(string input)
            {
                BLL.Cursist cursist = new BLL.Cursist();
                int cursistNummer = 0;

                if (!Int32.TryParse(input, out cursistNummer))
                {
                    throw new Exception("Ingegeven cursistnummer is ongeldig.");
                }


                cursist = Administratix.Model.Cursist.CursistSelectAllByCursistNummer(cursistNummer);

                if (cursist.CursistNummer == 0)
                {
                    throw new Exception("Ingegeven cursistnummer is ongeldig.");
                }

                return cursist;
            }
        }

        public class Kalender
        {

            public static List<BLL.KalenderDag> KalenderSelectAllByDates(DateTime Date1, DateTime Date2)
            {
                return DAL.Feestdagen.SelectFeestDagen(Date1,Date2);
            }
        }

        public class pagina
        {
            public static string volgende(int i)
            {
                try
                {
                    List<string> pages = DAL.paginaTest.Makelist();
                    return pages[i + 1];
                }
                catch
                {
                    return "Error";
                }
            }
            public static string vorige(int i)
            {
                try
                {
                    List<string> pages = DAL.paginaTest.Makelist();
                    return pages[i - 1];
                }
                catch
                {
                    return "Error";
                }
            }
        }
    }
}