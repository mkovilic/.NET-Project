using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsProject
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            cbSelectLanguge.Items.Add("English");
            cbSelectLanguge.Items.Add("Croatian");
            cbSelectLanguge.SelectedItem = "Croatian";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbSelectLanguge.Text.Equals("English"))
            {

                FavoriteTeam ft = new FavoriteTeam(new CultureInfo("en-US"));
                ft.Show();

            }
            else if (cbSelectLanguge.Text.Equals("Croatian"))
            {

                FavoriteTeam ft = new FavoriteTeam(new CultureInfo("hr-HR"));
                ft.Show();

            }
        }

        private void LanguageMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
