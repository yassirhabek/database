using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
    public partial class WerknemerAanpassen : Form
    {
        DbHelper helper = new DbHelper();

        public WerknemerAanpassen()
        {
            InitializeComponent();
            List<Werknemer> lijstWerknemers = new List<Werknemer>();
            lijstWerknemers = helper.GetAllWerknemers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WerknemerVerwijderen_Load(object sender, EventArgs e)
        {

        }
    }
}
