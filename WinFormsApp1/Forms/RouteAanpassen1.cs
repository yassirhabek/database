using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
    public partial class RouteAanpassen1 : Form
    {
        DbHelper helper = new DbHelper();
        List<Werknemer> lijstWerknemers = new List<Werknemer>();
        List<Route> routes = new List<Route>();
        public string[] Werknemers;
        public string[] GekozenRoutes;
        public Route AanpassendeRoute;

        public RouteAanpassen1()
        {
            InitializeComponent();

            lijstWerknemers = helper.GetAllWerknemers();
            Werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();
            hideVisibleThingsScreen2();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (comboBox1.Items != null)
            {
                comboBox1.Items.Clear();
            }

            string datum = Convert.ToString(monthCalendar1.SelectionStart);
            routes = helper.GetRouteFromDate(datum, lijstWerknemers);
            GekozenRoutes = routes.Select(r => Convert.ToString(r.RouteNummer)).ToArray();

            comboBox1.Items.AddRange(GekozenRoutes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AanpassendeRoute = routes.FirstOrDefault(w => w.RouteNummer == Convert.ToInt32(comboBox1.Text));
            hideVisibleThingsScreen1();
            showVisibleThingsScreen2();

            addItemsInBoxes(AanpassendeRoute);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int routeNummer = Convert.ToInt32(textBox1.Text);
            DateTime datum = monthCalendar2.SelectionStart;
            Werknemer chauffeur = lijstWerknemers.FirstOrDefault(w => w.Naam == comboBox3.Text);
            Werknemer bijrijder = lijstWerknemers.FirstOrDefault(w => w.Naam == comboBox2.Text);
            TimeSpan startTijd = TimeSpan.Parse(textBox2.Text);
            TimeSpan eindTijd = TimeSpan.Parse(textBox3.Text);
            string bijzonderheden = richTextBox1.Text;

            Route changedRoute = new Route(routeNummer, datum, chauffeur, bijrijder, startTijd, eindTijd, bijzonderheden);

            helper.UpdateRoute(changedRoute, AanpassendeRoute);
        }

        private void hideVisibleThingsScreen1()
        {
            label1.Visible = false;
            label3.Visible = false;
            monthCalendar1.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
        }

        private void showVisibleThingsScreen1()
        {
            label1.Visible = true;
            label3.Visible = true;
            monthCalendar1.Visible = true;
            comboBox1.Visible = true;
            button1.Visible = true;
        }

        private void hideVisibleThingsScreen2()
        {
            textBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            monthCalendar2.Visible = false;
            richTextBox1.Visible = false;
            button2.Visible = false;

            label10.Visible = false;
            label9.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void showVisibleThingsScreen2()
        {
            textBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            monthCalendar2.Visible = true;
            richTextBox1.Visible = true;
            button2.Visible = true;

            label10.Visible = true;
            label9.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
        }


        private void addItemsInBoxes(Route aanpassendeRoute)
        {
            textBox1.Text = aanpassendeRoute.RouteNummer.ToString();

            comboBox3.Text = aanpassendeRoute.Chauffeur.Naam.ToString();
            comboBox3.Items.AddRange(Werknemers);
            comboBox2.Text = aanpassendeRoute.BijRijder.Naam.ToString();
            comboBox2.Items.AddRange(Werknemers);

            textBox2.Text = aanpassendeRoute.StartTijd.ToString();
            textBox3.Text = aanpassendeRoute.EindTijd.ToString();

            richTextBox1.Text = aanpassendeRoute.Bijzonderheden;

            monthCalendar2.SetDate(aanpassendeRoute.Datum);
        }

    }
}
