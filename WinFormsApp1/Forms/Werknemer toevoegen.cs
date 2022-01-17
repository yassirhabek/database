using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Forms
{
    public partial class WerknemerToevoegen : Form
    {
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
                    
                }
            }
        }
    }
}
