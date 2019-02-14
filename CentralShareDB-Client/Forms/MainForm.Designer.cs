namespace CentralShareDB_Client
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addShareBtn = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbVerbindungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkShareClbx = new System.Windows.Forms.CheckedListBox();
            this.addNewShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShareBtn = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // addShareBtn
            // 
            this.addShareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addShareBtn.Location = new System.Drawing.Point(11, 138);
            this.addShareBtn.Name = "addShareBtn";
            this.addShareBtn.Size = new System.Drawing.Size(130, 28);
            this.addShareBtn.TabIndex = 0;
            this.addShareBtn.Text = "Mount Share";
            this.addShareBtn.UseVisualStyleBackColor = true;
            this.addShareBtn.Click += new System.EventHandler(this.addShareBtn_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(377, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewShareToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbVerbindungToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // dbVerbindungToolStripMenuItem
            // 
            this.dbVerbindungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.testConnectionToolStripMenuItem});
            this.dbVerbindungToolStripMenuItem.Name = "dbVerbindungToolStripMenuItem";
            this.dbVerbindungToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.dbVerbindungToolStripMenuItem.Text = "Database Connection";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // testConnectionToolStripMenuItem
            // 
            this.testConnectionToolStripMenuItem.Name = "testConnectionToolStripMenuItem";
            this.testConnectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testConnectionToolStripMenuItem.Text = "Test Connection";
            this.testConnectionToolStripMenuItem.Click += new System.EventHandler(this.testConnectionToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.germanToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // germanToolStripMenuItem
            // 
            this.germanToolStripMenuItem.Name = "germanToolStripMenuItem";
            this.germanToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.germanToolStripMenuItem.Text = "German";
            // 
            // helpToolStripItem
            // 
            this.helpToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.helpToolStripItem.Name = "helpToolStripItem";
            this.helpToolStripItem.Size = new System.Drawing.Size(24, 20);
            this.helpToolStripItem.Text = "?";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.licenseToolStripMenuItem.Text = "License";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // networkShareClbx
            // 
            this.networkShareClbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkShareClbx.CheckOnClick = true;
            this.networkShareClbx.FormattingEnabled = true;
            this.networkShareClbx.Items.AddRange(new object[] {
            "(F:) //192.168.1.118/lt-nas-01-productive"});
            this.networkShareClbx.Location = new System.Drawing.Point(12, 38);
            this.networkShareClbx.Name = "networkShareClbx";
            this.networkShareClbx.Size = new System.Drawing.Size(353, 94);
            this.networkShareClbx.TabIndex = 4;
            // 
            // addNewShareToolStripMenuItem
            // 
            this.addNewShareToolStripMenuItem.Name = "addNewShareToolStripMenuItem";
            this.addNewShareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewShareToolStripMenuItem.Text = "Add New Share";
            this.addNewShareToolStripMenuItem.Click += new System.EventHandler(this.addNewShareToolStripMenuItem_Click);
            // 
            // deleteShareBtn
            // 
            this.deleteShareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteShareBtn.Location = new System.Drawing.Point(147, 138);
            this.deleteShareBtn.Name = "deleteShareBtn";
            this.deleteShareBtn.Size = new System.Drawing.Size(130, 28);
            this.deleteShareBtn.TabIndex = 5;
            this.deleteShareBtn.Text = "Delete Share";
            this.deleteShareBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(377, 183);
            this.Controls.Add(this.deleteShareBtn);
            this.Controls.Add(this.networkShareClbx);
            this.Controls.Add(this.addShareBtn);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CentralShareDB-Client";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addShareBtn;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbVerbindungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox networkShareClbx;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewShareToolStripMenuItem;
        private System.Windows.Forms.Button deleteShareBtn;
    }
}

