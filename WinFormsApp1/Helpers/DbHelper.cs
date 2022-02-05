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
            string query = "INSERT INTO werknemers(WerknemerID, Naam, aantal_uur) VALUES(@id, @naam, @anu)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = werknemerNieuw.WerknemerID;
                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = werknemerNieuw.Naam;
                cmd.Parameters.Add("@anu", MySqlDbType.Float).Value = werknemerNieuw.AantalUren;

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

        public void ChangeWerknemerData(string newNaam, string NewID, string searchNaam)
        {
            string query = "UPDATE werknemers SET Naam = @naam, WerknemerID = @id WHERE Naam = @snaam";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = newNaam;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = NewID;
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
                            AantalUren = Convert.ToDouble(rdr[2])
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
            if (this.openConnection())
            {
                string query = "SELECT * FROM route WHERE Datum=@datum";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@datum", MySqlDbType.VarChar).Value = date;

                MySqlDataReader rdr = cmd.ExecuteReader();

                try
                {
                    while (rdr.Read())
                    {
                        output.Add(new Route()
                        {
                            RouteNummer = Convert.ToInt32(rdr[0]),
                            Datum = Convert.ToDateTime(rdr[1]),
                            Chauffeur = lijstWerknemers.FirstOrDefault(w => w.Naam == rdr[2]),
                            BijRijder = lijstWerknemers.FirstOrDefault(w => w.Naam == rdr[3]),
                            StartTijd = TimeSpan.Parse(Convert.ToString(rdr[4])),
                            EindTijd = TimeSpan.Parse(Convert.ToString(rdr[5])),
                            AantalUur = TimeSpan.Parse(Convert.ToString(rdr[6])),
                            Bijzonderheden = Convert.ToString(rdr[7])
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

