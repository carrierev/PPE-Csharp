namespace WindowsFormsApplication1
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierMotDePasseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketDincidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerUnTicketDincidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suivreUnTicketDincidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motDePasseOubliéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.profilToolStripMenuItem,
            this.ticketDincidentToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionToolStripMenuItem,
            this.déconnexionToolStripMenuItem,
            this.toolStripSeparator,
            this.quitterToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // connexionToolStripMenuItem
            // 
            this.connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            this.connexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connexionToolStripMenuItem.Text = "Connexion";
            this.connexionToolStripMenuItem.Click += new System.EventHandler(this.connexionToolStripMenuItem_Click);
            // 
            // déconnexionToolStripMenuItem
            // 
            this.déconnexionToolStripMenuItem.Name = "déconnexionToolStripMenuItem";
            this.déconnexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.déconnexionToolStripMenuItem.Text = "Déconnexion";
            this.déconnexionToolStripMenuItem.Visible = false;
            this.déconnexionToolStripMenuItem.Click += new System.EventHandler(this.déconnexionToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(140, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierMotDePasseToolStripMenuItem});
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Visible = false;
            // 
            // modifierMotDePasseToolStripMenuItem
            // 
            this.modifierMotDePasseToolStripMenuItem.Name = "modifierMotDePasseToolStripMenuItem";
            this.modifierMotDePasseToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.modifierMotDePasseToolStripMenuItem.Text = "Modifier mot de passe";
            this.modifierMotDePasseToolStripMenuItem.Click += new System.EventHandler(this.modifierMotDePasseToolStripMenuItem_Click);
            // 
            // ticketDincidentToolStripMenuItem
            // 
            this.ticketDincidentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerUnTicketDincidentToolStripMenuItem,
            this.suivreUnTicketDincidentToolStripMenuItem});
            this.ticketDincidentToolStripMenuItem.Name = "ticketDincidentToolStripMenuItem";
            this.ticketDincidentToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.ticketDincidentToolStripMenuItem.Text = "Ticket d\'incident";
            this.ticketDincidentToolStripMenuItem.Visible = false;
            // 
            // créerUnTicketDincidentToolStripMenuItem
            // 
            this.créerUnTicketDincidentToolStripMenuItem.Name = "créerUnTicketDincidentToolStripMenuItem";
            this.créerUnTicketDincidentToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.créerUnTicketDincidentToolStripMenuItem.Text = "Créer un ticket d\'incident";
            this.créerUnTicketDincidentToolStripMenuItem.Click += new System.EventHandler(this.créerUnTicketDincidentToolStripMenuItem_Click);
            // 
            // suivreUnTicketDincidentToolStripMenuItem
            // 
            this.suivreUnTicketDincidentToolStripMenuItem.Name = "suivreUnTicketDincidentToolStripMenuItem";
            this.suivreUnTicketDincidentToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.suivreUnTicketDincidentToolStripMenuItem.Text = "Historique des tickets d\'incident";
            this.suivreUnTicketDincidentToolStripMenuItem.Click += new System.EventHandler(this.suivreUnTicketDincidentToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motDePasseOubliéToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // motDePasseOubliéToolStripMenuItem
            // 
            this.motDePasseOubliéToolStripMenuItem.Name = "motDePasseOubliéToolStripMenuItem";
            this.motDePasseOubliéToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.motDePasseOubliéToolStripMenuItem.Text = "Mot de passe oublié";
            this.motDePasseOubliéToolStripMenuItem.Click += new System.EventHandler(this.motDePasseOubliéToolStripMenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(12, 27);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(816, 535);
            this.pnlContainer.TabIndex = 1;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 574);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "GSB - Gestionnaire de tickets d\'incident";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierMotDePasseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketDincidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem créerUnTicketDincidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suivreUnTicketDincidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motDePasseOubliéToolStripMenuItem;
    }
}