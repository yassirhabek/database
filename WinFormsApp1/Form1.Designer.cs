
namespace WinFormsApp1
{
    partial class PanelSideMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.DropdownPanel = new System.Windows.Forms.Panel();
            this.WerknemerVerwijderenbtn = new System.Windows.Forms.Button();
            this.WerknemerAanpassenbtn = new System.Windows.Forms.Button();
            this.WerknemerToevoegenbtn = new System.Windows.Forms.Button();
            this.werknemersBtn = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.childPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.DropdownPanel.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(129)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.DropdownPanel);
            this.panel1.Controls.Add(this.werknemersBtn);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 621);
            this.panel1.TabIndex = 3;
            // 
            // DropdownPanel
            // 
            this.DropdownPanel.Controls.Add(this.WerknemerVerwijderenbtn);
            this.DropdownPanel.Controls.Add(this.WerknemerAanpassenbtn);
            this.DropdownPanel.Controls.Add(this.WerknemerToevoegenbtn);
            this.DropdownPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DropdownPanel.Location = new System.Drawing.Point(0, 135);
            this.DropdownPanel.Name = "DropdownPanel";
            this.DropdownPanel.Size = new System.Drawing.Size(250, 125);
            this.DropdownPanel.TabIndex = 8;
            // 
            // WerknemerVerwijderenbtn
            // 
            this.WerknemerVerwijderenbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.WerknemerVerwijderenbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.WerknemerVerwijderenbtn.FlatAppearance.BorderSize = 0;
            this.WerknemerVerwijderenbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WerknemerVerwijderenbtn.ForeColor = System.Drawing.Color.White;
            this.WerknemerVerwijderenbtn.Location = new System.Drawing.Point(0, 82);
            this.WerknemerVerwijderenbtn.Name = "WerknemerVerwijderenbtn";
            this.WerknemerVerwijderenbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.WerknemerVerwijderenbtn.Size = new System.Drawing.Size(250, 41);
            this.WerknemerVerwijderenbtn.TabIndex = 2;
            this.WerknemerVerwijderenbtn.Text = "Werknemer Verwijderen";
            this.WerknemerVerwijderenbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WerknemerVerwijderenbtn.UseVisualStyleBackColor = false;
            // 
            // WerknemerAanpassenbtn
            // 
            this.WerknemerAanpassenbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.WerknemerAanpassenbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.WerknemerAanpassenbtn.FlatAppearance.BorderSize = 0;
            this.WerknemerAanpassenbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WerknemerAanpassenbtn.ForeColor = System.Drawing.Color.White;
            this.WerknemerAanpassenbtn.Location = new System.Drawing.Point(0, 41);
            this.WerknemerAanpassenbtn.Name = "WerknemerAanpassenbtn";
            this.WerknemerAanpassenbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.WerknemerAanpassenbtn.Size = new System.Drawing.Size(250, 41);
            this.WerknemerAanpassenbtn.TabIndex = 1;
            this.WerknemerAanpassenbtn.Text = "Werknemer Aanpassen";
            this.WerknemerAanpassenbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WerknemerAanpassenbtn.UseVisualStyleBackColor = false;
            this.WerknemerAanpassenbtn.Click += new System.EventHandler(this.WerknemerAanpassenbtn_Click);
            // 
            // WerknemerToevoegenbtn
            // 
            this.WerknemerToevoegenbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.WerknemerToevoegenbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.WerknemerToevoegenbtn.FlatAppearance.BorderSize = 0;
            this.WerknemerToevoegenbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WerknemerToevoegenbtn.ForeColor = System.Drawing.Color.White;
            this.WerknemerToevoegenbtn.Location = new System.Drawing.Point(0, 0);
            this.WerknemerToevoegenbtn.Name = "WerknemerToevoegenbtn";
            this.WerknemerToevoegenbtn.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.WerknemerToevoegenbtn.Size = new System.Drawing.Size(250, 41);
            this.WerknemerToevoegenbtn.TabIndex = 0;
            this.WerknemerToevoegenbtn.Text = "Werknemer Toevoegen";
            this.WerknemerToevoegenbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WerknemerToevoegenbtn.UseVisualStyleBackColor = false;
            this.WerknemerToevoegenbtn.Click += new System.EventHandler(this.WerknemerToevoegenbtn_Click);
            // 
            // werknemersBtn
            // 
            this.werknemersBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.werknemersBtn.FlatAppearance.BorderSize = 0;
            this.werknemersBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(37)))), ((int)(((byte)(74)))));
            this.werknemersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.werknemersBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.werknemersBtn.Location = new System.Drawing.Point(0, 85);
            this.werknemersBtn.Name = "werknemersBtn";
            this.werknemersBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.werknemersBtn.Size = new System.Drawing.Size(250, 50);
            this.werknemersBtn.TabIndex = 7;
            this.werknemersBtn.Text = "Werknemers";
            this.werknemersBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.werknemersBtn.UseVisualStyleBackColor = true;
            this.werknemersBtn.Click += new System.EventHandler(this.werknemersToevoegenBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 85);
            this.panelLogo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGO";
            // 
            // childPanel
            // 
            this.childPanel.BackColor = System.Drawing.Color.White;
            this.childPanel.Location = new System.Drawing.Point(245, 0);
            this.childPanel.Name = "childPanel";
            this.childPanel.Size = new System.Drawing.Size(906, 621);
            this.childPanel.TabIndex = 4;
            // 
            // PanelSideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1149, 621);
            this.Controls.Add(this.childPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(1165, 660);
            this.MinimumSize = new System.Drawing.Size(783, 510);
            this.Name = "PanelSideMenu";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.DropdownPanel.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel childPanel;
        private System.Windows.Forms.Button werknemersBtn;
        private System.Windows.Forms.Panel DropdownPanel;
        private System.Windows.Forms.Button WerknemerVerwijderenbtn;
        private System.Windows.Forms.Button WerknemerAanpassenbtn;
        private System.Windows.Forms.Button WerknemerToevoegenbtn;
    }
}

