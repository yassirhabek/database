using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
    public partial class RouteToevoegen : Form
    {
        DbHelper helper = new DbHelper();

        public RouteToevoegen()
        {
            InitializeComponent();

            List<Werknemer> lijstWerknemers = new List<Werknemer>();
            lijstWerknemers = helper.GetAllWerknemers();
            string[] werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();

            comboBox1.Items.AddRange(werknemers);
            comboBox2.Items.AddRange(werknemers);
        }       
        
        private void button1_Click(object sender, EventArgs e)
        {
            int routeNummer = Convert.ToInt32(textBox1.Text.ToString());
            string chauffeur = comboBox1.Text.ToString();
            string bijrijder = comboBox2.Text.ToString();
            
        }        
        
        private string comboBoxToString(ComboBox comboBox)
        {
            string selected = comboBox.GetItemText(comboBox.SelectedItem);
            return selected;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Toevoegen(object sender, EventArgs e)
        {

        }


    }
}
