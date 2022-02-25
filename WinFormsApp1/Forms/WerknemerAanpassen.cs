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
    public partial class WerknemerAanpassen : Form
    {
        DbHelper helper = new DbHelper();
        List<Werknemer> lijstWerknemers = new List<Werknemer>();

        public WerknemerAanpassen()
        {
            InitializeComponent();
            lijstWerknemers = helper.GetAllWerknemers();
            string[] werknemers = lijstWerknemers.Select(x => x.Naam).ToArray();

            comboBox1.Items.AddRange(werknemers);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WerknemerVerwijderen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBoxToString(comboBox1);
            int newID = Convert.ToInt32(textBox1.Text);
            string newNaam = textBox2.Text.ToString();
            int newTel = Convert.ToInt32(textBox3.Text);

            Werknemer changeWerknemer = new Werknemer(newID, newNaam, newTel);

            helper.ChangeWerknemerData(changeWerknemer, selected);
            this.Refresh();
        }

        private string comboBoxToString(ComboBox comboBox)
        {
            string selected = comboBox.GetItemText(comboBox.SelectedItem);
            return selected;
        }


    }
}
