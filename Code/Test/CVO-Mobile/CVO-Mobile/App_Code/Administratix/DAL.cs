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
        string Message {get;} 
        //bool Update(TypeEntity entity); 
        int Insert(TypeEntity entity); 
        //bool Delete(int Id); 
        TypeEntity SelectOne(int id);
        List<TypeEntity> SelectAll();
        List<TypeEntity> SelectAllByCursistNummer(int cursistNummer);
    }
}

namespace Administratix.DAL
{

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

    public class ExDel2deZitDate : MobileCVO.DAL.IDal<BLL.ExDel2deZitDate>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public ExDel2deZitDate()
        {
            this.message = "";
        }

        public int Insert(BLL.ExDel2deZitDate entity)
        {
            throw new NotImplementedException();
        }

        public BLL.ExDel2deZitDate SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<BLL.ExDel2deZitDate> SelectAll()
        {
            throw new NotImplementedException();
        }


        public List<BLL.ExDel2deZitDate> SelectAllByCursistNummer(int cursistNummer)
        {
            List<BLL.ExDel2deZitDate> exDel2deZitDateLijst = new List<BLL.ExDel2deZitDate>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectExDel2deZitDateByCursistNummer";

            command.CommandType = CommandType.StoredProcedure;

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;
            command.CommandText = sqlString;

            command.Connection = connection;
            this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.ExDel2deZitDate exDel2deZitDate = new BLL.ExDel2deZitDate();
                            exDel2deZitDate.Cursusnummer = result["CursusNummer"].ToString();
                            exDel2deZitDate.Module = result["Module"].ToString();
                            exDel2deZitDate.AanvangsDatum = Convert.ToDateTime(result["AanvangsDatum"]);
                            exDel2deZitDate.EindDatum = Convert.ToDateTime(result["EindDatum"]);
                            exDel2deZitDate.ExamenDatum = Convert.ToDateTime(result["ExamenDatum"]);
                            exDel2deZitDate.DeliberatieDatum = Convert.ToDateTime(result["DeliberatieDatum"]);
                            exDel2deZitDate.DatumTweedeZit = Convert.ToDateTime(result["DatumTweedeZit"]);
                            exDel2deZitDateLijst.Add(exDel2deZitDate);
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

            return exDel2deZitDateLijst;
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

        public List<BLL.Evenement> SelectAll()
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
            this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.Evenement evenement = new BLL.Evenement();
                            evenement.Id = (int)result["Id"];
                            evenement.Naam = result["Naam"].ToString();
                            evenement.Datum = result["Datum"].ToString();
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
                this.message = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return evenementenLijst;
        }


        public BLL.Evenement SelectOne(int id)
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
            string sqlString = "grp2_SelectOneEvenementById";

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
                // retourneert het aantal rijen dat geïnserted werd
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
                        evenement.Naam = result["Naam"].ToString();
                        evenement.Datum = result["Datum"].ToString();
                        evenement.Locatie = result["Locatie"].ToString();
                        evenement.Start = result["StartUur"].ToString();
                        evenement.Eind = result["EindUur"].ToString();
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


        public int Insert(BLL.Evenement entity)
        {
            throw new NotImplementedException();
        }


