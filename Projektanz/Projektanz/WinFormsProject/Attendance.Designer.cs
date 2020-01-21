namespace WinFormsProject
{
    partial class Attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            this.lblAttendanceTitle = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintAttendance = new System.Windows.Forms.Button();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAttendanceTitle
            // 
            resources.ApplyResources(this.lblAttendanceTitle, "lblAttendanceTitle");
            this.lblAttendanceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendanceTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblAttendanceTitle.Name = "lblAttendanceTitle";
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colLocation,
            this.colAttendance,
            this.colHomeTeam,
            this.colAwayTeam});
            resources.ApplyResources(this.dgvAttendance, "dgvAttendance");
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAttendance.RowTemplate.Height = 24;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAttendance.TabStop = false;
            this.dgvAttendance.SelectionChanged += new System.EventHandler(this.dgvAttendance_SelectionChanged);
            // 
            // colNumber
            // 
            this.colNumber.FillWeight = 20.96936F;
            resources.ApplyResources(this.colNumber, "colNumber");
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.FillWeight = 98.03177F;
            resources.ApplyResources(this.colLocation, "colLocation");
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAttendance
            // 
            this.colAttendance.FillWeight = 98.03177F;
            resources.ApplyResources(this.colAttendance, "colAttendance");
            this.colAttendance.Name = "colAttendance";
            this.colAttendance.ReadOnly = true;
            // 
            // colHomeTeam
            // 
            this.colHomeTeam.FillWeight = 98.03177F;
            resources.ApplyResources(this.colHomeTeam, "colHomeTeam");
            this.colHomeTeam.Name = "colHomeTeam";
            this.colHomeTeam.ReadOnly = true;
            this.colHomeTeam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAwayTeam
            // 
            this.colAwayTeam.FillWeight = 98.03177F;
            resources.ApplyResources(this.colAwayTeam, "colAwayTeam");
            this.colAwayTeam.Name = "colAwayTeam";
            this.colAwayTeam.ReadOnly = true;
            this.colAwayTeam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnPrintAttendance
            // 
            resources.ApplyResources(this.btnPrintAttendance, "btnPrintAttendance");
            this.btnPrintAttendance.Name = "btnPrintAttendance";
            this.btnPrintAttendance.UseVisualStyleBackColor = true;
            this.btnPrintAttendance.Click += new System.EventHandler(this.btnPrintAttendance_Click);
            // 
            // printPreviewDialog2
            // 
            resources.ApplyResources(this.printPreviewDialog2, "printPreviewDialog2");
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Attendance
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WinFormsProject.Properties.Resources.FIFA_World_Cup_Russia_2018_1920x1080;
            this.Controls.Add(this.btnPrintAttendance);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.lblAttendanceTitle);
            this.MaximizeBox = false;
            this.Name = "Attendance";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttendanceTitle;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;     
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAwayTeam;
        private System.Windows.Forms.Button btnPrintAttendance;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
        private System.Drawing.Printing.PrintDocument printDocument2;
    }
}