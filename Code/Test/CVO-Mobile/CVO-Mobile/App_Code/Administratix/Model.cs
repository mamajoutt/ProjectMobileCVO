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
            public static List<BLL.LesDavinci> LesroosterTonen(int cursistNummer)
            {
                return DAL.LesDavinci.SelectAllByCursistNummer(cursistNummer);
            }

            public static List<BLL.LesDavinci> LesroosterTussenDatums(int cursistNummer, DateTime begin, DateTime einde)
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

            public static Administratix.BLL.Evenement EvenementSelectOne(int id)
            {
                Administratix.DAL.Evenement dal = new DAL.Evenement();
                return dal.SelectOne(id);
            }
        }

        public class EvenementInschrijving
        {
            public static string EvenementInschrijvingInsert(string idCursist, string idEvenement, string opmerkingen)
            {
                Administratix.BLL.EvenementInschrijving evenementInschrijving = new BLL.EvenementInschrijving();
                evenementInschrijving.IdCursist = Convert.ToInt32(idCursist);
                evenementInschrijving.IdEvenement = Convert.ToInt32(idEvenement);
                evenementInschrijving.Opmerkingen = opmerkingen;
                Administratix.DAL.EvenementInschrijving dal = new DAL.EvenementInschrijving();
                dal.Insert(evenementInschrijving);
                return dal.Message;
            }
        }

        public class CursusResultaat
        {
            public static List<BLL.CursusResultaat> CursusResultaten(int cursistNummer)
            {
                return DAL.CursusResultaat.SelectAllByCursistNummer(cursistNummer);
            }
        }

        public class TweedezitResultaat
        {
            public static List<BLL.TweedezitResultaat> Select2deZitByCursistNummer(int CursistNummer)
            {
                return DAL.TweedezitResultaat.Select2deZitByCursistNummer(CursistNummer);
            }
            public static int UpdateTweedeZit(int CursistNummer, string CursusNummer)
            {
                return DAL.TweedezitResultaat.UpdateTweedeZit(CursistNummer, CursusNummer);
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

        public class ExDel2deZitDate
        {
            public static List<Administratix.BLL.ExDel2deZitDate> ExDel2deZitDateSelectAll(int cursistNummer)
            {
                Administratix.DAL.ExDel2deZitDate dal = new DAL.ExDel2deZitDate();
                return dal.SelectAllByCursistNummer(cursistNummer);
            }
        }

        public class Cursist
        {
            public static string GetEmailByCursistNummer(int cursistNummer)
            {
                return DAL.Cursist.GetEmailByCursistNummer(cursistNummer);
            }
        }

        public class Kalender
        {
            public static List<BLL.Kalender> SelectFeestdagen(string Date1,string Date2)
            {
                return DAL.Feestdagen.SelectFeesdagen(Date1,Date2);
            }
        }
    }
}