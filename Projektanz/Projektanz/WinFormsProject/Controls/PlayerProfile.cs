using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Knjiznica;
using WinFormsProject.Properties;

namespace WinFormsProject.Controls
{
    public partial class PlayerProfile : UserControl
    {
        public bool IsFav { get; set; }

        public PlayerProfile()
        {
            InitializeComponent();
            IsFav = false;
        }

        private void pbPlayerIcon_Click(object sender, EventArgs e)
        {
            Bitmap btm = FileRepo.ChoosePicture(lblPlayerName.Text, IsFav) ?? Resources.p5;
            pbPlayerIcon.Image = btm;
            if (IsFav)
            {
                FileRepo.FillPlayerDictionary(lblPlayerName.Text, btm, FileRepo.favPlayerPictures);
            }
            else
            {
                FileRepo.FillPlayerDictionary(lblPlayerName.Text, btm, FileRepo.playerPictures);
            }
        }
    }
}
