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
    /// <summary>
    /// Classe FrmMenu correspondant à la fenêtre principale de l'application
    /// </summary>
    public partial class FrmMenu : Form
    {
        private PanelConnexion myCnx;
        private PanelProfil myProfil;
        private PanelMdpOublie myForgetPw;
        private PanelCreerTicket myCreateTicket;
        private PanelHistoTicket myHistoTicket;
        private String currentPanel;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public FrmMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode permettant d'afficher des menus lorsque l'utilisateur est connecté
        /// </summary>
        public void enableMenu()
        {
            this.ticketDincidentToolStripMenuItem.Visible = true;
            this.déconnexionToolStripMenuItem.Visible = true;
            this.profilToolStripMenuItem.Visible = true;
            this.connexionToolStripMenuItem.Visible = false;
            this.aideToolStripMenuItem.Visible = false;
        }

        /// <summary>
        /// Méthode permettant de réinitialiser l'attribut currentPanel
        /// </summary>
        public void resetCurrentPannel() { this.currentPanel = ""; }

        /// <summary>
        /// Méthode permettant de cacher des menus lorsque l'utilisateur est déconnecté
        /// </summary>
        private void disableMenu()
        {
            this.ticketDincidentToolStripMenuItem.Visible = false;
            this.déconnexionToolStripMenuItem.Visible = false;
            this.profilToolStripMenuItem.Visible = false;
            this.connexionToolStripMenuItem.Visible = true;
            this.aideToolStripMenuItem.Visible = true;
        }

        /// <summary>
        /// Méthode permettant l'affichage du formulaire de connexion
        /// </summary>
        private void connexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.pnlContainer.Controls.Contains(this.myCnx))
            {
                this.myCnx = new PanelConnexion(this);
                this.pnlContainer.Controls.Add(this.myCnx);
            }
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlCnx") != 0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlCnx";
            this.pnlContainer.Controls.Find("pnlCnx", true)[0].Show();
        }

        /// <summary>
        /// Méthode permettant l'affichage du formulaire pour la modification du mot de passe
        /// </summary>
        private void modifierMotDePasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.pnlContainer.Controls.Contains(this.myProfil))
            {
                this.myProfil = new PanelProfil(this);
                this.pnlContainer.Controls.Add(this.myProfil);
            }
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlProfil") != 0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlProfil";
            this.pnlContainer.Controls.Find("pnlProfil", true)[0].Show();
        }

        /// <summary>
        /// Méthode permettant la déconnexion de l'utilisateur
        /// </summary>
        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            User.ResetUser();
            this.disableMenu();
            this.currentPanel = "";
            MessageBox.Show("Déconnexion effectuée");
        }

        /// <summary>
        /// Méthode permettant de quitter complètement l'application
        /// </summary>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Méthode permettant l'affichage du formulaire pour le mot de passe oublié
        /// </summary>
        private void motDePasseOubliéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.pnlContainer.Controls.Contains(this.myForgetPw))
            {
                this.myForgetPw = new PanelMdpOublie(this);
                this.pnlContainer.Controls.Add(this.myForgetPw);
            }
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlMdpOublie")!=0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlMdpOublie";
            this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Show();
        }

        /// <summary>
        /// Méthode permettant l'affichage du formulaire de création d'un ticket d'incident
        /// </summary>
        private void créerUnTicketDincidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.pnlContainer.Controls.Contains(this.myCreateTicket))
            {
                this.myCreateTicket = new PanelCreerTicket(this);
                this.pnlContainer.Controls.Add(this.myCreateTicket);
            }
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlCreerTicket") != 0)
                this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            this.currentPanel = "pnlCreerTicket";
            this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Show();
        }

        /// <summary>
        /// Méthode permettant l'affichage de l'historique des tickets d'incident
        /// </summary>
        private void suivreUnTicketDincidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.currentPanel) && this.currentPanel.CompareTo("pnlHistoTicket") != 0) this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Hide();
            if (this.pnlContainer.Controls.Contains(this.myHistoTicket)) this.pnlContainer.Controls.Remove(this.myHistoTicket);
            this.myHistoTicket = new PanelHistoTicket();
            this.pnlContainer.Controls.Add(this.myHistoTicket);
            this.currentPanel = "pnlHistoTicket";
            this.pnlContainer.Controls.Find(this.currentPanel, true)[0].Show();
        }
    }
}
