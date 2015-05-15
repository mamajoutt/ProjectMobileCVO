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
        TypeEntity SelectOne(int cursistNummer);
        List<TypeEntity> SelectAllByCursistNummer(int cursistNummer);
    }
}

namespace Administratix.DAL
{

    public class TweedezitResultaat 
    {

        public static List<BLL.TweedezitResultaat> Select2deZitByCursistNummer(int CursistNummer)
        {
            List<BLL.TweedezitResultaat> resultaten = new List<BLL.TweedezitResultaat>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectTweedeZitByCursistNummer";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = CursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.TweedezitResultaat resultaat = new BLL.TweedezitResultaat();
                            resultaat.Module = result["Module"].ToString();
                            resultaat.Datum= Convert.ToDateTime(result["Datum"].ToString());
                            resultaat.Lokaal = result["Lokaal"].ToString();
                            resultaat.Van = result["Van"].ToString();
                            resultaat.Tot = result["Tot"].ToString();
                            resultaat.Punten = Convert.ToDouble(result["Punten"].ToString());
                            resultaat.Ingeschreven = Convert.ToBoolean(result["Ingeschreven"].ToString());

                            resultaten.Add(resultaat);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return resultaten;
        }
        public static int UpdateTweedeZit(int CursistNummer, string CursusNummer)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_UpdateTweedeZit";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = CursistNummer;
            command.Parameters.Add(new SqlParameter("@CursusNummer",
               SqlDbType.NVarChar)).Value = CursusNummer;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sqlString;
            command.Connection = connection;
            //this.message = "Niets te melden";

