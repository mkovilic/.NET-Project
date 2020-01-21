using Knjiznica;
using Knjiznica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Matches> matches = new List<Matches>();
        public static List<Country> teams = new List<Country>();
        public static List<MainWindow> wRefrences = new List<MainWindow>();
        public static bool current = true;
        public static Random rnd;
        private int playerIndex1 = 0;
        private int playerIndex2 = 7;
        private int defenderPlayerCount = 0;
        private int midfilderPlayerCount = 0;
        private int forwardPlayerCount = 0;
        private string selectedCountry;
        private string f_code_left;
        private string f_code_right;


        public MainWindow()
        {
            rnd = new Random();

          //  Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(FileManager.ApplicationLanguage);
            InitializeComponent();
           // SetSize();
            SetFieldImage();
            SetCountrys();
            SetPostavke();

        }

        private void SetPostavke()
        {
            Image image = new Image();
            image.Width = 32;
            image.Height = 32;
            image.Stretch = Stretch.Fill;
            //btnPostavke.Content = image;
        }


        private async void SetCountrys()
        {
            ObservableCollection<string> countrys = new ObservableCollection<string>();

            selectedCountry = FileRepo.ReadFromFile(FileRepo.FAV_COUNTRY)[0];
            f_code_left = selectedCountry.Substring(selectedCountry.Length - 4, 3);

            //teams = await DataLayer
            //     .Data
            //     .GetTeams();
              teams = await Data.GetCountries("https://worldcup.sfg.io/teams/results");

            teams.Sort((x, y) => x.CountryName.CompareTo(y.CountryName));
            teams.ForEach(team => countrys.Add($"{team.CountryName.ToUpper()}  ({team.FifaCode})"));

            cbFavRep.ItemsSource = countrys;
            cbFavRep.SelectedValue = selectedCountry;

        }

        private async Task SetOpposition(string selectedCountry)
        {
            ObservableCollection<string> opposition = new ObservableCollection<string>();

            f_code_left = selectedCountry.Substring(selectedCountry.Length - 4, 3);                  
            matches = await Data.GetMatches(f_code_left);

            foreach (var m in matches)
            {
                if (m.Home_Team.Code == f_code_left)
                {
                    opposition.Add(m.Away_Team.Country + "(" + m.Away_Team.Code + ")");
                }
                else if (m.Away_Team.Code == f_code_left)
                {
                    opposition.Add(m.Home_Team.Country + "(" + m.Home_Team.Code + ")");
                }
            }

            cbProtivnik.ItemsSource = opposition;
        }

        private void SetFieldImage()
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   $"{FileRepo.PICTURE_DIR}\\teren.jpg"));
            myBrush.ImageSource = image.Source;
            gPlayers.Background = myBrush;
        }

    

        private void CbProtivnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProtivnik.SelectedValue != null)
            {
                gPlayers.Children.Clear();
                f_code_right = cbProtivnik.SelectedValue.ToString().Substring(cbProtivnik.SelectedValue.ToString().Length - 4, 3);
                var s1 = new Statistics(f_code_left, f_code_right);
                var s2 = new Statistics(f_code_right, f_code_left);
                var ms = new MatchStatistics(s1, s2);
                ms.ShowDialog();
                InitializePlayers();
                playerIndex1 = 0;
                playerIndex2 = 7;
            }
        }

        private void InitializePlayers()
        {
            foreach (var match in matches)
            {
                if (match.Home_Team.Code == f_code_left && match.Away_Team.Code == f_code_right)
                {
                    foreach (var player in match.Home_Team_Statistics.Starting_Eleven)
                    {
                        //dodaj
                        AddPlayerCount(player);
                    }
                    foreach (var player in match.Home_Team_Statistics.Starting_Eleven)
                    {
                        //nacrtaj
                        DrawPlayers(player, 0, playerIndex1, match);
                    }
                    //reset count
                    ResetPlayerCount();
                    foreach (var player in match.Away_Team_Statistics.Starting_Eleven)
                    {
                        //dodaj
                        AddPlayerCount(player);
                    }
                    foreach (var player in match.Away_Team_Statistics.Starting_Eleven)
                    {
                        //nacrtaj
                        DrawPlayers(player, 4, playerIndex2, match);
                    }
                    //reset count
                    ResetPlayerCount();
                }
                else if (match.Home_Team.Code == f_code_right && match.Away_Team.Code == f_code_left)
                {
                    foreach (var player in match.Away_Team_Statistics.Starting_Eleven)
                    {
                        //dodaj
                        AddPlayerCount(player);
                    }
                    foreach (var player in match.Away_Team_Statistics.Starting_Eleven)
                    {
                        //nacrtaj
                        DrawPlayers(player, 0, playerIndex1, match);
                    }
                    //reset count
                    ResetPlayerCount();
                    foreach (var player in match.Home_Team_Statistics.Starting_Eleven)
                    {
                        //dodaj
                        AddPlayerCount(player);
                    }
                    foreach (var player in match.Home_Team_Statistics.Starting_Eleven)
                    {
                        //nacrtaj
                        DrawPlayers(player, 4, playerIndex2, match);
                    }
                    //reset count
                    ResetPlayerCount();
                }
            }
        }

        private void ResetPlayerCount()
        {
            defenderPlayerCount = 0;
            midfilderPlayerCount = 0;
            forwardPlayerCount = 0;
        }

        private void AddPlayerCount(Knjiznica.Model.Player player)
        {
            switch (player.Position)
            {
                case "Defender":
                    defenderPlayerCount++;
                    break;
                case "Midfield":
                    midfilderPlayerCount++;
                    break;
                case "Forward":
                    forwardPlayerCount++;
                    break;
            }
        }

        private void DrawPlayers(Knjiznica.Model.Player player, int from, int playerIndex, Matches match)
        {
            switch (player.Position)
            {
                case "Goalie":
                    PlacePlayer(player, (from == 0) ? 0 : 7, playerIndex, 0, match);
                    break;
                case "Defender":
                    PlacePlayer(player, (from == 0) ? 1 : 6, playerIndex, defenderPlayerCount, match);
                    defenderPlayerCount--;
                    break;
                case "Midfield":
                    PlacePlayer(player, (from == 0) ? 2 : 5, playerIndex, midfilderPlayerCount, match);
                    midfilderPlayerCount--;
                    break;
                case "Forward":
                    PlacePlayer(player, (from == 0) ? 3 : 4, playerIndex, forwardPlayerCount, match);
                    forwardPlayerCount--;
                    break;
            }
        }

        private void PlacePlayer(Knjiznica.Model.Player player, int column, int index, int playerCount, Matches match)
        {
            UserControl temp = new Player(player, match);

            temp.HorizontalAlignment = HorizontalAlignment.Center;
            temp.VerticalAlignment = VerticalAlignment.Center;

            Grid.SetColumn(temp, column);
            if (player.Position == "Goalie")
            {
                Grid.SetRow(temp, 1);
                Grid.SetRowSpan(temp, 3);

            }
            else
            {
                Grid.SetRow(temp, playerCount - 1);
            }
            gPlayers.Children.Add(temp);
        }

        private async void CbFavRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCountry = cbFavRep.SelectedValue.ToString() ?? selectedCountry;
            await SetOpposition(selectedCountry);
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (current)
            {
                var result = MessageBox.Show(Properties.Resources.wMsg, Properties.Resources.wTitle, MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    current = false;
                    wRefrences.ForEach(w => w.Close());
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

      
    }
}
