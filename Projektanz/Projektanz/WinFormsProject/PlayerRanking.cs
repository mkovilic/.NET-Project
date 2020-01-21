using Knjiznica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsProject
{
    public partial class PlayerRanking : Form
    {
        public Country SelectedCountry { get; set; }
        private List<Player> players = null;
        private List<Bitmap> btms = new List<Bitmap>();


        public PlayerRanking() { }


        public PlayerRanking(List<Player> playersList, Country selectedCountry)
        {
            InitializeComponent();
            SelectedCountry = selectedCountry;
            players = playersList;
            LoadData();
        }

        public void SetLanguage()
        {
            CultureInfo culture;
            culture=Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager rm = new ResourceManager("WinFormsProject.PlayerRankings", System.Reflection.Assembly.GetExecutingAssembly());
            this.Text = this.Text + " " + DateTime.Now.ToLongDateString();

            lblPlayerRanking.Text = rm.GetString("lblPlayerRanking.Text");
            label1.Text = rm.GetString("label1.Text");
            label2.Text = rm.GetString("label2.Text");
        }

        private void LoadData()
        {
            lblPlayerRanking.Text = $"Player ranking - {SelectedCountry.CountryName}";
            foreach (var player in players)
            {
                dgvRankByGoals.Rows.Add(null, player.Name, player.Goals);
                dgvRankByYellowCards.Rows.Add(null, player.Name, player.YellowCards);
            }
            dgvRankByGoals.Sort(dgvRankByGoals.Columns["colGoals"], ListSortDirection.Descending);
            dgvRankByYellowCards.Sort(dgvRankByYellowCards.Columns["colYellowCards"], ListSortDirection.Descending);
            SetRowNumbers(dgvRankByGoals);
            SetRowNumbers(dgvRankByYellowCards);
        }

        private void SetRowNumbers(DataGridView dgv)
        {
            int rowNumber = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells[0].Value = rowNumber++;
            }
        }

        private void dgvRankByGoals_SelectionChanged(object sender, EventArgs e)
        {
            dgvRankByGoals.ClearSelection();
        }

        private void dgvRankByYellowCards_SelectionChanged(object sender, EventArgs e)
        {
            dgvRankByYellowCards.ClearSelection();
        }

        private void btnPrintPlayerRanking_Click(object sender, EventArgs e)
        {


         
            printDocument1.Print();

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
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap bm = new Bitmap(this.dgvRankByGoals.Width, this.dgvRankByGoals.Height);
            dgvRankByGoals.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvRankByGoals.Width, this.dgvRankByGoals.Height));
            e.Graphics.DrawImage(bm, 10, 10);


            bm = new Bitmap(this.dgvRankByYellowCards.Width, this.dgvRankByYellowCards.Height);
            dgvRankByGoals.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvRankByYellowCards.Width, this.dgvRankByYellowCards.Height));
            e.Graphics.DrawImage(bm, 10, 10);




        }
    }
}
