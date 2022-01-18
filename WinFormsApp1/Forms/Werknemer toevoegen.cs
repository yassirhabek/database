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
            if (textBox1 != null)
            {
                if (textBox2 != null)
                {
                    int werknemerID;

                    if (int.TryParse(textBox1.Text, out werknemerID))
                    {
                        string werknemerNaam = textBox2.Text.ToString();

                        Werknemer werknemerNieuw = new Werknemer(werknemerID, werknemerNaam);

                        helper.nieuwWerknemerToevoegen(werknemerNieuw);
                    }
                    else
                    {
                        //parsing failed. 
                    }
                    
                }
                else
                {
                    MessageBox.Show("Werknemer naam niet ingevuld!");
                }
            }
            else
            {
                MessageBox.Show("Werknemer ID niet ingevuld!");
            }
        }
    }
}
