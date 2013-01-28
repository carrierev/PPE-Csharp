using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmMenu : Form
    {
        private PanelConnexion myCnx;
        private PanelProfil myProfil;
        private PanelMdpOublie myForgetPw;
        private String currentPanel;

        public FrmMenu()
        {
            InitializeComponent();
        }

        public void enableMenu()
        {
            this.toolStripSeparator1.Visible = true;
            this.toolStripSeparator2.Visible = true;
            this.toolStripSeparator4.Visible = false;
            this.créerUnTicketDincidentToolStripMenuItem.Visible = true;
            this.déconnexionToolStripMenuItem.Visible = true;
            this.modifierMotDePasseToolStripMenuItem.Visible = true;
            this.suivreUnTicketDincidentToolStripMenuItem.Visible = true;
            this.connexionToolStripMenuItem.Visible = false;
            this.motDePasseOubliéToolStripMenuItem.Visible = false;
        }

        private void disableMenu()
        {
            this.toolStripSeparator1.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.toolStripSeparator4.Visible = true;
            this.créerUnTicketDincidentToolStripMenuItem.Visible = false;
            this.déconnexionToolStripMenuItem.Visible = false;
            this.modifierMotDePasseToolStripMenuItem.Visible = false;
            this.suivreUnTicketDincidentToolStripMenuItem.Visible = false;
            this.connexionToolStripMenuItem.Visible = true;
            this.motDePasseOubliéToolStripMenuItem.Visible = true;
        }

        private void connexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.myCnx == null) this.myCnx = new PanelConnexion(this);
            if (!this.pnlContainer.Controls.Contains(this.myCnx)) this.pnlContainer.Controls.Add(this.myCnx);
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlCnx") != 0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlCnx";
            this.pnlContainer.Controls.Find("pnlCnx", true)[0].Show();
        }

        private void modifierMotDePasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.myProfil == null) this.myProfil = new PanelProfil();
            if (!this.pnlContainer.Controls.Contains(this.myProfil)) this.pnlContainer.Controls.Add(this.myProfil);
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlProfil") != 0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlProfil";
            this.pnlContainer.Controls.Find("pnlProfil", true)[0].Show();
        }

        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            User.ResetUser();
            this.disableMenu();
            MessageBox.Show("Déconnexion effectuée");
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void motDePasseOubliéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.myForgetPw == null) this.myForgetPw = new PanelMdpOublie();
            if (!this.pnlContainer.Controls.Contains(this.myForgetPw)) this.pnlContainer.Controls.Add(this.myForgetPw);
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlMdpOublie")!=0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlMdpOublie";
            this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Show();
        }
    }
}
