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
        }

        //public class Evenement
        //{
        //    public static List<BLL.Evenement> EvenementenTonen()
        //    {
        //        return DAL.Evenement.SelectAllEvenement();
        //    }
        //}

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
                            module.CrursistIsIngeschreven = true;
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
                    if (!voorkennis.CrursistIsIngeschreven || !voorkennis.CursistIsGeslaagd)
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

        public class DelibiratieDate
        {
            public static List<BLL.DelibiratieDate> SelectDeliberatieDateByCursistNummer(int cursistNummer)
            {
                return DAL.DelibiratieDate.SelectDeliberatieDateByCursistNummer(cursistNummer);
            }
        }

        public class Evenement
        {
            public static List<BLL.Evenement> SelectAllEvenement()
            {
                return DAL.Evenement.SelectAllEvenement();
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