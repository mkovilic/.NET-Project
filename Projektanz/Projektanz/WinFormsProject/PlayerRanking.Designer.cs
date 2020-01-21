namespace WinFormsProject
{
    partial class PlayerRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRanking));
            this.lblPlayerRanking = new System.Windows.Forms.Label();
            this.dgvRankByGoals = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRankByYellowCards = new System.Windows.Forms.DataGridView();
            this.colNumber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrintPlayerRanking = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankByGoals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankByYellowCards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerRanking
            // 
            resources.ApplyResources(this.lblPlayerRanking, "lblPlayerRanking");
            this.lblPlayerRanking.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerRanking.ForeColor = System.Drawing.Color.Cyan;
            this.lblPlayerRanking.Name = "lblPlayerRanking";
            // 
            // dgvRankByGoals
            // 
            this.dgvRankByGoals.AllowUserToAddRows = false;
            this.dgvRankByGoals.AllowUserToResizeRows = false;
            this.dgvRankByGoals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRankByGoals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankByGoals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colName,
            this.colGoals});
            resources.ApplyResources(this.dgvRankByGoals, "dgvRankByGoals");
            this.dgvRankByGoals.Name = "dgvRankByGoals";
            this.dgvRankByGoals.ReadOnly = true;
            this.dgvRankByGoals.RowHeadersVisible = false;
            this.dgvRankByGoals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRankByGoals.RowTemplate.Height = 24;
            this.dgvRankByGoals.TabStop = false;
            this.dgvRankByGoals.SelectionChanged += new System.EventHandler(this.dgvRankByGoals_SelectionChanged);
            // 
            // colNumber
            // 
            this.colNumber.FillWeight = 30.45686F;
            resources.ApplyResources(this.colNumber, "colNumber");
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FillWeight = 134.7716F;
            resources.ApplyResources(this.colName, "colName");
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colGoals
            // 
            this.colGoals.FillWeight = 134.7716F;
            resources.ApplyResources(this.colGoals, "colGoals");
            this.colGoals.Name = "colGoals";
            this.colGoals.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // dgvRankByYellowCards
            // 
            this.dgvRankByYellowCards.AllowUserToAddRows = false;
            this.dgvRankByYellowCards.AllowUserToResizeRows = false;
            this.dgvRankByYellowCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRankByYellowCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankByYellowCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber2,
            this.colName2,
            this.colYellowCards});
            resources.ApplyResources(this.dgvRankByYellowCards, "dgvRankByYellowCards");
            this.dgvRankByYellowCards.Name = "dgvRankByYellowCards";
            this.dgvRankByYellowCards.ReadOnly = true;
            this.dgvRankByYellowCards.RowHeadersVisible = false;
            this.dgvRankByYellowCards.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRankByYellowCards.RowTemplate.Height = 24;
            this.dgvRankByYellowCards.TabStop = false;
            this.dgvRankByYellowCards.SelectionChanged += new System.EventHandler(this.dgvRankByYellowCards_SelectionChanged);
            // 
            // colNumber2
            // 
            this.colNumber2.FillWeight = 30.45685F;
            resources.ApplyResources(this.colNumber2, "colNumber2");
            this.colNumber2.Name = "colNumber2";
            this.colNumber2.ReadOnly = true;
            // 
            // colName2
            // 
            this.colName2.FillWeight = 134.7716F;
            resources.ApplyResources(this.colName2, "colName2");
            this.colName2.Name = "colName2";
            this.colName2.ReadOnly = true;
            // 
            // colYellowCards
            // 
            this.colYellowCards.FillWeight = 134.7716F;
            resources.ApplyResources(this.colYellowCards, "colYellowCards");
            this.colYellowCards.Name = "colYellowCards";
            this.colYellowCards.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnPrintPlayerRanking
            // 
            resources.ApplyResources(this.btnPrintPlayerRanking, "btnPrintPlayerRanking");
            this.btnPrintPlayerRanking.Name = "btnPrintPlayerRanking";
            this.btnPrintPlayerRanking.UseVisualStyleBackColor = true;
            this.btnPrintPlayerRanking.Click += new System.EventHandler(this.btnPrintPlayerRanking_Click);
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // PlayerRanking
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsProject.Properties.Resources.FIFA_World_Cup_Russia_2018_1920x1080;
            this.Controls.Add(this.btnPrintPlayerRanking);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRankByYellowCards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRankByGoals);
            this.Controls.Add(this.lblPlayerRanking);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayerRanking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankByGoals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankByYellowCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerRanking;
        private System.Windows.Forms.DataGridView dgvRankByGoals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRankByYellowCards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYellowCards;
        private System.Windows.Forms.Button btnPrintPlayerRanking;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}