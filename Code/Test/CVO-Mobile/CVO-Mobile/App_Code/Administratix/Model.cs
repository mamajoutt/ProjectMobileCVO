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

            public static List<BLL.LesDavinci> LesDavinciSelectAllByCursistNummerWithVakantieDagen(List<BLL.LesDavinci> lessenrooster, List<BLL.Kalender> vakantiedagen)
            {
                foreach (BLL.Kalender k in vakantiedagen)
                {
                    if (!k.Omschrijving.Equals(""))
                    {
                        BLL.LesDavinci dag = new BLL.LesDavinci();
                        dag.Datum = k.Datum;
                        dag.Module = k.Omschrijving;

                        lessenrooster.Add(dag);
                    }

                }
                return lessenrooster.OrderBy(o => o.Datum).ThenBy(o => o.Aanvangsdatum).ToList();

            }
        }

        public class Evenement
        {
            public static List<BLL.Evenement> EvenementSelectAll()
            {
                Administratix.DAL.Evenement dal = new DAL.Evenement();
                return dal.SelectAll();
            }

            public static Administratix.BLL.Evenement EvenementSelectOne(int id)
            {
                Administratix.DAL.Evenement dal = new DAL.Evenement();
                return dal.SelectOne(id);
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
            public static string TweedeZitInschrijvingInsert(string idCursist, string grp2_IdTweedeZit)
            {
                Administratix.BLL.TweedeZitInschrijving tweedeZitInschrijving = new BLL.TweedeZitInschrijving();
                tweedeZitInschrijving.IdCursist = Convert.ToInt32(idCursist);
                tweedeZitInschrijving.IdTweedeZit = Convert.ToInt32(grp2_IdTweedeZit);
                Administratix.DAL.TweedeZitInschrijving dal = new DAL.TweedeZitInschrijving();
                dal.Insert(tweedeZitInschrijving);
                return dal.Message;
            }
        }

        public class StatusTraject
        {
            public static List<BLL.StatusTraject> SelectStatusByCursistNummer(int cursistNummer)
            {
                return DAL.StatusTraject.SelectStatusByCursistNummer(cursistNummer);
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

            public static List<BLL.Module> CombineerModuleResultatenMetTrajectModules(List<BLL.Module> trajectModules, List<BLL.CursusResultaat> moduleResultaten)
            {
                foreach (BLL.Module module in trajectModules)
                {
                    foreach (BLL.CursusResultaat resultaat in moduleResultaten)
                    {
                        if (resultaat.IdModuleVariant == module.Id)
                        {
                            module.CursistIsIngeschreven = true;
                            module.PuntenTotaal = resultaat.PuntenTotaal;
                            if (module.PuntenTotaal > 50)
                            {
                                module.CursistIsGeslaagd = true;
                            }
                        }
                    }
                }

                return trajectModules;
            }

            public static void ModulesAddVoorkennis(List<BLL.Module> trajectModules, List<KeyValuePair<int, int>> voorkennisPairs)
            {
                foreach (KeyValuePair<int, int> pair in voorkennisPairs)
                {
                    BLL.Module trajectModule = GetModuleFromListById(trajectModules, pair.Key);
                    BLL.Module voorkennisModule = GetModuleFromListById(trajectModules, pair.Value);
                    trajectModule.VoorkennisModules.Add(voorkennisModule);
                }

                foreach (BLL.Module module in trajectModules)
                {
                    module.CursistHeeftVoorkennis = HeeftNodigeVoorkennis(module);
                }
            }

            private static bool HeeftNodigeVoorkennis(BLL.Module module)
            {
                foreach (BLL.Module voorkennis in module.VoorkennisModules)
                {
                    if (!voorkennis.CursistIsIngeschreven || !voorkennis.CursistIsGeslaagd)
                    {
                        return false;
                    }
                }
                return true;
            }

            private static BLL.Module GetModuleFromListById(List<BLL.Module> modules, int id)
            {
                BLL.Module module = new BLL.Module();
                foreach (BLL.Module m in modules)
                {
                    if (m.Id == id)
                    {
                        module = m;
                    }
                }
                return module;

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
        }

        public class Kalender
        {
            public static List<BLL.Kalender> KalenderSelectAll()
            {
                Administratix.DAL.Kalender dal = new DAL.Kalender();
                return dal.SelectAll();
            }

            public static List<BLL.Kalender> KalenderSelectAllByDates(DateTime Date1,DateTime  Date2)
            {
                return DAL.Feestdagen.SelectFeestDagen(Date1,Date2);
            }
        }
    }
}