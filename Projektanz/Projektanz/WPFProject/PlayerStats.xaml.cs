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
using System.Windows.Shapes;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for PlayerStats.xaml
    /// </summary>
    public partial class PlayerStats : Window
    {

        public PlayerStats(Knjiznica.Model.Player player, ImageSource source, Matches match)
        {
          //  Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(filere.ApplicationLanguage);
            InitializeComponent();
            SetStats(player, source, match);
        }
        
        private void SetStats(Knjiznica.Model.Player player, ImageSource source, Matches match)
        {
            pImage.Source = source;
            pName.Content = player.Name;
            pNumber.Content = $"{Properties.Resources.pNumber}{player.Number}";
            pPosition.Content = player.Position;
            pRole.Content = $"{Properties.Resources.pCaptain}{((player.IsCaptain == true) ? Properties.Resources.pYes : Properties.Resources.pNo)}";


            int yellowCardsCount = 0;
            int goalsScoredCount = 0;
            foreach (var other in match.Home_Team_Statistics.Starting_Eleven)
            {
                if (other.Name == player.Name)
                {
                    foreach (var evt in match.Home_Team_Events)
                    {
                        if (evt.EventType == "yellow-card" && evt.PlayerName == player.Name)
                        {
                            yellowCardsCount++;
                        }
                        if (evt.EventType == "goal-penalty" && evt.PlayerName == player.Name ||
                            evt.EventType == "goal-own" && evt.PlayerName == player.Name ||
                            evt.EventType == "goal" && evt.PlayerName == player.Name)
                        {
                            goalsScoredCount++;
                        }
                    }
                }
            }
            foreach (var other in match.Away_Team_Statistics.Starting_Eleven)
            {
                if (other.Name == player.Name)
                {
                    foreach (var evt in match.Away_Team_Events)
                    {
                        if (evt.EventType == "yellow-card" && evt.PlayerName == player.Name)
                        {
                            yellowCardsCount++;
                        }
                        if (evt.EventType == "goal-penalty" && evt.PlayerName == player.Name ||
                            evt.EventType == "goal-own" && evt.PlayerName == player.Name ||
                            evt.EventType == "goal" && evt.PlayerName == player.Name)
                        {
                            goalsScoredCount++;
                        }
                    }
                }
            }

            pGoalsScored.Content = $"{Properties.Resources.pGoals}{goalsScoredCount}";
            pYellowCards.Content = $"{Properties.Resources.pCards}{yellowCardsCount}";
        }
    }
}
