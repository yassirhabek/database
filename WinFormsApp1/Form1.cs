using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DbHelper helper = new DbHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WerknemerToevoegen werknemerToevoegen = new WerknemerToevoegen();
            werknemerToevoegen.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Werknemer> lijstWerknemers = new List<Werknemer>();
            lijstWerknemers = helper.GetAllWerknemers();

            foreach (Werknemer werknemer in lijstWerknemers)
            {
                label2.Text = Convert.ToString(werknemer);
            }
        }
    }
}
