using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelCreerTicket permettant à l'utilisateur de créer un ticket d'incident
    /// </summary>
    class PanelCreerTicket : Panel
    {
        private Label lblTitre,lblNom,lblContenu,lblDate,lblCat,lblPrio, lblErr;
        private TextBox txtNom;
        private RichTextBox rtxtContenu;
        private Button btnValider;
        private DateTimePicker dTPDate;
        private ListBox listPrio,listCat;
        private FrmMenu myParent;
        private Ticket myTicket;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="myParent">myParent, fenêtre principale de l'application</param>
        public PanelCreerTicket(FrmMenu myParent)
        {
            this.lblTitre = new Label();
            this.txtNom = new TextBox();
            this.lblNom = new Label();
            this.lblContenu = new Label();
            this.lblDate = new Label();
            this.lblCat = new Label();
            this.rtxtContenu = new RichTextBox();
            this.btnValider = new Button();
            this.dTPDate = new DateTimePicker();
            this.lblPrio = new Label();
            this.listPrio = new ListBox();
            this.listCat = new ListBox();
            this.lblErr = new Label();
            this.myParent = myParent;
            this.myTicket = new Ticket();
            this.SuspendLayout();
            initComponents();
        }

        /// <summary>
        /// Méthode initialisant les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initPanel();
            initLblTitre();
            initNomComponents();
            initContenuComponents();
            initDateComponents();
            initBtnValider();
            initPrioComponents();
            initCatComponents();
            initLblErr();
        }

        /// <summary>
        /// Méthode initialisant le Panel
        /// </summary>
        private void initPanel()
        {
            this.Controls.Add(this.listPrio);
            this.Controls.Add(this.listCat);
            this.Controls.Add(this.lblPrio);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.rtxtContenu);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblContenu);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.dTPDate);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.lblErr);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlCreerTicket";
            this.Size = new System.Drawing.Size(502, 531);
            this.TabIndex = 0;
        }

        /// <summary>
        /// Méthode initialisant le label servant de titre
        /// </summary>
        private void initLblTitre()
        {
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(241, 25);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(79, 13);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Création Ticket";
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du nom
        /// </summary>
        private void initNomComponents()
        {
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(118, 65);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(64, 13);
            this.lblNom.TabIndex = 6;
            this.lblNom.Text = "Nom ticket :";
            this.txtNom.Location = new System.Drawing.Point(190, 62);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 20);
            this.txtNom.TabIndex = 4;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du contenu
        /// </summary>
        private void initContenuComponents()
        {
            this.lblContenu.AutoSize = true;
            this.lblContenu.Location = new System.Drawing.Point(118, 91);
            this.lblContenu.Name = "lblContenu";
            this.lblContenu.Size = new System.Drawing.Size(53, 13);
            this.lblContenu.TabIndex = 7;
            this.lblContenu.Text = "Contenu :";
            this.rtxtContenu.Location = new System.Drawing.Point(190, 88);
            this.rtxtContenu.Name = "rtxtContenu";
            this.rtxtContenu.Size = new System.Drawing.Size(200, 96);
            this.rtxtContenu.TabIndex = 11;
            this.rtxtContenu.Text = "";
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox de la date
        /// </summary>
        private void initDateComponents()
        {
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(120, 196);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date :";
            this.dTPDate.Location = new System.Drawing.Point(190, 190);
            this.dTPDate.Name = "dTPDate";
            this.dTPDate.Size = new System.Drawing.Size(200, 20);
            this.dTPDate.TabIndex = 3;
            this.dTPDate.Value = DateTime.Now;
            this.dTPDate.Enabled = false;
        }
        
        /// <summary>
        /// Méthode initialisant le bouton de validation
        /// </summary>
        private void initBtnValider()
        {
            this.btnValider.Location = new System.Drawing.Point(245, 431);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 14;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
        }

        /// <summary>
        /// Méthode initialisant le label et la liste de la priorité
        /// </summary>
        private void initPrioComponents()
        {
            this.lblPrio.AutoSize = true;
            this.lblPrio.Location = new System.Drawing.Point(118, 317);
            this.lblPrio.Name = "lblPrio";
            this.lblPrio.Size = new System.Drawing.Size(48, 13);
            this.lblPrio.TabIndex = 15;
            this.lblPrio.Text = "Priorité : ";
            this.listPrio.Items.AddRange(new object[] { "Basse", "Moyenne", "Haute" });
            this.listPrio.Location = new System.Drawing.Point(190, 317);
            this.listPrio.Name = "listPrio";
            this.listPrio.Size = new System.Drawing.Size(200, 95);
            this.listPrio.TabIndex = 17;
            this.listPrio.SelectedIndexChanged += new System.EventHandler(this.listPriorite_SelectedIndexChanged);
        }

        /// <summary>
        /// Méthode initialisant le label et la liste de la catégorie
        /// </summary>
        private void initCatComponents()
        {
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(120, 216);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(58, 13);
            this.lblCat.TabIndex = 9;
            this.lblCat.Text = "Catégorie :";
            this.listCat.FormattingEnabled = true;
            this.listCat.Items.AddRange(new object[] { "Poste", "Imprimante", "Autre matériels", "Windows", "Bureautique", "Autre logiciels" });
            this.listCat.Location = new System.Drawing.Point(190, 216);
            this.listCat.Name = "listCat";
            this.listCat.Size = new System.Drawing.Size(200, 95);
            this.listCat.TabIndex = 16;
            this.listCat.SelectedIndexChanged += new System.EventHandler(this.listCategorie_SelectedIndexChanged);
        }

        /// <summary>
        /// Méthode initialisant le label correspondant au message d'erreur
        /// </summary>
        private void initLblErr()
        {
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(206, 415);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(169, 13);
            this.lblErr.TabIndex = 18;
            this.lblErr.Text = "Tous les champs sont obligatoires.";
            this.lblErr.Visible = false;
        }

        /// <summary>
        /// Méthode attribuant la catégorie au ticket lors de la sélection
        /// </summary>
        private void listCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Récupération de la valeur de la liste catégorie en fonction du choix de l'user
            if (this.listCat.SelectedItem as String == "Poste") this.myTicket.SetIdCategorie(1);
            else if (this.listCat.SelectedItem as String == "Imprimante") this.myTicket.SetIdCategorie(2);
            else if (this.listCat.SelectedItem as String == "Autre matériels") this.myTicket.SetIdCategorie(3);
            else if (this.listCat.SelectedItem as String == "Windows") this.myTicket.SetIdCategorie(4);
            else if (this.listCat.SelectedItem as String == "Bureautique") this.myTicket.SetIdCategorie(5);
            else if (this.listCat.SelectedItem as String == "Autre logiciels") this.myTicket.SetIdCategorie(6);
        }

        /// <summary>
        /// Méthode attribuant la priorité au ticket lors de la sélection
        /// </summary>
        private void listPriorite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Récupération de la valeur de la liste priorité en fonction du choix de l'user
            if (this.listPrio.SelectedItem as String == "Basse") this.myTicket.SetIdPrio(1);
            else if (this.listPrio.SelectedItem as String == "Moyenne") this.myTicket.SetIdPrio(2);
            else if (this.listPrio.SelectedItem as String == "Haute") this.myTicket.SetIdPrio(3);
        }

        /// <summary>
        /// Méthode permettant l'insertion du ticket si tous les champs sont remplis
        /// Sinon affiche un message d'erreur
        /// </summary>
        private void btnValider_Click(object sender, EventArgs e)
        {
            this.lblErr.Visible = false;
            if (this.myTicket.GetTitre() != "" && this.myTicket.GetContenu() != "" && this.myTicket.GetIdCategorie() != 0 && this.myTicket.GetIdPrio() != 0)
            {
                this.myTicket.SetTitre(this.txtNom.Text);
                this.myTicket.SetContenu(this.rtxtContenu.Text);
                this.myTicket.SetDate(dTPDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                this.myTicket.SetIdUser(User.GetId());
                if (myTicket.InsertTicket())
                {
                    MessageBox.Show("Ticket ajouté");
                    this.Hide();
                    this.Parent.Controls.Remove(this);
                    this.myParent.resetCurrentPannel();
                }
            }
            else this.lblErr.Visible = true;
        }
    }
}
