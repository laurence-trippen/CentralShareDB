namespace CentralShareDB_Client.Forms
{
    partial class ShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareForm));
            this.driveLettersCbx = new System.Windows.Forms.ComboBox();
            this.newShareBtn = new System.Windows.Forms.Button();
            this.pathTbx = new System.Windows.Forms.TextBox();
            this.driveLettersLbl = new System.Windows.Forms.Label();
            this.pathLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // driveLettersCbx
            // 
            this.driveLettersCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveLettersCbx.FormattingEnabled = true;
            this.driveLettersCbx.Location = new System.Drawing.Point(15, 26);
            this.driveLettersCbx.Name = "driveLettersCbx";
            this.driveLettersCbx.Size = new System.Drawing.Size(78, 21);
            this.driveLettersCbx.TabIndex = 0;
            // 
            // newShareBtn
            // 
            this.newShareBtn.Location = new System.Drawing.Point(180, 53);
            this.newShareBtn.Name = "newShareBtn";
            this.newShareBtn.Size = new System.Drawing.Size(121, 27);
            this.newShareBtn.TabIndex = 1;
            this.newShareBtn.Text = "New Share";
            this.newShareBtn.UseVisualStyleBackColor = true;
            this.newShareBtn.Click += new System.EventHandler(this.newShareBtn_Click);
            // 
            // pathTbx
            // 
            this.pathTbx.Location = new System.Drawing.Point(99, 27);
            this.pathTbx.Name = "pathTbx";
            this.pathTbx.Size = new System.Drawing.Size(202, 20);
            this.pathTbx.TabIndex = 2;
            // 
            // driveLettersLbl
            // 
            this.driveLettersLbl.AutoSize = true;
            this.driveLettersLbl.Location = new System.Drawing.Point(12, 9);
            this.driveLettersLbl.Name = "driveLettersLbl";
            this.driveLettersLbl.Size = new System.Drawing.Size(62, 13);
            this.driveLettersLbl.TabIndex = 3;
            this.driveLettersLbl.Text = "Drive Letter";
            this.driveLettersLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pathLbl
            // 
            this.pathLbl.AutoSize = true;
            this.pathLbl.Location = new System.Drawing.Point(96, 9);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(29, 13);
            this.pathLbl.TabIndex = 4;
            this.pathLbl.Text = "Path";
            this.pathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(313, 95);
            this.Controls.Add(this.pathLbl);
            this.Controls.Add(this.driveLettersLbl);
            this.Controls.Add(this.pathTbx);
            this.Controls.Add(this.newShareBtn);
            this.Controls.Add(this.driveLettersCbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewShareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Share";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox driveLettersCbx;
        private System.Windows.Forms.Button newShareBtn;
        private System.Windows.Forms.TextBox pathTbx;
        private System.Windows.Forms.Label driveLettersLbl;
        private System.Windows.Forms.Label pathLbl;
    }
}