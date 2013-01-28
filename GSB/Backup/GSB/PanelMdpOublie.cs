using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApplication1
{
    public class PanelMdpOublie : Panel
    {
        private TextBox txtMail;
        private Label lblMail, lblErr;
        private Button btnValidate;

        public PanelMdpOublie()
        {
            this.lblMail = new Label();
            this.txtMail = new TextBox();
            this.btnValidate = new Button();
            this.lblErr = new Label();
            this.SuspendLayout();
            initComponents();
        }

        private void initComponents()
        {
            initPanel();
            initMailComponents();
            initBtnValidate();
            initLblErr();
        }

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
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("galaxyswissbourdin@gmail.com");
                mail.To.Add(this.txtMail.Text);
                mail.Subject = "Test";
                mail.Body = "Test";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("galaxyswissbourdin@gmail.com", "btssio2012");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("E-mail envoyé");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
