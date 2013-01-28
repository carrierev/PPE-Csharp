using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelMdpOublie permettant à l'utilisateur de récupérer par mail un mot de passe généré aléatoirement 
    /// </summary>
    public class PanelMdpOublie : Panel
    {
        private TextBox txtMail;
        private Label lblMail, lblErr;
        private Button btnValidate;
        private FrmMenu myParent;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="myParent">myParent, fenêtre principale de l'application</param>
        public PanelMdpOublie(FrmMenu myParent)
        {
            this.lblMail = new Label();
            this.txtMail = new TextBox();
            this.btnValidate = new Button();
            this.lblErr = new Label();
            this.myParent = myParent;
            this.SuspendLayout();
            initComponents();
        }

        /// <summary>
        /// Méthode permettant d'initialiser tous les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initPanel();
            initMailComponents();
            initBtnValidate();
            initLblErr();
        }

        /// <summary>
        /// Méthode initialisant le Panel
        /// </summary>
        private void initPanel()
        { 
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblMail);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlMdpOublie";
            this.Size = new System.Drawing.Size(335, 200);
            this.TabIndex = 0;
        }

        /// <summary>
        /// Méthode initialisant le label et la texbox pour l'e-mail
        /// </summary>
        private void initMailComponents()
        { 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(59, 59);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(35, 13);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "E-mail";
            this.txtMail.Location = new System.Drawing.Point(135, 56);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(132, 20);
            this.txtMail.TabIndex = 3;
        }

        /// <summary>
        /// Méthode initialisant le bouton de validation
        /// </summary>
        private void initBtnValidate()
        { 
            this.btnValidate.Location = new System.Drawing.Point(135, 82);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(132, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Valider";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
        }

        /// <summary>
        /// Méthode initialisant un message d'erreur
        /// </summary>
        private void initLblErr()
        { 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(89, 124);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(155, 13);
            this.lblErr.TabIndex = 5;
            this.lblErr.Text = "L'adresse e-mail est incorrecte !";
            this.lblErr.Visible = false;
        }

        /// <summary>
        /// Méthode appelé lors de la validation
        /// Si l'e-mail existe en base de données, un nouveau mot de passe est généré et envoyé à l'utilisateur
        /// Sinon un message d'erreur s'affiche.
        /// </summary>
        private void btnValidate_Click(object sender, EventArgs e)
        {
            this.lblErr.Visible = false;
            if(User.CheckMail(this.txtMail.Text.ToLower()))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    String newPw = this.CreateRandomPassword();

                    User.UpdatePw(this.txtMail.Text.ToLower(), newPw);

                    mail.From = new MailAddress("galaxyswissbourdin@gmail.com");
                    mail.To.Add(this.txtMail.Text);
                    mail.Subject = "Votre nouveau mot de passe";
                    mail.Body = "Voici votre nouveau mot de passe : " + newPw;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("galaxyswissbourdin@gmail.com", "btssio2012");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("E-mail envoyé");
                    this.Parent.Controls.Remove(this);
                    this.myParent.resetCurrentPannel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else this.lblErr.Visible = true;
        }

        /// <summary>
        /// Fonction générant un mot de passe de 8 caractères aléatoirement
        /// </summary>
        /// <returns>le nouveau mot de passe</returns>
        private string CreateRandomPassword()
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[8];
            Random rd = new Random();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
