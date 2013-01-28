using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelProfil permettant à l'utilisateur de modifier son mot de passe
    /// </summary>
    class PanelProfil : Panel
    {
        private TextBox txtSurname,txtLastname,txtMail,txtNewPw,txtNewPwC,txtCurrentPw;
        private Label lblSurname,lblLastname,lblMail,lblNewPw,lblNewPwC,lblCurrentPw,lblErr, lblErr2;
        private Button btnChgPw;
        private FrmMenu myParent;

        /// <summary>
        /// Constructeur de la classe PanelProfil
        /// </summary>
        /// <param name="myParent">myParent, fenêtre principale de l'application</param>
        public PanelProfil(FrmMenu myParent)
        {
            this.lblErr = new Label();
            this.lblErr2 = new Label();
            this.txtCurrentPw = new TextBox();
            this.lblCurrentPw = new Label();
            this.txtNewPwC = new TextBox();
            this.txtNewPw = new TextBox();
            this.txtMail = new TextBox();
            this.txtLastname = new TextBox();
            this.lblNewPwC = new Label();
            this.lblNewPw = new Label();
            this.lblMail = new Label();
            this.lblLastname = new Label();
            this.lblSurname = new Label();
            this.txtSurname = new TextBox();
            this.myParent = myParent;
            this.btnChgPw = new Button();
            this.SuspendLayout();
            initComponents();
        }

        /// <summary>
        /// Méthode permettant l'initialisation de tous les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initPanel();
            initLblErrs();
            initSurnameComponents();
            initLastnameComponents();
            initMailComponents();
            initCurrentPwComponents();
            initNewPwComponents();
            initNewPwCComponents();
            initBtnChgPw();
            initValues();
        }

        /// <summary>
        /// Méthode permettant l'initialisation du Panel et de ses composants
        /// </summary>
        private void initPanel()
        {
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.lblErr2);
            this.Controls.Add(this.txtCurrentPw);
            this.Controls.Add(this.lblCurrentPw);
            this.Controls.Add(this.txtNewPwC);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.lblNewPwC);
            this.Controls.Add(this.lblNewPw);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.btnChgPw);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlProfil";
            this.Size = new System.Drawing.Size(502, 531);
            this.TabIndex = 0;
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label de message d'erreur
        /// </summary>
        private void initLblErrs()
        { 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(114, 295);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(260, 13);
            this.lblErr.TabIndex = 26;
            this.lblErr.Text = "Erreur sur le nouveau mot de passe ou la confirmation";
            this.lblErr.Visible = false;
            this.lblErr2.AutoSize = true;
            this.lblErr2.ForeColor = System.Drawing.Color.Red;
            this.lblErr2.Location = new System.Drawing.Point(114, 295);
            this.lblErr2.Name = "lblErr";
            this.lblErr2.Size = new System.Drawing.Size(260, 13);
            this.lblErr2.TabIndex = 26;
            this.lblErr2.Text = "8 caractères minimum pour le mot de passe";
            this.lblErr2.Visible = false;
        }
        
        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox pour le mot de passe actuel
        /// </summary>
        private void initCurrentPwComponents()
        { 
            this.txtCurrentPw.Location = new System.Drawing.Point(254, 147);
            this.txtCurrentPw.Name = "txtCurrentPw";
            this.txtCurrentPw.PasswordChar = '*';
            this.txtCurrentPw.ReadOnly = true;
            this.txtCurrentPw.Size = new System.Drawing.Size(120, 20);
            this.txtCurrentPw.TabIndex = 25;
            this.txtCurrentPw.UseSystemPasswordChar = true;
            this.lblCurrentPw.AutoSize = true;
            this.lblCurrentPw.Location = new System.Drawing.Point(124, 150);
            this.lblCurrentPw.Name = "lblCurrentPw";
            this.lblCurrentPw.Size = new System.Drawing.Size(103, 13);
            this.lblCurrentPw.TabIndex = 24;
            this.lblCurrentPw.Text = "Mot de passe actuel";
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox du nouveau mot de passe
        /// </summary>
        private void initNewPwComponents()
        {
            this.lblNewPwC.AutoSize = true;
            this.lblNewPwC.Location = new System.Drawing.Point(124, 211);
            this.lblNewPwC.Name = "lblNewPwC";
            this.lblNewPwC.Size = new System.Drawing.Size(64, 13);
            this.lblNewPwC.TabIndex = 19;
            this.lblNewPwC.Text = "Confirmez-le";
            this.txtNewPw.Location = new System.Drawing.Point(254, 177);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.PasswordChar = '*';
            this.txtNewPw.Size = new System.Drawing.Size(120, 20);
            this.txtNewPw.TabIndex = 22;
            this.txtNewPw.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox pour confirmer le nouveau mot de passe
        /// </summary>
        private void initNewPwCComponents()
        {
            this.lblNewPw.AutoSize = true;
            this.lblNewPw.Location = new System.Drawing.Point(124, 180);
            this.lblNewPw.Name = "lblNewPw";
            this.lblNewPw.Size = new System.Drawing.Size(117, 13);
            this.lblNewPw.TabIndex = 18;
            this.lblNewPw.Text = "Nouveau mot de passe";
            this.txtNewPwC.Location = new System.Drawing.Point(254, 208);
            this.txtNewPwC.Name = "txtNewPwC";
            this.txtNewPwC.PasswordChar = '*';
            this.txtNewPwC.Size = new System.Drawing.Size(120, 20);
            this.txtNewPwC.TabIndex = 23;
            this.txtNewPwC.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox pour l'e-mail
        /// </summary>
        private void initMailComponents()
        {
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(124, 120);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(35, 13);
            this.lblMail.TabIndex = 17;
            this.lblMail.Text = "E-mail";
            this.txtMail.Location = new System.Drawing.Point(254, 117);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(120, 20);
            this.txtMail.TabIndex = 21;
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox pour le prénom
        /// </summary>
        private void initLastnameComponents()
        {
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(124, 89);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(43, 13);
            this.lblLastname.TabIndex = 16;
            this.lblLastname.Text = "Prénom";
            this.txtLastname.Location = new System.Drawing.Point(254, 86);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.ReadOnly = true;
            this.txtLastname.Size = new System.Drawing.Size(120, 20);
            this.txtLastname.TabIndex = 20;
        }

        /// <summary>
        /// Méthode permettant d'initialiser le label et la textbox pour le nom
        /// </summary>
        private void initSurnameComponents()
        {
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(124, 56);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(29, 13);
            this.lblSurname.TabIndex = 15;
            this.lblSurname.Text = "Nom";
            this.txtSurname.Location = new System.Drawing.Point(254, 53);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.ReadOnly = true;
            this.txtSurname.Size = new System.Drawing.Size(120, 20);
            this.txtSurname.TabIndex = 14;

        }

        /// <summary>
        /// Méthode permettant d'initialiser le bouton de validation
        /// </summary>
        private void initBtnChgPw()
        {
            this.btnChgPw.Location = new System.Drawing.Point(254, 234);
            this.btnChgPw.Name = "btnChgPw";
            this.btnChgPw.Size = new System.Drawing.Size(120, 23);
            this.btnChgPw.TabIndex = 27;
            this.btnChgPw.Text = "Valider";
            this.btnChgPw.UseVisualStyleBackColor = true;
            this.btnChgPw.Click += new System.EventHandler(this.btnChgPw_Click);
        }

        /// <summary>
        /// Méthode initialisant les différents champs avec les informations de l'utilisateur
        /// </summary>
        private void initValues()
        {            
            this.txtSurname.Text = User.GetSurname();
            this.txtLastname.Text = User.GetLastname();
            this.txtMail.Text = User.GetMail();
            this.txtCurrentPw.Text = User.GetPassword();
        }
        
        /// <summary>
        /// Méthode appelée lors de la validation du changement du mot de passe
        /// Si le nouveau mot de passe fait plus de 8 caractères et qu'il est identique à la confirmation alors le mot de passe est mis à jour
        /// Sinon un message d'erreur s'affiche
        /// </summary>
        private void btnChgPw_Click(object sender, EventArgs e)
        {
            this.lblErr.Visible = false;
            this.lblErr2.Visible = false;
            if (this.txtNewPw.Text.Length >= 8 && this.txtNewPwC.Text.Length >= 8)
            {
                if (this.txtNewPw.Text == this.txtNewPwC.Text && this.txtNewPw.Text != "" && this.txtNewPwC.Text != "")
                {
                    if (User.UpdatePw(User.GetMail(), this.txtNewPwC.Text))
                    {
                        MessageBox.Show("Mise à jour du mot de passe effectuée");
                        this.Hide();
                        this.Parent.Controls.Remove(this);
                        this.myParent.resetCurrentPannel();
                    }
                }
                else this.lblErr.Visible = true;
            }
            else this.lblErr2.Visible = true;
        }
    }
}

