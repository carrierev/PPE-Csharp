using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelDetailsTicket affichant les détails d'un ticket précis
    /// </summary>
    public partial class PanelDetailsTicket : Panel
    {
        private Label lblTitre,lblNom,lblContenu,lblDate,lblCat,lblPrio,lblEtat;
        private RichTextBox rtxtContenu;
        private TextBox txtNom, txtDate, txtCat, txtPrio, txtEtat;
        private Button btnFermer;
        private Ticket monTicket;

        /// <summary>
        /// Constructeurs de la classe
        /// </summary>
        /// <param name="id">id, identifiant du ticket</param>
        public PanelDetailsTicket(int id)
        {
            this.lblTitre = new Label();
            this.txtNom = new TextBox();
            this.lblNom = new Label();
            this.lblContenu = new Label();
            this.lblDate = new Label();
            this.lblCat = new Label();
            this.lblPrio = new Label();
            this.rtxtContenu = new RichTextBox();
            this.txtDate = new TextBox();
            this.txtCat = new TextBox();
            this.txtPrio = new TextBox();
            this.lblEtat = new Label();
            this.txtEtat = new TextBox();
            this.btnFermer = new Button();
            this.monTicket = new Ticket();
            this.monTicket.GetTicket(id);
            this.SuspendLayout();
            initComponents();
        }

        /// <summary>
        /// Méthode initialisant les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initPanel();
            initLblTitle();
            initNomComponents();
            initContenuComponents();
            initDateComponents();
            initStatutComponents();
            initPrioComponents();
            initCatComponents();
            initBtnFermer();
        }

        /// <summary>
        /// Méthode initialisant le Panel
        /// </summary>
        private void initPanel()
        {
            this.BackColor = System.Drawing.Color.Gray;
            this.Size = new System.Drawing.Size(502, 531);
            this.Controls.Add(this.txtEtat);
            this.Controls.Add(this.lblEtat);
            this.Controls.Add(this.txtPrio);
            this.Controls.Add(this.txtCat);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.rtxtContenu);
            this.Controls.Add(this.lblPrio);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblContenu);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnFermer);
            this.Name = "pnlDetailsTicket";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Méthode initialisant le label servant de titre
        /// </summary>
        private void initLblTitle()
        {
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(241, 24);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(83, 13);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Détails du ticket";
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du nom
        /// </summary>
        private void initNomComponents()
        {
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(106, 55);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(64, 13);
            this.lblNom.TabIndex = 6;
            this.lblNom.Text = "Nom ticket :";
            this.txtNom.Location = new System.Drawing.Point(187, 52);
            this.txtNom.Name = "txtNom";
            this.txtNom.Text = this.monTicket.GetTitre();
            this.txtNom.ReadOnly = true;
            this.txtNom.Size = new System.Drawing.Size(200, 20);
            this.txtNom.TabIndex = 4;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du contenu
        /// </summary>
        private void initContenuComponents()
        {
            this.lblContenu.AutoSize = true;
            this.lblContenu.Location = new System.Drawing.Point(117, 81);
            this.lblContenu.Name = "lblContenu";
            this.lblContenu.Size = new System.Drawing.Size(53, 13);
            this.lblContenu.TabIndex = 7;
            this.lblContenu.Text = "Contenu :";
            this.rtxtContenu.Location = new System.Drawing.Point(187, 78);
            this.rtxtContenu.Name = "rtxtContenu";
            this.rtxtContenu.ReadOnly = true;
            this.rtxtContenu.Size = new System.Drawing.Size(200, 96);
            this.rtxtContenu.TabIndex = 11;
            this.rtxtContenu.Text = this.monTicket.GetContenu();
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox de la date
        /// </summary>
        private void initDateComponents()
        {
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(134, 183);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date :";
            this.txtDate.Location = new System.Drawing.Point(187, 180);
            this.txtDate.Name = "txtDate";
            this.txtDate.Text = this.monTicket.GetDate();
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(200, 20);
            this.txtDate.TabIndex = 14;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox de la catégorie
        /// </summary>
        private void initCatComponents()
        {
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(112, 209);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(58, 13);
            this.lblCat.TabIndex = 9;
            this.lblCat.Text = "Catégorie :";
            this.txtCat.Location = new System.Drawing.Point(187, 206);
            this.txtCat.Name = "txtCat";
            this.txtCat.Text = this.monTicket.GetCategorie();
            this.txtCat.ReadOnly = true;
            this.txtCat.Size = new System.Drawing.Size(200, 20);
            this.txtCat.TabIndex = 15;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox de la priorité
        /// </summary>
        private void initPrioComponents()
        {
            this.lblPrio.AutoSize = true;
            this.lblPrio.Location = new System.Drawing.Point(125, 235);
            this.lblPrio.Name = "lblPrio";
            this.lblPrio.Size = new System.Drawing.Size(45, 13);
            this.lblPrio.TabIndex = 10;
            this.lblPrio.Text = "Priorité :";
            this.txtPrio.Location = new System.Drawing.Point(187, 232);
            this.txtPrio.Name = "txtPrio";
            this.txtPrio.Text = this.monTicket.GetPriorite(); ;
            this.txtPrio.ReadOnly = true;
            this.txtPrio.Size = new System.Drawing.Size(200, 20);
            this.txtPrio.TabIndex = 16;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox de l'état
        /// </summary>
        private void initStatutComponents()
        {
            this.lblEtat.AutoSize = true;
            this.lblEtat.Location = new System.Drawing.Point(138, 261);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(32, 13);
            this.lblEtat.TabIndex = 17;
            this.lblEtat.Text = "Etat :";
            this.txtEtat.Location = new System.Drawing.Point(187, 258);
            this.txtEtat.Name = "txtEtat";
            this.txtEtat.Text = this.monTicket.GetStatut();
            this.txtEtat.ReadOnly = true;
            this.txtEtat.Size = new System.Drawing.Size(200, 20);
            this.txtEtat.TabIndex = 18;
        }

        /// <summary>
        /// Méthode initialisant le bouton servant à fermer le panel
        /// </summary>
        private void initBtnFermer()
        {
            this.btnFermer.Location = new System.Drawing.Point(249, 284);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(75, 23);
            this.btnFermer.TabIndex = 19;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btsFermer_Click);
        }

        /// <summary>
        /// Méthode appelé fermant le panel
        /// </summary>
        private void btsFermer_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = false;
            this.Parent.Controls.Remove(this);
        }
    }
}
