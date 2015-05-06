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

        public static List<BLL.TweedezitResultaat> Select2deZitByCursistNummer(int cursistNummer)
        {
            List<BLL.TweedezitResultaat> resultaten = new List<BLL.TweedezitResultaat>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "Select2deZitByCursistNummer";

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
                            BLL.TweedezitResultaat resultaat = new BLL.TweedezitResultaat();
                            resultaat.Module = result["Module"].ToString();
                            resultaat.Datum= Convert.ToDateTime(result["Datum"].ToString());
                            resultaat.Lokaal = result["Lokaal"].ToString();
                            resultaat.Van = result["Van"].ToString();
                            resultaat.Tot = result["Tot"].ToString();

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

            string sqlString = "SelectStatusTrajectByCursistNummer ";

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
                            resultaat.Module = result["Module"].ToString();
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

        public static List<BLL.TrajectOverzicht> SelectTrajectByCursistNummer(int cursistNummer)
        {
            List<BLL.TrajectOverzicht> resultaten = new List<BLL.TrajectOverzicht>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "SelectTrajectByCursistNummer";

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
                            BLL.TrajectOverzicht resultaat = new BLL.TrajectOverzicht();
                            resultaat.Module = result["Module"].ToString();
                            resultaat.Lestijden = Convert.ToInt32(result["Lestijden"].ToString());
                            resultaat.Code = result["Code"].ToString();

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

            string sqlString = "SelectDeliberatieDateByCursistNummer ";

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
                            resultaat.Module = result["Module"].ToString();
                            resultaat.Cursusnummer = Convert.ToInt32(result["Cursusnummer"].ToString());
                            resultaat.DeliberatieDatum = Convert.ToDateTime(result["Code"].ToString());
                            resultaat.TweedeZitDatum = Convert.ToDateTime(result["Code"].ToString());

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

        public static List<BLL.Evenement> Select2deZitByCursistNummer(int cursistNummer)
        {
            List<BLL.Evenement> resultaten = new List<BLL.Evenement>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "SelectEvenementByCursistNummer";

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
                            BLL.Evenement resultaat = new BLL.Evenement();
                            resultaat.Locatie = result["Locatie"].ToString();
                            resultaat.Datum = Convert.ToDateTime(result["Datum"].ToString());
                            resultaat.Evenement = result["Evenement"].ToString();
                            resultaat.Van = result["Van"].ToString();
                            resultaat.Tot = result["Tot"].ToString();

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

            string sqlString = "SelectAllPlaatsingResultaatByCursistNummer";

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
                            resultaat.CursusNaam = result["Module"].ToString();
                            double punt = 0;
                            Double.TryParse(result["PuntenTotaal"].ToString(), out punt);
                            resultaat.PuntenTotaal = punt;
                            punt = 0;
                            Double.TryParse(result["PuntenPermanenteEvaluatie"].ToString(), out punt);
                            resultaat.PuntenPermanenteEvaluatie = punt;
                            punt = 0;
                            Double.TryParse(result["PuntenEersteZit"].ToString(), out punt);
                            resultaat.PuntenEersteZit = punt;
                            punt = 0;
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
            string sqlString = "SelectAllLesDavinciByCursistNummer";

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
                            les.Module = result["Module"].ToString();
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