            int row = 0;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";
                row = command.ExecuteNonQuery();
                if(row == 1)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }

            }
            catch (SqlException e)
            {
                //this.message = e.Message;
                result = 3;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }

    public class StatusTraject 
    {

        public static List<BLL.StatusTraject> SelectStatusByCursistNummer(int cursistNummer)
        {
            List<BLL.StatusTraject> resultaten = new List<BLL.StatusTraject>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectStatusTrajectByCursistNummer";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.StatusTraject resultaat = new BLL.StatusTraject();
                            resultaat.Module = result["Naam"].ToString();
                            resultaat.AantalPlaatsen = Convert.ToInt32(result["AantalPlaatsen"].ToString());
                            resultaat.Cursusnummer = Convert.ToInt32(result["Cursusnummer"].ToString());
                            resultaat.Inschrijfbaar = Convert.ToBoolean(result["Inschrijfbaar"].ToString());
                            resultaat.Start = result["Start"].ToString();

                            resultaten.Add(resultaat);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return resultaten;
        }
    }

    public class TrajectOverzicht
    {

        public static List<KeyValuePair<int, int>> SelectVoorkennisIdsByOpleidingsvariantId(int id)
        {
            List<KeyValuePair<int, int>> idPairs = new List<KeyValuePair<int, int>>();

            //List<BLL.CursusResultaat> resultaten = new List<BLL.CursusResultaat>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectTrajectVoorkennisByOpleidingsvariantId";

            command.Parameters.Add(new SqlParameter("@OpleidingsvariantId",
               SqlDbType.Int)).Value = id;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            int modulevariantId = Convert.ToInt32(result["ModulevariantId"].ToString());
                            int voorkenisModulevariantId = Convert.ToInt32(result["VoorkennisModulevariantId"].ToString());

                            idPairs.Add(new KeyValuePair<int, int>(modulevariantId, voorkenisModulevariantId));
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return idPairs;
        }

        public static List<BLL.Module> SelectTrajectModulesByCursistNummer(int cursistNummer)
        {
            List<BLL.Module> modules = new List<BLL.Module>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectTrajectModulesByCursistNummer";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.Module module = new BLL.Module();
                            module.Id = Convert.ToInt32(result["Id"].ToString());
                            module.Naam = result["Naam"].ToString();
                            //module.Lestijden = Convert.ToInt32(result["Lestijden"].ToString());
                            //module.Code = result["Code"].ToString();

                            modules.Add(module);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return modules;
        }
    }

    public class DelibiratieDate
    {

        public static List<BLL.DelibiratieDate> SelectDeliberatieDateByCursistNummer(int cursistNummer)
        {
            List<BLL.DelibiratieDate> resultaten = new List<BLL.DelibiratieDate>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectDeliberatieDateByCursistNummer";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.DelibiratieDate resultaat = new BLL.DelibiratieDate();
                            resultaat.Module = result["Naam"].ToString();
                            resultaat.Cursusnummer = Convert.ToInt32(result["Cursusnummer"].ToString());
                            resultaat.DeliberatieDatum = result["DeliberatieDatum"].ToString();
                            resultaat.TweedeZitDatum = Convert.ToDateTime(result["TweedeZitDatum"].ToString());

                            resultaten.Add(resultaat);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return resultaten;
        }
    }

    public class Evenement
    {

        public static List<BLL.Evenement> SelectAllEvenement()
        {
            List<BLL.Evenement> evenementenLijst = new List<BLL.Evenement>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectAllEvenement";

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.Evenement evenement = new BLL.Evenement();
                            evenement.Naam = result["Naam"].ToString();
                            evenement.Datum = Convert.ToDateTime(result["Datum"].ToString());
                            evenement.Locatie = result["Locatie"].ToString();
                            evenement.Start = result["StartUur"].ToString();
                            evenement.Eind = result["EindUur"].ToString();

                            evenementenLijst.Add(evenement);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return evenementenLijst;
        }
    }

    public class CursusResultaat //: MobileCVO.DAL.IDal<BLL.CursusResultaat>
    {
        /*private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public CursusResultaat()
       {
           this.message = "";
       }*/

        public static List<BLL.CursusResultaat> SelectAllByCursistNummer(int cursistNummer)
        {
            List<BLL.CursusResultaat> resultaten = new List<BLL.CursusResultaat>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectAllPlaatsingResultaatByCursistNummer";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            //this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.CursusResultaat resultaat = new BLL.CursusResultaat();
                            resultaat.CursusNummer = Convert.ToInt32(result["Cursusnummer"].ToString());
                            resultaat.CursusNaam = result["Naam"].ToString();
                            double punt = -1;
                            resultaat.IdModuleVariant = Convert.ToInt32(result["IdModuleVariant"].ToString());
                            Double.TryParse(result["PuntenTotaal"].ToString(), out punt);
                            resultaat.PuntenTotaal = punt;
                            punt = -1;
                            Double.TryParse(result["PuntenPermanenteEvaluatie"].ToString(), out punt);
                            resultaat.PuntenPermanenteEvaluatie = punt;
                            punt = -1;
                            Double.TryParse(result["PuntenEersteZit"].ToString(), out punt);
                            resultaat.PuntenEersteZit = punt;
                            punt = -1;
                            Double.TryParse(result["PuntenTweedeZit"].ToString(), out punt);
                            resultaat.PuntenTweedeZit = punt;

                            resultaten.Add(resultaat);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return resultaten;
        }
    }

    public class LesDavinci //: MobileCVO.DAL.IDal<BLL.LesDavinci>
    {
        /*private string message;
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
        }*/

        public static List<BLL.LesDavinci> SelectAllByCursistNummer(int cursistNummer)
        {
            List<BLL.LesDavinci> lessenrooster = new List<BLL.LesDavinci>();
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
            string sqlString = "grp2_SelectAllLesDavinciByCursistNummer";

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
            //this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            SqlDataReader result;
            try
            {
                connection.Open();
                //this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.LesDavinci les = new BLL.LesDavinci();
                            les.Cursusnummer = result["Cursusnummer"].ToString(); 
                            les.Dag = result["Dag"].ToString(); 
                            les.Datum = result["Datum"].ToString();
                            les.IdPersoneel = (int)result["IdPersoneel"];
                            les.Docent = result["Docent"].ToString();
                            les.IdLesplaats = (int)result["IdLesPlaats"];
                            les.Campus = result["Campus"].ToString();
                            les.IdLokaal = (int)result["IdLokaal"];
                            les.Lokaal = result["Lokaal"].ToString();
                            les.IdIngerichteModulevariant = (int)result["IdIngerichteModulevariant"];
                            les.Module = result["Naam"].ToString();
                            les.Aanvangsdatum = result["Van"].ToString();
                            les.Einddatum = result["Tot"].ToString();
                            lessenrooster.Add(les);
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                //this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return lessenrooster;
        }
    }
}