        public List<BLL.Evenement> SelectAllByCursistNummer(int cursistNummer)
        {
            throw new NotImplementedException();
        }
    }

    public class EvenementInschrijving : MobileCVO.DAL.IDal<BLL.EvenementInschrijving>
    {

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public EvenementInschrijving()
        {
            this.message = "";
        }

        public int Insert(BLL.EvenementInschrijving inschrijvingEvenement)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "grp2_InsertCursistEvenement";
            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@CursistNummer",
                SqlDbType.Int)).Value = inschrijvingEvenement.IdCursist;
            command.Parameters.Add(new SqlParameter("@IdEvenement",
                SqlDbType.Int)).Value = inschrijvingEvenement.IdEvenement;
            command.Parameters.Add(new SqlParameter("@Opmerkingen",
                SqlDbType.NVarChar, 255)).Value = inschrijvingEvenement.Opmerkingen;
            command.Parameters.Add(new SqlParameter("@ReservatieDatum",
                SqlDbType.DateTime)).Value = DateTime.Now;
            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;
            command.Parameters.Add(id);
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            int result = 0;
            try
            {
                connection.Open();
                // retourneert het aantal rijen dat geïnserted werd
                this.message = "De database is klaar!";
                result = command.ExecuteNonQuery();
                // we moeten kijken naar de waarde van out parameter
                // van Insert stored procedure. Als de naam van de
                // category al bestaat, retourneert de out parameter van
                // de stored procedure
                // -1
                if ((int)id.Value == -100)
                {
                    this.message = String.Format("U bent reeds ingeschreven voor dit evenement.");
                    result = -100;
                }
                else if (result <= 0)
                {
                    this.message = String.Format("Uw inschrijving voor dit evenement is niet geregistreerd, probeer het nog een keer.");
                }
                else
                {
                    message = String.Format("Uw inschrijving voor dit evenement is succesvol afgerond!");
                    result = (int)id.Value;
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
            return result; // 0 of de Id van de nieuwe rij
        }

        public BLL.EvenementInschrijving SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<BLL.EvenementInschrijving> SelectAll()
        {
            throw new NotImplementedException();
        }


        public List<BLL.EvenementInschrijving> SelectAllByCursistNummer(int cursistNummer)
        {
            throw new NotImplementedException();
        }
    }

    public class CursusResultaat : MobileCVO.DAL.IDal<BLL.CursusResultaat>
    {
        private string message;
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
        }

        public List<BLL.CursusResultaat> SelectAll()
        {
            throw new NotImplementedException();
        }


        public BLL.CursusResultaat SelectOne(int id)
        {
            throw new NotImplementedException();
        }


        public int Insert(BLL.CursusResultaat entity)
        {
            throw new NotImplementedException();
        }


        public List<BLL.CursusResultaat> SelectAllByCursistNummer(int cursistNummer)
        {
            List<BLL.CursusResultaat> resultatenLijst = new List<BLL.CursusResultaat>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectAllResultatenByCursistNummer";

            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;

            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = sqlString;

            command.Connection = connection;
            this.message = "Niets te melden";

            SqlDataReader result;
            try
            {
                connection.Open();
                this.message = "De database is klaar!";

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.CursusResultaat resultaat = new BLL.CursusResultaat();
                            resultaat.Id = (int)result["Id"];
                            resultaat.IdModuleVariant = (int)result["IdModuleVariant"];
                            resultaat.CursusNummer = result["CursusNummer"].ToString();
                            resultaat.Module = result["Module"].ToString();
                            resultaat.AanvangsDatum = result["AanvangsDatum"].ToString();
                            resultaat.EindDatum = result["EindDatum"].ToString();
                            double punt = -1;
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
                            int id = 0;
                            Int32.TryParse(result["grp2_IdTweedeZit"].ToString(), out id);
                            resultaat.Grp2_IdTweedeZit = id;
                            //resultaat.Grp2_IdTweedeZit = (int)result["grp2_IdTweedeZit"];
                            //resultaat.PuntenTotaal = (double)result["PuntenTotaal"];
                            //resultaat.PuntenPermanenteEvaluatie = (double)result["PuntenPermanenteEvaluatie"];
                            //resultaat.PuntenEersteZit = (double)result["PuntenEersteZit"];
                            //resultaat.PuntenTweedeZit = (double)result["PuntenTweedeZit"];
                            resultaat.OpmerkingNaDeliberatieEersteZit = result["OpmerkingNaDeliberatieEersteZit"].ToString();
                            resultatenLijst.Add(resultaat);
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

            return resultatenLijst;
        }
    }

    public class TweedeZitInschrijving : MobileCVO.DAL.IDal<BLL.TweedeZitInschrijving>
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public int Insert(BLL.TweedeZitInschrijving inschrijvingTweedeZit)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();
            // Sqlcommand object
            SqlCommand command = new SqlCommand();
            // in de CommandText eigenschap stoppen de naam
            // van de stored procedure
            string sqlString = "grp2_InsertCursistTweedeZit";
            // shortcut to add parameter
            command.Parameters.Add(new SqlParameter("@CursistNummer",
                SqlDbType.Int)).Value = inschrijvingTweedeZit.IdCursist;
            command.Parameters.Add(new SqlParameter("@IdTweedeZit",
                SqlDbType.Int)).Value = inschrijvingTweedeZit.Grp2_IdTweedeZit ;
            command.Parameters.Add(new SqlParameter("@ReservatieDatum",
                SqlDbType.DateTime)).Value = DateTime.Now;
            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;
            command.Parameters.Add(id);
            // zeg aan het command object dat het een tored procedure
            // zal krijgen en geen SQL Statement
            command.CommandType = CommandType.StoredProcedure;
            // stop het sql statement in het command object
            command.CommandText = sqlString;
            // geeft het connection object door aan het command object
            command.Connection = connection;
            this.message = "Niets te melden";
            // we gaan ervan uit dat het mislukt
            int result = 0;
            try
            {
                connection.Open();
                // retourneert het aantal rijen dat geïnserted werd
                this.message = "De database is klaar!";
                result = command.ExecuteNonQuery();
                // we moeten kijken naar de waarde van out parameter
                // van Insert stored procedure. Als de naam van de
                // category al bestaat, retourneert de out parameter van
                // de stored procedure
                // -1
                if ((int)id.Value == -100)
                {
                    this.message = String.Format("U bent reeds ingeschreven voor de 2de zit van deze module.");
                    result = -100;
                }
                else if (result <= 0)
                {
                    this.message = String.Format("Uw inschrijving voor de 2de zit van deze module is niet geregistreerd, probeert u het nog een keer a.u.b");
                }
                else
                {
                    message = String.Format("Uw inschrijving voor de 2de zit van deze module is succesvol afgerond!");
                    result = (int)id.Value;
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
            return result; // 0 of de Id van de nieuwe rij
        }

        public BLL.TweedeZitInschrijving SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<BLL.TweedeZitInschrijving> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<BLL.TweedeZitInschrijving> SelectAllByCursistNummer(int cursistNummer)
        {
            throw new NotImplementedException();
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
                            les.Datum = Convert.ToDateTime(result["Datum"]);
                            les.Docent = result["Docent"].ToString();
                            les.Campus = result["Campus"].ToString();
                            les.Lokaal = result["Lokaal"].ToString();
                            les.Module = result["Module"].ToString();
                            les.Aanvangsdatum = Convert.ToDateTime(result["Van"]);
                            les.Einddatum = Convert.ToDateTime(result["Tot"]);
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

        public static List<BLL.LesDavinci> SelectAllByCursistNummerAndDates(int cursistNummer, DateTime begin, DateTime einde)
        {
            List<BLL.LesDavinci> lessenrooster = new List<BLL.LesDavinci>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
                 System.Configuration.ConfigurationManager.
                 ConnectionStrings["MobileCVO"].ToString();

            SqlCommand command = new SqlCommand();

            string sqlString = "grp2_SelectLesDavinci";

            command.Parameters.Add(new SqlParameter("@CursistNummer",
               SqlDbType.Int)).Value = cursistNummer;
            command.Parameters.Add(new SqlParameter("@DateBegin",
               SqlDbType.DateTime)).Value = begin;
            command.Parameters.Add(new SqlParameter("@DateEinde",
               SqlDbType.DateTime)).Value = einde;

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sqlString;
            command.Connection = connection;

            SqlDataReader result;
            try
            {
                connection.Open();

                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.LesDavinci les = new BLL.LesDavinci();
                            les.Cursusnummer = result["Cursusnummer"].ToString();
                            les.Datum = Convert.ToDateTime(result["Datum"]);
                            les.Docent = result["Docent"].ToString();
                            les.Campus = result["Campus"].ToString();
                            les.Lokaal = result["Lokaal"].ToString();
                            les.Module = result["Module"].ToString();
                            les.Aanvangsdatum = Convert.ToDateTime(result["Van"]);
                            les.Einddatum = Convert.ToDateTime(result["Tot"]);
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

    public class Cursist //: MobileCVO.DAL.IDal<BLL.LesDavinci>
    {
        public static BLL.Cursist SelectCursistByCursistNummer(int cursistNummer)
        {
            BLL.Cursist cursist = new BLL.Cursist();
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
            string sqlString = "grp2_SelectCursistByCursistNummer";

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
                            cursist.CursistNummer = cursistNummer;
                            cursist.Voornaam = result["Voornaam"].ToString();
                            cursist.Familienaam = result["Familienaam"].ToString(); 
                            cursist.Email = result["Email"].ToString(); 
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

            return cursist;
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

        public int Insert(BLL.Kalender entity)
        {
            throw new NotImplementedException();
        }

        public BLL.Kalender SelectOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<BLL.Kalender> SelectAll()
        {
            List<BLL.Kalender> feestDagenLijst = new List<BLL.Kalender>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MobileCVO"].ToString();
            SqlCommand command = new SqlCommand();

            String sqlString = "grp2_SelectFeestdagenVersieMo";
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sqlString;
            command.Connection = connection;
            this.message = "Niets te melden";
            SqlDataReader result;

            try
            {
                connection.Open();
                this.message = "De database is klaar";
                using (result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.Kalender feestDag = new BLL.Kalender();
                            feestDag.Schooljaar = result["Schooljaar"].ToString();
                            feestDag.Datum = Convert.ToDateTime(result["Datum"]);
                            feestDag.Omschrijving = result["Omschrijving"].ToString();
                            feestDagenLijst.Add(feestDag);
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
            return feestDagenLijst;
        }

        public List<BLL.Kalender> SelectAllByCursistNummer(int cursistNummer)
        {
            throw new NotImplementedException();
        }
    }

    public class Feestdagen
    {
        public static List<BLL.Kalender> SelectFeestDagen(DateTime Date1, DateTime Date2)
        {
            List<BLL.Kalender> lijstfeestdagen = new List<BLL.Kalender>();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MobileCVO"].ToString();
            SqlCommand com = new SqlCommand();

            String sqlString = "grp2_SelectFeestdagen";
            com.Parameters.Add(new SqlParameter("@Date1",
               SqlDbType.DateTime)).Value = Date1;
            com.Parameters.Add(new SqlParameter("@Date2",
               SqlDbType.DateTime)).Value = Date2;

            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = sqlString;
            com.Connection = con;
            SqlDataReader result;

            try
            {
                con.Open();
                using (result = com.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            BLL.Kalender kalender = new BLL.Kalender();
                            kalender.Datum = Convert.ToDateTime(result["Datum"]);
                            kalender.IdSchooljaar = Convert.ToInt32(result["IdSchooljaar"].ToString());
                            kalender.Omschrijving = result["Omschrijving"].ToString();

                            lijstfeestdagen.Add(kalender);
                        }
                    }
                }
            }

            catch (SqlException e)
            {
                //this.Message = e.Message;
            }
            finally
            {
                con.Close();
            }
            return lijstfeestdagen;
        }
    }
}