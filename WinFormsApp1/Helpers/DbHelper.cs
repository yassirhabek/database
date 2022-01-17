using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Helpers
{
    public class DbHelper
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DbHelper()
        {
            initialize();
        }

        private void initialize()
        {
            server = "studmysql01.fhict.local";
            database = "dbi485050";
            uid = "dbi485050";
            password = "Vredeoord123";

            string connString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection connection = new MySqlConnection(connString);
        }

        public void Insert()
        {
            string query = "INSERT INTO users(UID, username, password) VALUES (0, yassirhabek, vredeoord123)";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
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
