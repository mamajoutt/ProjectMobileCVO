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
                        }
                    }
                }

                return trajectModules;
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
            public static List<BLL.Evenement> Select2deZitByCursistNummer(int cursistNummer)
            {
                return DAL.Evenement.Select2deZitByCursistNummer(cursistNummer);
            }
        }
    }
}