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
            public static Administratix.BLL.LesDavinci LesroosterTonen(int cursistNummer)
            {
                Administratix.DAL.LesDavinci dal = new DAL.LesDavinci();
                return dal.SelectOne(cursistNummer);
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