using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileCVO.DAL
{
    interface IDal<TypeEntity>
    {
        string message {get;} 
        //bool Update(TypeEntity entity); 
        //int Insert(TypeEntity entity); 
        //bool Delete(int Id); 
        TypeEntity SelectOne(int id);
        List<TypeEntity> SelectAll();
    }
}

namespace Administratix.DAL
{
    //DAL voor Cursist 
    public class Cursist : MobileCVO.DAL.IDal<Administratix.BLL.Cursist>
    {
        public Cursist()
        {
            // 
        }

        public Administratix.BLL.Cursist SelectOne(int id)
        {
            //ProjectMobileCVO.BLL.Cursist cursist = new BLL.Cursist(); 

        }
    }

    //DAL voor Personeel 
    public class Personeel : MobileCVO.DAL.IDal<Administratix.BLL.Personeel>
    {
        public Personeel()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Schooljaar 
    public class Schooljaar : MobileCVO.DAL.IDal<Administratix.BLL.Schooljaar>
    {
        public Schooljaar()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Kalender 
    public class Kalender : MobileCVO.DAL.IDal<Administratix.BLL.Kalender>
    {
        public Kalender()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Evenement 
    public class Evenement : MobileCVO.DAL.IDal<Administratix.BLL.Evenement>
    {
        public Evenement()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Module 
    public class Module : MobileCVO.DAL.IDal<Administratix.BLL.Module>
    {
        public Module()
        {
            //this.message = ""; 
        }
    }

    //DAL voor IngerichteModulevariant 
    public class IngerichteModulevariant : MobileCVO.DAL.IDal<Administratix.BLL.IngerichteModulevariant>
    {
        public IngerichteModulevariant()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Plaatsing 
    public class Plaatsing : MobileCVO.DAL.IDal<Administratix.BLL.Plaatsing>
    {
        public Plaatsing()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Les 
    public class LesDavinci : MobileCVO.DAL.IDal<Administratix.BLL.LesDavinci>
    {
        public LesDavinci()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Lokaal 
    public class Lokaal : MobileCVO.DAL.IDal<Administratix.BLL.Lokaal>
    {
        public Lokaal()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Resultaat 
    public class PlaatsingResultaat : MobileCVO.DAL.IDal<Administratix.BLL.PlaatsingResultaat>
    {
        public PlaatsingResultaat()
        {
            //this.message = ""; 
        }
    }

    //DAL voor Attest 
    public class Attest : MobileCVO.DAL.IDal<Administratix.BLL.Attest>
    {
        public Attest()
        {
            //this.message = ""; 
        }
    }

    //DAL voor TweedeZit 
    public class TweedeZit : MobileCVO.DAL.IDal<Administratix.BLL.TweedeZit>
    {
        public TweedeZit()
        {
            //this.message = ""; 
        }
    }
}