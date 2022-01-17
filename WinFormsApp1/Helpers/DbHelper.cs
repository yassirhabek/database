using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace WinFormsApp1.Helpers
{
    public class DbHelper
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection connection;

        public DbHelper()
        {
            initialize();
        }

        private void initialize()
        {
            server = "192.168.176.101";
            database = "yassir";
            uid = "student";
            password = "student";

            string connString = "user id=root;host=localhost;database=test";
            /*"SERVER=" + server + ";" + "DATABASE=" +
                        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";*/

            connection = new MySqlConnection(connString);
        }

        public void Insert()
        {
            string query = "INSERT INTO users(UID, Username, Password) VALUES(1, yassirhabek, vredeoord123)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("succesvol ingevoerd");
                this.closeConnection();
            }
            else
            {
                MessageBox.Show("er is iets verkankerd, ik weet ook niet wat");
            }
        }

        public void Delete()
        {

        }

        public void Update()
        {

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
