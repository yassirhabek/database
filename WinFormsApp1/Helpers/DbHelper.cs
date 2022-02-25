using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using WinFormsApp1.Models;

namespace WinFormsApp1.Helpers
{
    public class DbHelper
    { 
        private MySqlConnection connection;
        private readonly string connString = "user id=root;host=localhost;database=test";

        public DbHelper()
        {
            initialize();
        }

        private void initialize()
        {
            connection = new MySqlConnection(connString);
        }

        #region Werknemer
        public void AddNewWerknemer(Werknemer werknemerNieuw)
        {
            string query = "INSERT INTO werknemers(WerknemerID, Naam, Telefoonnummer) VALUES(@id, @naam, @tel)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = werknemerNieuw.WerknemerID;
                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = werknemerNieuw.Naam;
                cmd.Parameters.Add("@tel", MySqlDbType.Int32).Value = werknemerNieuw.TelefoonNummer;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesvol Werknemer Toegevoegd!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.closeConnection();
            }
            else
            {
                MessageBox.Show("Werknemer Toevoegen gefaald! Neem contact op met de administrator.");
            }
        }

        public void ChangeWerknemerData(Werknemer changeWerknemer, string searchNaam)
        {
            string query = "UPDATE werknemers SET Naam = @naam, WerknemerID = @id, Telefoonnummer = @tel WHERE Naam = @snaam";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = changeWerknemer.Naam;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = changeWerknemer.WerknemerID;
                cmd.Parameters.Add("@tel", MySqlDbType.Int32).Value = changeWerknemer.TelefoonNummer;
                cmd.Parameters.Add("@snaam", MySqlDbType.Text).Value = searchNaam;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesvol Aangepast!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.closeConnection();
            }
            else
            {
                MessageBox.Show("Werknemer Aanpassen gefaald! Neem contact op met de administrator.");
            }

        }

        public void DeleteWerknemer(string naam)
        {
            string query = "DELETE FROM werknemers WHERE Naam = @naam";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = naam;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesvol Verwijderd");
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Werknemer verwijderen gefaald! Neem contact op met de administrator.");
            }
            closeConnection();

        }

        public List<Werknemer> GetAllWerknemers()
        {
            List<Werknemer> output = new List<Werknemer>();
            if (this.openConnection())
            {
                try
                {
                    string query = "SELECT * FROM werknemers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        output.Add(new Werknemer()
                        {
                            WerknemerID = Convert.ToInt32(rdr[0]),
                            Naam = Convert.ToString(rdr[1]),
                            TelefoonNummer = Convert.ToInt32(rdr[2])
                        });
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            this.closeConnection();
            return output;
        }
        #endregion

        #region Route
        public void AddRoute(Route newRoute)
        {
            string query = "INSERT INTO route (RouteNummer, Datum, Chauffeur, Bijrijder, Starttijd, Eindtijd, AantalUur, Bijzonderheden, DatumToegevoegd) " +
                        "VALUES (@route, @date, @chauf, @bijr, @stijd, @etijd, @aanu, @bijz, @curdate)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@route", MySqlDbType.Int32).Value = newRoute.RouteNummer;
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = newRoute.Datum;
                cmd.Parameters.Add("@chauf", MySqlDbType.Text).Value = newRoute.Chauffeur.Naam;
                cmd.Parameters.Add("@bijr", MySqlDbType.Text).Value = newRoute.BijRijder.Naam;
                cmd.Parameters.Add("@stijd", MySqlDbType.Time).Value = newRoute.StartTijd;
                cmd.Parameters.Add("@etijd", MySqlDbType.Time).Value = newRoute.EindTijd;
                cmd.Parameters.Add("@aanu", MySqlDbType.Time).Value = newRoute.AantalUur;
                cmd.Parameters.Add("@bijz", MySqlDbType.Text).Value = newRoute.Bijzonderheden;
                cmd.Parameters.Add("@curdate", MySqlDbType.DateTime).Value = DateTime.Now;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Route succesvol toegevoegd!");
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            this.closeConnection();

        }


        public List<Route> GetRouteFromDate(string date, List<Werknemer> lijstWerknemers)
        {
            List<Route> output = new List<Route>();

            string searchDate = date.Remove(10);

            if (this.openConnection())
            {
                string query = "SELECT * FROM route WHERE Datum=@datum";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@datum", MySqlDbType.Text).Value = searchDate;

                MySqlDataReader rdr = cmd.ExecuteReader();

                try
                {
                    while (rdr.Read())
                    {
                        output.Add(new Route()
                        {
                            RouteNummer = Convert.ToInt32(rdr[1]),
                            Datum = Convert.ToDateTime(rdr[2]),
                            Chauffeur = lijstWerknemers.FirstOrDefault(w => w.Naam == rdr[3].ToString()),
                            BijRijder = lijstWerknemers.FirstOrDefault(w => w.Naam == rdr[4].ToString()),
                            StartTijd = TimeSpan.Parse(Convert.ToString(rdr[5])),
                            EindTijd = TimeSpan.Parse(Convert.ToString(rdr[6])),
                            AantalUur = TimeSpan.Parse(Convert.ToString(rdr[7])),
                            Bijzonderheden = Convert.ToString(rdr[8])
                        });
                    }
                    rdr.Close();
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            this.closeConnection();
            return output;
        }

        public void UpdateRoute(Route updateRoute, Route oldRoute)
        {
            string oldDateFormat = oldRoute.Datum.ToString().Remove(10);
            string newDateFormat = updateRoute.Datum.ToString().Remove(10);

            string query = "UPDATE route SET RouteNummer= @newroutenum, Datum= @datum, Chauffeur= @chauff, Bijrijder= @bijr," +
                "Starttijd= @startt, Eindtijd= @eindt, AantalUur= @aantaluur, Bijzonderheden =@bijz, DatumToegevoegd= @datumtoeg WHERE RouteNummer = @oldroutenum AND Datum= @oldDatum";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@newroutenum", MySqlDbType.Int32).Value = updateRoute.RouteNummer;
                cmd.Parameters.Add("@datum", MySqlDbType.Text).Value = newDateFormat;
                cmd.Parameters.Add("@chauff", MySqlDbType.Text).Value = updateRoute.Chauffeur.Naam;
                cmd.Parameters.Add("@bijr", MySqlDbType.Text).Value = updateRoute.BijRijder.Naam;
                cmd.Parameters.Add("@startt", MySqlDbType.Time).Value = updateRoute.StartTijd;
                cmd.Parameters.Add("@eindt", MySqlDbType.Time).Value = updateRoute.EindTijd;
                cmd.Parameters.Add("@aantaluur", MySqlDbType.Time).Value = updateRoute.AantalUur;
                cmd.Parameters.Add("@bijz", MySqlDbType.Text).Value = updateRoute.Bijzonderheden;
                cmd.Parameters.Add("@datumtoeg", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@oldroutenum", MySqlDbType.Int32).Value = oldRoute.RouteNummer;
                cmd.Parameters.Add("@oldDatum", MySqlDbType.DateTime).Value = oldDateFormat;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesvol Route Aangepast!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            this.closeConnection();
        }
             
        #endregion

        #region connections
        private bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("kan geen verbinding maken met server. neem contact op met administrator");
                        break;

                    case 1045:
                        MessageBox.Show("ongeldig username/password");
                        break;
                }
                return false;
            }
        }

        private bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

    }
}

