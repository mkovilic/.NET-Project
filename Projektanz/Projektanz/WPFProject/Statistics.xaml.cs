using Knjiznica;
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
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        public Statistics(string f_code_left, string f_code_right)
        {
           // Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(FileManager.ApplicationLanguage);
            InitializeComponent();
           
            FillComponents(f_code_left, f_code_right);
        }

        private void FillComponents(string f_code_left, string f_code_right)
        {
            foreach (var match in MainWindow.matches)
            {
                if (match.Home_Team.Code == f_code_left && match.Away_Team.Code == f_code_right)
                {
                    lblSide.Content = Properties.Resources.sSideHome;
                    lblGoals.Content = $"{Properties.Resources.sGoals}{match.Home_Team.Goals.ToString()}";
                    lblPenalties.Content = $"{Properties.Resources.sPen}{match.Home_Team.Penalties.ToString()}";
                    lblTactics.Content = $"{Properties.Resources.sTact}{match.Home_Team_Statistics.Tactics}";
                    lblResult.Content = (match.Home_Team.Goals + match.Home_Team.Penalties > match.Away_Team.Goals + match.Away_Team.Penalties) ? Properties.Resources.sWinner : Properties.Resources.sLosser;
                }
                else if (match.Away_Team.Code == f_code_left && match.Home_Team.Code == f_code_right)
                {
                    lblSide.Content = Properties.Resources.sSideAway;
                    lblGoals.Content = $"{Properties.Resources.sGoals}{match.Away_Team.Goals.ToString()}";
                    lblPenalties.Content = $"{Properties.Resources.sPen}{match.Away_Team.Penalties.ToString()}";
                    lblTactics.Content = $"{Properties.Resources.sTact}{match.Away_Team_Statistics.Tactics}";
                    lblResult.Content = (match.Home_Team.Goals + match.Home_Team.Penalties < match.Away_Team.Goals + match.Away_Team.Penalties) ? Properties.Resources.sWinner : Properties.Resources.sLosser;

                }
            }
            foreach (var team in MainWindow.teams)
            {
                if (team.FifaCode == f_code_left)
                {
                    lblTitle.Content = team.CountryName;
                    lblWinsScore.Content = team.Wins;
                    lblDrawsScore.Content = team.Draws;
                    lblLossesScore.Content = team.Losses;
                    lblGoalsForScore.Content = team.GoalsFor;
                    lblGoalsAgainstScore.Content = team.GoalsAgainst;
                    lblGoalDifferentialScore.Content = team.GoalDifferential;
                }
            }
            lblWins.Content = Properties.Resources.sWin;
            lblDraws.Content = Properties.Resources.sDraw;
            lblLosses.Content = Properties.Resources.sLoss;
            lblGoalsFor.Content = Properties.Resources.sFor;
            lblGoalsAgainst.Content = Properties.Resources.sAgainst;
            lblGoalDifferential.Content = Properties.Resources.sDiff;
            lblOverall.Content = Properties.Resources.sOverall;
        }
    }
}
