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
    public partial class RouteAanpassen : Form
    {
        DbHelper helper = new DbHelper();
        List<Werknemer> lijstWerknemers = new List<Werknemer>();
        List<Route> routes = new List<Route>();

        public RouteAanpassen()
        {
            InitializeComponent();

            lijstWerknemers = helper.GetAllWerknemers();
            string[] werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string datum = Convert.ToString(monthCalendar1.SelectionStart);
            routes = helper.GetRouteFromDate(datum, lijstWerknemers);
            string[] gekozenRoutes = routes.Select(r => r.Chauffeur.Naam).ToArray();

            comboBox1.Items.AddRange(gekozenRoutes);
        }
    }
}
