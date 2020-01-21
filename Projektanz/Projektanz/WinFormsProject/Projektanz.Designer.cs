namespace WinFormsProject
{
    partial class FavoriteTeam
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoriteTeam));
            this.listTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmTeam = new System.Windows.Forms.Button();
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblFavoritePlayers = new System.Windows.Forms.Label();
            this.cmsAddPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnPlayerRanking = new System.Windows.Forms.Button();
            this.btnAttendence = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmsAddPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTeams
            // 
            this.listTeams.DropDownHeight = 300;
            this.listTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listTeams.FormattingEnabled = true;
            resources.ApplyResources(this.listTeams, "listTeams");
            this.listTeams.Name = "listTeams";
            this.listTeams.SelectedIndexChanged += new System.EventHandler(this.listTeams_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Name = "label1";
            // 
            // btnConfirmTeam
            // 
            resources.ApplyResources(this.btnConfirmTeam, "btnConfirmTeam");
            this.btnConfirmTeam.Name = "btnConfirmTeam";
            this.btnConfirmTeam.UseVisualStyleBackColor = true;
            this.btnConfirmTeam.Click += new System.EventHandler(this.btnConfirmTeam_Click);
            // 
            // flpPlayers
            // 
            resources.ApplyResources(this.flpPlayers, "flpPlayers");
            this.flpPlayers.BackColor = System.Drawing.Color.White;
            this.flpPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPlayers.Name = "flpPlayers";
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.BackColor = System.Drawing.Color.White;
            this.flpFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            this.flpFavoritePlayers.Paint += new System.Windows.Forms.PaintEventHandler(this.flpFavoritePlayers_Paint);
            // 
            // lblPlayers
            // 
            resources.ApplyResources(this.lblPlayers, "lblPlayers");
            this.lblPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayers.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPlayers.Name = "lblPlayers";
            // 
            // lblFavoritePlayers
            // 
            resources.ApplyResources(this.lblFavoritePlayers, "lblFavoritePlayers");
            this.lblFavoritePlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblFavoritePlayers.ForeColor = System.Drawing.Color.DarkGray;
            this.lblFavoritePlayers.Name = "lblFavoritePlayers";
            // 
            // cmsAddPlayer
            // 
            this.cmsAddPlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAddPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavoritesToolStripMenuItem});
            this.cmsAddPlayer.Name = "cmsAddPlayer";
            resources.ApplyResources(this.cmsAddPlayer, "cmsAddPlayer");
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            resources.ApplyResources(this.addToFavoritesToolStripMenuItem, "addToFavoritesToolStripMenuItem");
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // lblCounter
            // 
            resources.ApplyResources(this.lblCounter, "lblCounter");
            this.lblCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblCounter.ForeColor = System.Drawing.Color.Black;
            this.lblCounter.Name = "lblCounter";
            // 
            // btnPlayerRanking
            // 
            this.btnPlayerRanking.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.btnPlayerRanking, "btnPlayerRanking");
            this.btnPlayerRanking.Name = "btnPlayerRanking";
            this.btnPlayerRanking.UseVisualStyleBackColor = false;
            this.btnPlayerRanking.Click += new System.EventHandler(this.btnPlayerRanking_Click);
            // 
            // btnAttendence
            // 
            this.btnAttendence.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.btnAttendence, "btnAttendence");
            this.btnAttendence.Name = "btnAttendence";
            this.btnAttendence.UseVisualStyleBackColor = false;
            this.btnAttendence.Click += new System.EventHandler(this.btnAttendence_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FavoriteTeam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WinFormsProject.Properties.Resources.FIFA_World_Cup_Russia_2018_1920x1080;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAttendence);
            this.Controls.Add(this.btnPlayerRanking);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFavoritePlayers);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpPlayers);
            this.Controls.Add(this.btnConfirmTeam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listTeams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FavoriteTeam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FavoriteTeam_FormClosed);
            this.Load += new System.EventHandler(this.FavoriteTeam_Load);
            this.cmsAddPlayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox listTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmTeam;
        private System.Windows.Forms.FlowLayoutPanel flpPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblFavoritePlayers;
        private System.Windows.Forms.ContextMenuStrip cmsAddPlayer;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnPlayerRanking;
        private System.Windows.Forms.Button btnAttendence;
        private System.Windows.Forms.Button button1;
    }
}

