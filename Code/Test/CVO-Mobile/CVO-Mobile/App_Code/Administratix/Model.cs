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
            public static List<BLL.TweedezitResultaat> Select2deZitByCursistNummer(int cursistNummer)
            {
                return DAL.TweedezitResultaat.Select2deZitByCursistNummer(cursistNummer);
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
            public static List<BLL.TrajectOverzicht> SelectTrajectByCursistNummer(int cursistNummer)
            {
                return DAL.TrajectOverzicht.SelectTrajectByCursistNummer(cursistNummer);
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