using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe PanelHistoTicket permettant d'afficher l'historique de tous les tickets en fonction d'un utilisateur
    /// </summary>
    public partial class PanelHistoTicket : Panel
    {
        private Label lblNumTicket,lblTitreTicket,lblDateTicket,lblStatutTicket;
        private TableLayoutPanel tbHistorique;
        private Panel pnlDetails;
        private List<Ticket> mesTickets;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public PanelHistoTicket()
        {
            this.lblNumTicket = new Label();
            this.lblTitreTicket = new Label();
            this.lblDateTicket = new Label();
            this.lblStatutTicket = new Label();
            this.tbHistorique = new TableLayoutPanel();
            this.pnlDetails = new Panel();
            this.tbHistorique.SuspendLayout();
            this.SuspendLayout();
            initComponents();
            initDatas();
        }

        /// <summary>
        /// Méthode initialisant les attributs de la classe
        /// </summary>
        private void initComponents()
        {
            initLblNumTicket();
            initLblTitreTicket();
            initLblDateTicket();
            initLblStatutTicket();
            initTbHistorique();
            initPnlDetails();
            initPanel();
        }

        /// <summary>
        /// Méthode initialisant le Panel
        /// </summary>
        private void initPanel()
        {
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.tbHistorique);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlHistoTicket";
            this.Size = new System.Drawing.Size(784, 603);
            this.TabIndex = 0;
            this.tbHistorique.ResumeLayout(false);
            this.tbHistorique.PerformLayout();
            this.ResumeLayout(false);
        }
        
        /// <summary>
        /// Méthode initialisant le label correspondant à l'en-tête de la première colonne
        /// </summary>
        private void initLblNumTicket()
        {
            this.lblNumTicket.AutoSize = true;
            this.lblNumTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTicket.Location = new System.Drawing.Point(4, 1);
            this.lblNumTicket.Name = "lblNumTicket";
            this.lblNumTicket.Size = new System.Drawing.Size(50, 16);
            this.lblNumTicket.TabIndex = 0;
            this.lblNumTicket.Text = "N° du ticket";
        }

        /// <summary>
        /// Méthode initialisant le label correspondant à l'en-tête de la seconde colonne
        /// </summary>
        private void initLblTitreTicket()
        {
            this.lblTitreTicket.AutoSize = true;
            this.lblTitreTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitreTicket.Location = new System.Drawing.Point(137, 1);
            this.lblTitreTicket.Name = "lblTitreTicket";
            this.lblTitreTicket.Size = new System.Drawing.Size(102, 16);
            this.lblTitreTicket.TabIndex = 1;
            this.lblTitreTicket.Text = "Titre du ticket";
        }

        /// <summary>
        /// Méthode initialisant le label correspondant à l'en-tête de la troisième colonne
        /// </summary>
        private void initLblDateTicket()
        {
            this.lblDateTicket.AutoSize = true;
            this.lblDateTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTicket.Location = new System.Drawing.Point(441, 1);
            this.lblDateTicket.Name = "lblDateTicket";
            this.lblDateTicket.Size = new System.Drawing.Size(185, 16);
            this.lblDateTicket.TabIndex = 2;
            this.lblDateTicket.Text = "Date de création du ticket";
        }

        /// <summary>
        /// Méthode initialisant le label correspondant à l'en-tête de la quatrième colonne
        /// </summary>
        private void initLblStatutTicket()
        {
            this.lblStatutTicket.AutoSize = true;
            this.lblStatutTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatutTicket.Location = new System.Drawing.Point(637, 1);
            this.lblStatutTicket.Name = "lblStatutTicket";
            this.lblStatutTicket.Size = new System.Drawing.Size(109, 16);
            this.lblStatutTicket.TabIndex = 3;
            this.lblStatutTicket.Text = "Statut du ticket";
        }


        /// <summary>
        /// Méthode initialisant le tableau
        /// </summary>
        private void initTbHistorique()
        {
            this.tbHistorique.BackColor = System.Drawing.Color.Silver;
            this.tbHistorique.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbHistorique.ColumnCount = 4;
            this.tbHistorique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tbHistorique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tbHistorique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tbHistorique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tbHistorique.Controls.Add(this.lblNumTicket, 0, 0);
            this.tbHistorique.Controls.Add(this.lblStatutTicket, 3, 0);
            this.tbHistorique.Controls.Add(this.lblDateTicket, 2, 0);
            this.tbHistorique.Controls.Add(this.lblTitreTicket, 1, 0);
            this.tbHistorique.Location = new System.Drawing.Point(0, 0);
            this.tbHistorique.AutoSize = true;
            this.tbHistorique.Name = "tbHistorique";
            this.tbHistorique.RowCount = 1;
            this.tbHistorique.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.83019F));
            this.tbHistorique.Size = new System.Drawing.Size(799, 121);
            this.tbHistorique.TabIndex = 6;
        }

        /// <summary>
        /// Méthode initialisant le Panel qui affichera les détails d'un ticket
        /// </summary>
        private void initPnlDetails()
        {
            this.pnlDetails.Location = new System.Drawing.Point(37, 139);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(500, 531);
            this.pnlDetails.TabIndex = 5;
            this.pnlDetails.Visible = false;
        }

        /// <summary>
        /// Méthode qui remplit le tableau en fonction de l'historique récupéré depuis la base de données
        /// </summary>
        private void initDatas()
        {
            mesTickets = Ticket.GetAllTicket(User.GetId());
            this.tbHistorique.RowCount = 1 + mesTickets.Count;
            int i = 1;

            foreach (Ticket unTicket in mesTickets)
            {
                this.tbHistorique.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.83019F));

                LinkLabel lblNumTicket = new LinkLabel();
                lblNumTicket.Text = unTicket.GetId().ToString();
                lblNumTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblNumTicket.Size = new System.Drawing.Size(50, 16);
                lblNumTicket.Click += new System.EventHandler(this.lblNumTicket_Click);

                Label lblTitreTicket = new Label();
                lblTitreTicket.Text = unTicket.GetTitre();
                lblTitreTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblTitreTicket.Size = new System.Drawing.Size(250, 32);

                Label lblDateTicket = new Label();
                lblDateTicket.Text = unTicket.GetDate();
                lblDateTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblDateTicket.Size = new System.Drawing.Size(185, 16);

                Label lblStatutTicket = new Label();
                lblStatutTicket.Text = unTicket.GetStatut();
                lblStatutTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblStatutTicket.Size = new System.Drawing.Size(109, 16);

                tbHistorique.Controls.Add(lblNumTicket, 0, i);
                tbHistorique.Controls.Add(lblTitreTicket, 1, i);
                tbHistorique.Controls.Add(lblDateTicket, 2, i);
                tbHistorique.Controls.Add(lblStatutTicket, 3, i);
                i++;
            }
        }

        /// <summary>
        /// Méthode appelé lors du click sur le lien
        /// </summary>
        private void lblNumTicket_Click(object sender, EventArgs e)
        {
            this.pnlDetails.Visible = true;
            LinkLabel unLabel = sender as LinkLabel;
            this.pnlDetails.Controls.Add(new PanelDetailsTicket(int.Parse(unLabel.Text)));
        }
    }
}
