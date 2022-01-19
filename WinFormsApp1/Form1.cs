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
    public partial class PanelSideMenu : Form
    {
        DbHelper helper = new DbHelper();

        public PanelSideMenu()
        {
            InitializeComponent();
            changeSubmenuView();
        }

        private void werknemersToevoegenBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(DropdownPanel);
        }

        private void WerknemerToevoegenbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new WerknemerToevoegen());
        }

        private void WerknemerAanpassenbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new WerknemerAanpassen());
        }

        private void changeSubmenuView()
        {
            DropdownPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (DropdownPanel.Visible == true)
                DropdownPanel.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childPanel.Controls.Add(childForm);
            childPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
