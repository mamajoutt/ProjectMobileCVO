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