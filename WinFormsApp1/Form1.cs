using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        readonly DbHelper helper = new DbHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper.Insert();
        }
    }
}
