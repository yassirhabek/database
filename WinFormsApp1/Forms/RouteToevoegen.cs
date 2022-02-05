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
        List<Werknemer> lijstWerknemers = new List<Werknemer>();

        public RouteToevoegen()
        {
            InitializeComponent();

            lijstWerknemers = helper.GetAllWerknemers();
            string[] werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();

            comboBox1.Items.AddRange(werknemers);
            comboBox2.Items.AddRange(werknemers);
        }       
        
        private void button1_Click(object sender, EventArgs e)
        {
            int routeNummer = Convert.ToInt32(textBox1.Text.ToString());
            DateTime datum = Convert.ToDateTime(monthCalendar1.SelectionEnd.ToString());

            string rawChauffeur = comboBox1.Text.ToString();
            Werknemer chauffeur = lijstWerknemers.FirstOrDefault(w => w.Naam == rawChauffeur);
            string rawBijrijder = comboBox2.Text.ToString();
            Werknemer bijrijder = lijstWerknemers.FirstOrDefault(w => w.Naam == rawBijrijder);

            string rawStartTijd = textBox2.Text.ToString();
            TimeSpan startTijd = TimeSpan.Parse(rawStartTijd);

            string rawEindTijd = textBox3.Text.ToString();
            TimeSpan eindTijd = TimeSpan.Parse(rawEindTijd);

            string bijzonderheden = richTextBox1.Text.ToString();
            
            if(bijzonderheden != null)
            {
                Route newRoute = new Route(routeNummer, datum, chauffeur, bijrijder, startTijd, eindTijd, bijzonderheden);
                helper.AddRoute(newRoute);
            }
            else
            {
                Route newRoute = new Route(routeNummer, datum, chauffeur, bijrijder, startTijd, eindTijd);
                helper.AddRoute(newRoute);
            }

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
