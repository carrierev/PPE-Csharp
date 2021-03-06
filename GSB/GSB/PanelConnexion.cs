﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelConnexion permettant à l'utilisateur de se connecter
    /// </summary>
    class PanelConnexion : Panel
    {
        private Label lblErr,lblPw,lblMail;
        private TextBox txtPw,txtMail;
        private Button btnCnx;
        private FrmMenu myParent;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="myParent">myParent, fenêtre principale de l'application</param>
        public PanelConnexion(FrmMenu myParent)
        {
            this.myParent = myParent;
            this.lblErr = new Label();
            this.btnCnx = new Button();
            this.txtPw = new TextBox();
            this.txtMail = new TextBox();
            this.lblPw = new Label();
            this.lblMail = new Label();
            this.SuspendLayout();
            initComponents();
        }

        /// <summary>
        /// Méthode initialisant tous les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initPanel();
            initLblErr();
            initMailComponents();
            initPwComponents();
            initBtnCnx();
        }

        /// <summary>
        /// Méthode initialisant le Panel
        /// </summary>
        private void initPanel()
        {
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnCnx);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.lblMail);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlCnx";
            this.Size = new System.Drawing.Size(502, 531);
            this.TabIndex = 6;
        }

        /// <summary>
        /// Méthode initialisant le label servant de message d'erreur
        /// </summary>
        private void initLblErr()
        {
            
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(27, 158);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(238, 13);
            this.lblErr.TabIndex = 11;
            this.lblErr.Text = "L'adresse e-mail ou le mot de passe est incorrect.";
            this.lblErr.Visible = false;
        }

        /// <summary>
        /// Méthode initialisant le bouton de connexion
        /// </summary>
        private void initBtnCnx()
        {
            this.btnCnx.Location = new System.Drawing.Point(153, 114);
            this.btnCnx.Name = "btnCnx";
            this.btnCnx.Size = new System.Drawing.Size(76, 23);
            this.btnCnx.TabIndex = 10;
            this.btnCnx.Text = "Connexion";
            this.btnCnx.UseVisualStyleBackColor = true;
            this.btnCnx.Click += new System.EventHandler(this.btnCnx_Click);
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du mot de passe
        /// </summary>
        private void initPwComponents()
        {
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(48, 96);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(71, 13);
            this.lblPw.TabIndex = 7;
            this.lblPw.Text = "Mot de passe";
            this.txtPw.Location = new System.Drawing.Point(128, 88);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(101, 20);
            this.txtPw.TabIndex = 9;
            this.txtPw.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Méthode initialisant le label et la textbox du mail
        /// </summary>
        private void initMailComponents()
        {
            this.txtMail.Location = new System.Drawing.Point(128, 60);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 8;
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(47, 68);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(35, 13);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "E-mail";
        }

        /// <summary>
        /// Méthode permettant la connexion
        /// Si le mot de passe et le mail correspondent bien, l'utilisateur est connecté
        /// Sinon un message d'erreur s'affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCnx_Click(object sender, EventArgs e)
        {
            Boolean connected = false;
            if (this.txtMail.Text != "" && this.txtPw.Text != "")
            {
                if (User.CheckUser(this.txtMail.Text.ToLower(), this.txtPw.Text))
                {
                    connected = true;
                    MessageBox.Show("Connexion effectuée");
                    this.Hide();
                    this.Parent.Controls.Remove(this);
                    this.myParent.resetCurrentPannel();
                    this.myParent.enableMenu();
                }
            }
            if (!connected) lblErr.Visible = true;
        }
    }
}
