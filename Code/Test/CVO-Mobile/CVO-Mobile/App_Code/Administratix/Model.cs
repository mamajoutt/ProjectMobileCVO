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
    }
}