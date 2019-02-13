namespace CentralShareDB_Client
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dbTitlePbx = new System.Windows.Forms.PictureBox();
            this.hostTbx = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.hostLbl = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.testConnectionBtn = new System.Windows.Forms.Button();
            this.portNud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dbTitlePbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNud)).BeginInit();
            this.SuspendLayout();
            // 
            // dbTitlePbx
            // 
            this.dbTitlePbx.Image = global::CentralShareDB_Client.Properties.Resources.mongodb;
            this.dbTitlePbx.Location = new System.Drawing.Point(12, 12);
            this.dbTitlePbx.Name = "dbTitlePbx";
            this.dbTitlePbx.Size = new System.Drawing.Size(181, 110);
            this.dbTitlePbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dbTitlePbx.TabIndex = 0;
            this.dbTitlePbx.TabStop = false;
            // 
            // hostTbx
            // 
            this.hostTbx.Location = new System.Drawing.Point(12, 145);
            this.hostTbx.Name = "hostTbx";
            this.hostTbx.Size = new System.Drawing.Size(181, 20);
            this.hostTbx.TabIndex = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 217);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(181, 27);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // hostLbl
            // 
            this.hostLbl.AutoSize = true;
            this.hostLbl.Location = new System.Drawing.Point(9, 129);
            this.hostLbl.Name = "hostLbl";
            this.hostLbl.Size = new System.Drawing.Size(29, 13);
            this.hostLbl.TabIndex = 4;
            this.hostLbl.Text = "Host";
            this.hostLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Location = new System.Drawing.Point(9, 171);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(26, 13);
            this.portLbl.TabIndex = 6;
            this.portLbl.Text = "Port";
            this.portLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.Location = new System.Drawing.Point(12, 250);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(181, 27);
            this.testConnectionBtn.TabIndex = 7;
            this.testConnectionBtn.Text = "Test Connection";
            this.testConnectionBtn.UseVisualStyleBackColor = true;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click);
            // 
            // portNud
            // 
            this.portNud.Location = new System.Drawing.Point(12, 187);
            this.portNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNud.Name = "portNud";
            this.portNud.Size = new System.Drawing.Size(181, 20);
            this.portNud.TabIndex = 8;
            this.portNud.Value = new decimal(new int[] {
            27017,
            0,
            0,
            0});
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(207, 296);
            this.Controls.Add(this.portNud);
            this.Controls.Add(this.testConnectionBtn);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.hostLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.hostTbx);
            this.Controls.Add(this.dbTitlePbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Connection";
            ((System.ComponentModel.ISupportInitialize)(this.dbTitlePbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox dbTitlePbx;
        private System.Windows.Forms.TextBox hostTbx;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label hostLbl;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.NumericUpDown portNud;
    }
}