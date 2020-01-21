namespace WinFormsProject.Controls
{
    partial class PlayerProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerProfile));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pbPlayerIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(80, 10);
            this.lblPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(0, 13);
            this.lblPlayerName.TabIndex = 2;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(80, 32);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(0, 13);
            this.lblPosition.TabIndex = 3;
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(118, 55);
            this.lblCaptain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(0, 13);
            this.lblCaptain.TabIndex = 4;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(80, 55);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(0, 13);
            this.lblNumber.TabIndex = 5;
            // 
            // pbPlayerIcon
            // 
            this.pbPlayerIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlayerIcon.BackgroundImage")));
            this.pbPlayerIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayerIcon.Location = new System.Drawing.Point(2, 2);
            this.pbPlayerIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbPlayerIcon.Name = "pbPlayerIcon";
            this.pbPlayerIcon.Size = new System.Drawing.Size(73, 76);
            this.pbPlayerIcon.TabIndex = 0;
            this.pbPlayerIcon.TabStop = false;
            this.pbPlayerIcon.Click += new System.EventHandler(this.pbPlayerIcon_Click);
            // 
            // PlayerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.pbPlayerIcon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PlayerProfile";
            this.Size = new System.Drawing.Size(254, 80);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerIcon;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.Label lblNumber;
    }
}
