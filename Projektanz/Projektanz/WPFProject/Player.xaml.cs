using Knjiznica;
using Knjiznica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFProject
{

    public partial class Player : UserControl
    {
        private Matches match;
        private Knjiznica.Model.Player player;
        public Player(Knjiznica.Model.Player player, Matches match)
        {
            this.match = match;
            this.player = player;
            InitializeComponent();
            SetPlayer(player, match);

        }

        private void SetPlayer(Knjiznica.Model.Player player, Matches match)
        {

            System.Drawing.Bitmap image;
            image = FileRepo.LoadPlayerPictureFromCache(player.Name, FileRepo.playerPicturesPath);

            if (image == null)
            {
                image = Properties.Resources.p5;
            }
           // pImage.Source = MainWindow.BitmapToImageSource(image);
            pNumber.Text = player.Number.ToString();
            pName.Text = player.Name;

        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var temp = new PlayerStats(player, pImage.Source, match);
            temp.ShowDialog();
        }
    }
}
