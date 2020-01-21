using Knjiznica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsProject
{
    public partial class Attendance : Form
    {
        public Country SelectedCountry { get; set; }
        private List<AttendanceInfo> selectedCountryAttendance = null;
        private List<Bitmap> btms = new List<Bitmap>();
        private int page_count = 1;
        private int btm_portion = 0;
        private int offsetY = 0;




        public Attendance(List<AttendanceInfo> selectedCountryAttendanceList, Country selectedCountry)
        {
            InitializeComponent();
            SelectedCountry = selectedCountry;
            selectedCountryAttendance = selectedCountryAttendanceList;
            LoadData();
            SetLanguage();
        }

        public void SetLanguage()
        {
            CultureInfo culture;
            culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager rm = new ResourceManager("WinFormsProject.Attendance", System.Reflection.Assembly.GetExecutingAssembly());
            this.Text = this.Text + " " + DateTime.Now.ToLongDateString();

            lblAttendanceTitle.Text = rm.GetString("lblAttendanceTitle.Text");
            btnPrintAttendance.Text = rm.GetString("btnPrintAttendance.Text");
        }

        private void LoadData()
        {
            lblAttendanceTitle.Text = $"Attendance - {SelectedCountry.CountryName}";
            int rowNumber = 1;
            foreach (var matchInfo in selectedCountryAttendance)
            {
                dgvAttendance.Rows.Add(null, matchInfo.Location, matchInfo.Attendance, matchInfo.HomeTeam, matchInfo.AwayTeam);
            }
            dgvAttendance.Sort(dgvAttendance.Columns["colAttendance"], ListSortDirection.Descending);
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                row.Cells["colNumber"].Value = rowNumber++;
            }
        }

        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            dgvAttendance.ClearSelection();
        }

        private void btnPrintAttendance_Click(object sender, EventArgs e)
        {

         
            printDocument2.Print();

        }

        private void InitializePrint(DataGridView dgv)
        {
            int height = dgv.Height;
            dgv.Height = dgv.RowCount * dgv.RowTemplate.Height * 2;
            int rows = dgv.Rows.Count;

            //header
            btms.Add(new Bitmap(dgv.Width, 80));
            dgv.DrawToBitmap(btms[0], new Rectangle(0, 0, dgv.Width, 80));
            //body
            btms.Add(new Bitmap(dgv.Width, dgv.Height));
            dgv.DrawToBitmap(btms[1], new Rectangle(0, 0, dgv.Width, dgv.Height));

            dgv.Height = height;
            printPreviewDialog2.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap bm = new Bitmap(this.dgvAttendance.Width, this.dgvAttendance.Height);
            dgvAttendance.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvAttendance.Width, this.dgvAttendance.Height));
            e.Graphics.DrawImage(bm, 10, 10);


            bm = new Bitmap(this.dgvAttendance.Width, this.dgvAttendance.Height);
            dgvAttendance.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvAttendance.Width, this.dgvAttendance.Height));
            e.Graphics.DrawImage(bm, 10, 10);




        }

    }
}
