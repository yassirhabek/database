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

        public void nieuwWerknemerToevoegen(Werknemer werknemerNieuw)
        {
            string query = "INSERT INTO werknemers(WerknemerID, Naam, aantal_uur) VALUES(@id, @naam, @anu)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = werknemerNieuw.WerknemerID;
                cmd.Parameters.Add("@naam", MySqlDbType.Text).Value = werknemerNieuw.Naam;
                cmd.Parameters.Add("@anu", MySqlDbType.Float).Value = werknemerNieuw.AantalUren;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesvol Werknemer Toegevoegd!");
                this.closeConnection();
            }
            else
            {
                MessageBox.Show("Werknemer Toevoegen gefaald! Neem contact op met de administrator.");
            }
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
                            AantalUren = Convert.ToDouble(rdr[2]),
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
