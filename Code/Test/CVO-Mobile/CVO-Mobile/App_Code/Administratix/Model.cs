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
    }
}