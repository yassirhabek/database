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
    public partial class WerknemerToevoegen : Form
    {
        DbHelper helper = new DbHelper();
        public int WerknemerNummer { get; set; }
        public string Naam { get; set; }
        

        public WerknemerToevoegen()
        {
            InitializeComponent();
            List<Werknemer> lijstWerknemers = new List<Werknemer>();
            lijstWerknemers = helper.GetAllWerknemers(); 

            for (int i = 0; i < lijstWerknemers.Count; i++)
            {
                listBox1.Items.Add(lijstWerknemers[i].Naam);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addWerknemerToDatabase();
        }

        private void addWerknemerToDatabase()
        {
            if (textBox1 == null)
            {
                MessageBox.Show("Werknemer ID niet ingevuld!");
                return;
            }

            if (textBox2 == null)
            {
                MessageBox.Show("Werknemer naam niet ingevuld!");
                return;
            }

            if (textBox3 == null)
            {
                MessageBox.Show("Telefoonnummer niet ingevuld!");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int werknemerID))
            {
                MessageBox.Show("Geen geldig nummer ingevoerd!");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int telefoonNummer))
            {
                MessageBox.Show("Geen geldig telefoonnummer ingevoerd!");
                return;
            }

            string werknemerNaam = textBox2.Text.ToString();

            Werknemer werknemerNieuw = new Werknemer(werknemerID, werknemerNaam, telefoonNummer);

            helper.AddNewWerknemer(werknemerNieuw);
        }
    
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
