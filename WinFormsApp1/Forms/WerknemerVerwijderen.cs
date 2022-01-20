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
    public partial class WerknemerVerwijderen : Form
    {
        DbHelper helper = new DbHelper();
        public WerknemerVerwijderen()
        {
            InitializeComponent();
            List<Werknemer> lijstWerknemers = new List<Werknemer>();
            lijstWerknemers = helper.GetAllWerknemers();
            string[] werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();

            comboBox1.Items.AddRange(werknemers);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string comboBoxToString(ComboBox comboBox)
        {
            string selected = comboBox.GetItemText(comboBox.SelectedItem);
            return selected;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null)
            {
                string naam = comboBoxToString(comboBox1);
                helper.DeleteWerknemer(naam);
            }
            else
            {
                MessageBox.Show("Geen Werknemer gekozen! Kies een Werknemer");
            }
        }
    }
}
