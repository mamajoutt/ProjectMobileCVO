using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        TypeEntity SelectOne(int cursistNummer);
        List<TypeEntity> SelectAll();
    }
}

namespace Administratix.DAL
{
    public class Cursist : MobileCVO.DAL.IDal<BLL.Cursist>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Cursist()
       {
           this.message = "";
       }

        public Administratix.BLL.Cursist SelectOne(int id)
        {
            Administratix.BLL.Cursist cursist = new BLL.Cursist();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_Cursist";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        cursist.Id = (int)result["Id"];
                        cursist.CursistNummer = result["CursistNummer"].ToString();
                        cursist.Familienaam = result["Familienaam"].ToString();
                        cursist.Voornaam = result["Voornaam"].ToString();
                        cursist.Email = result["Email"].ToString();
                        cursist.GSM = result["GSM"].ToString();
                        cursist.Tel1 = result["Tel1"].ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return cursist;
        }
    }

    public class Personeel : MobileCVO.DAL.IDal<BLL.Personeel>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Personeel()
        {
            this.message = "";
        }

        public Administratix.BLL.Personeel SelectOne(int id)
        {
            Administratix.BLL.Personeel personeel = new BLL.Personeel();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_Personeel";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        personeel.Id = (int)result["Id"];
                        personeel.Personeelnummer = (int)result["Personeelsnummer"];
                        personeel.Naam = result["Naam"].ToString();
                        personeel.Voornaam = result["Voornaam"].ToString();
                        personeel.UserName = result["UserName"].ToString();
                        personeel.EmailCentrum = result["EmailCentrum"].ToString();
                        personeel.Stamboeknummer = result["Stamboeknummer"].ToString();
                        personeel.Geslacht = result["Geslacht"].ToString();
                        personeel.GSM = result["GSM"].ToString();
                        personeel.TEL = result["TEL"].ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return personeel;
        }

        public List<Administratix.BLL.Personeel> SelectAll()
        {
            List<Administratix.BLL.Personeel> personeelsLijst = new List<Administratix.BLL.Personeel>();

           // geen plain vanilla sql statement meegeven,
           // parameters gebruiken
           SqlConnection connection = new SqlConnection();
           connection.ConnectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["MobileCVO"].ToString();
           // Sqlcommand object
           SqlCommand command = new SqlCommand();
           // in de CommandText eigenschap stoppen de naam
           // van de stored procedure
           string sqlString = "SelectAll_Personeel";

           // zeg aan het command object dat het een tored procedure
           // zal krijgen en geen SQL Statement
           command.CommandType = CommandType.StoredProcedure;
           // stop het sql statement in het command object
           command.CommandText = sqlString;
           // geeft het connection object door aan het command object
           command.Connection = connection;
           this.message = "Niets te melden";
           // we gaan ervan uit dat het mislukt
           SqlDataReader result;

           try
           {
               connection.Open();
               this.message = "De database is klaar!";
               // voeg using toe om er voor te zorgen dat
               // de datareader gesloten wordt als we die niet
               // meer nodig hebben
               using (result = command.ExecuteReader())
               {
                   if (result.HasRows)
                   {
                       // zolang dat er iets te lezen valt
                       // uit de tabel
                       while (result.Read())
                       {
                           Administratix.BLL.Personeel personeel = new Administratix.BLL.Personeel();
                           personeel.Id = (int)result["Id"];
                           personeel.Personeelnummer = (int)result["Personeelsnummer"];
                           personeel.Naam = result["Naam"].ToString();
                           personeel.Voornaam = result["Voornaam"].ToString();
                           personeel.UserName = result["UserName"].ToString();
                           personeel.EmailCentrum = result["EmailCentrum"].ToString();
                           personeel.Stamboeknummer = result["Stamboeknummer"].ToString();
                           personeel.Geslacht = result["Geslacht"].ToString();
                           personeel.GSM = result["GSM"].ToString();
                           personeel.TEL = result["TEL"].ToString();
                           personeelsLijst.Add(personeel);
                       }
                   }
               }
           }
           catch (SqlException e)
           {
               this.message = e.Message;
           }
           finally
           {
               connection.Close();
           }
           return personeelsLijst;
       
        }

    }

    public class Schooljaar : MobileCVO.DAL.IDal<BLL.Schooljaar>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Schooljaar()
        {
            this.message = "";
        }

        public Administratix.BLL.Schooljaar SelectOne(int id)
        {
            Administratix.BLL.Schooljaar schooljaar = new BLL.Schooljaar();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_Schooljaar";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        schooljaar.Id = (int)result["Id"];
                        schooljaar.Omschrijving = result["Omschrijving"].ToString();
                        schooljaar.AanvangsDatum = (DateTime)result["AanvangsDatum"];
                        schooljaar.EindDatum = (DateTime)result["EindDatum"];
                        schooljaar.IsHuidig = (bool)result["IsHuidig"];
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return schooljaar;
        }
    }

    public class Kalender : MobileCVO.DAL.IDal<BLL.Kalender>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Kalender()
        {
            this.message = "";
        }

        public List<Administratix.BLL.Kalender> SelectAll()
        {
            List<Administratix.BLL.Kalender> kalenderLijst = new List<Administratix.BLL.Kalender>();

            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectAll_Kalender";

            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;

            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        // zolang dat er iets te lezen valt
                        // uit de tabel
                        while (result.Read())
                        {
                            Administratix.BLL.Kalender kalender = new Administratix.BLL.Kalender();
                            kalender.Id = (int)result["Id"];
                            kalender.Datum = (DateTime)result["Datum"];
                            kalender.IdSchooljaar = (int)result["IdSchooljaar"];
                            kalender.Omschrijving = result["Omschrijving"].ToString();
                            kalender.IdVerlofdagType = (int)result["IdVerlofdagType"];
                            kalenderLijst.Add(kalender);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return kalenderLijst;

        }

    }

    public class Evenement : MobileCVO.DAL.IDal<BLL.Evenement>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Evenement()
        {
            this.message = "";
        }

        public Administratix.BLL.Evenement SelectOne(int id)
        {
            Administratix.BLL.Evenement evenement = new BLL.Evenement();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_Evenement";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        evenement.Id = (int)result["Id"];
                        evenement.Evenement = result["Evenement"].ToString();
                        evenement.Datum = (DateTime)result["Datum"];
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return evenement;
        }

        public List<Administratix.BLL.Evenement> SelectAll()
        {
            List<Administratix.BLL.Evenement> evenementenLijst = new List<Administratix.BLL.Evenement>();

            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectAll_Evenement";

            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;

            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        // zolang dat er iets te lezen valt
                        // uit de tabel
                        while (result.Read())
                        {
                            Administratix.BLL.Evenement evenement = new Administratix.BLL.Evenement();
                            evenement.Id = (int)result["Id"];
                            evenement.Evenement = result["Evenement"].ToString();
                            evenement.Datum = (DateTime)result["Datum"];
                            evenementenLijst.Add(evenement);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return evenementenLijst;

        }

    }

    public class Module : MobileCVO.DAL.IDal<BLL.Module>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public Module()
        {
            this.message = "";
        }

        public Administratix.BLL.Module SelectOne(int id)
        {
            Administratix.BLL.Module module = new BLL.Module();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_Module";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        module.Id = (int)result["Id"];
                        module.Naam = result["Naam"].ToString();                        
                        module.Omschrijving = result["Omschrijving"].ToString();
                        module.Code = (int)result["Code"];
                        module.Aanvangsdatum = (DateTime)result["Aanvangsdatum"];
                        module.Einddatum = (DateTime)result["Einddatum"];
                        module.IdModuletype = (int)result["IdModuleType"];
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return module;
        }
    }

    /**
     * Tot de constatatie gekomen dat al dit niet nodig is !!!! pff
     * public class IngerichteModulevariant : MobileCVO.DAL.IDal<BLL.IngerichteModulevariant>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public IngerichteModulevariant()
        {
            this.message = "";
        }

        public Administratix.BLL.IngerichteModulevariant SelectOne(int id)
        {
            Administratix.BLL.IngerichteModulevariant ingerichteModulevariant = new BLL.IngerichteModulevariant();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByID_IngerichteModulevariant";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@Id",
               SqlDbType.Int)).Value = id;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        evenement.Id = (int)result["Id"];
                        evenement.Evenement = result["Evenement"].ToString();
                        evenement.Datum = (DateTime)result["Datum"];
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return evenement;
        }

        public List<Administratix.BLL.Evenement> SelectAll()
        {
            List<Administratix.BLL.Evenement> evenementenLijst = new List<Administratix.BLL.Evenement>();

            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectAll_Evenement";

            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;

            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        // zolang dat er iets te lezen valt
                        // uit de tabel
                        while (result.Read())
                        {
                            Administratix.BLL.Evenement evenement = new Administratix.BLL.Evenement();
                            evenement.Id = (int)result["Id"];
                            evenement.Evenement = result["Evenement"].ToString();
                            evenement.Datum = (DateTime)result["Datum"];
                            evenementenLijst.Add(evenement);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return evenementenLijst;

        }

    }
    **/

    public class LesDavinci : MobileCVO.DAL.IDal<BLL.LesDavinci>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public LesDavinci()
        {
            this.message = "";
        }

        public Administratix.BLL.LesDavinci SelectOne(int cursistNummer)
        {
            Administratix.BLL.LesDavinci lesDavinci = new BLL.LesDavinci();
            // geen plain vanilla sql statement meegeven,
            // parameters gebruiken
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "SelectOneByCursistNummer_LesDavinci";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";
                // voeg using toe om er voor te zorgen dat
                // de datareader gesloten wordt als we die niet
                // meer nodig hebben
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        result.Read();
                        lesDavinci.Id = (int)result["Id"];
                        lesDavinci.Dag = result["Dag"].ToString();
                        lesDavinci.Datum = result["Datum"].ToString();
                        lesDavinci.IdPersoneel = (int)result["IdPersoneel"];
                        lesDavinci.Docent = result["Docent"].ToString();
                        lesDavinci.IdLesplaats = (int)result["IdLesPlaats"];
                        lesDavinci.Campus = result["Campus"].ToString();
                        lesDavinci.IdLokaal = (int)result["IdLokaal"];
                        lesDavinci.Lokaal = result["Lokaal"].ToString();
                        lesDavinci.IdIngerichteModulevariant = (int)result["IdIngerichteModulevariant"];
                        lesDavinci.Module = result["Module"].ToString();
                        lesDavinci.Aanvangsdatum = result["Van"].ToString();
                        lesDavinci.Einddatum = result["Tot"].ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return lesDavinci;
        }
    }
}