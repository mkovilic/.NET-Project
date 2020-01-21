using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Knjiznica;
using Knjiznica.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinFormsProject.Controls;
using WinFormsProject.Properties;

namespace WinFormsProject
{
    public partial class FavoriteTeam : Form
    {
        private const string favTeamFile = @"../../fav_team/fav.txt";
        private const string favTeamFolder = @"../../fav_team";
        private List<Country> countriesList;
        private Country selectedCountry;
        private Country favoriteCountry;
        private List<Player> playersList;
        private List<TeamEvent> teamEvents;
        private List<PlayerProfile> selectedPlayers;
        private List<AttendanceInfo> selectedCountryAttendance;

        public FavoriteTeam(CultureInfo culture)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager rm = new ResourceManager("WinFormsProject.FavoriteTeam",System.Reflection.Assembly.GetExecutingAssembly());
            this.Text = this.Text + " " + DateTime.Now.ToLongDateString();

            label1.Text = rm.GetString("label1.Text");
            lblFavoritePlayers.Text = rm.GetString("lblFavoritePlayers.Text");
            lblPlayers.Text = rm.GetString("lblPlayers.Text");
            btnAttendence.Text = rm.GetString("btnAttendence.Text");
            btnConfirmTeam.Text = rm.GetString("btnConfirmTeam.Text");
            btnPlayerRanking.Text = rm.GetString("btnPlayerRanking.Text");


            selectedPlayers = new List<PlayerProfile>();
            playersList = new List<Player>();
            teamEvents = new List<TeamEvent>();
            favoriteCountry = new Country();
            selectedCountryAttendance = new List<AttendanceInfo>();
        }

        public FavoriteTeam()
        {
            InitializeComponent();
            selectedPlayers = new List<PlayerProfile>();
            playersList = new List<Player>();
            teamEvents = new List<TeamEvent>();
            favoriteCountry= new Country();
            selectedCountryAttendance = new List<AttendanceInfo>();
        }

        private async void FavoriteTeam_Load(object sender, EventArgs e)
        {
            //  countriesList = await DataLayer.Data.GetCountries("https://world-cup-json-2018.herokuapp.com/teams/results");
           
            countriesList = await Data.GetCountries("https://worldcup.sfg.io/teams/results");

            countriesList.Sort((x,y) => x.CountryName.CompareTo(y.CountryName));

            foreach (var team in countriesList)
            {
                
               listTeams.Items.Add($"{team.CountryName.ToUpper()} ({team.FifaCode})");
            }
        }

        private async void btnConfirmTeam_Click(object sender, EventArgs e)
        {
            selectedCountry = countriesList[listTeams.SelectedIndex] as Country;

            if (playersList.Count != 0)
            {
                flpPlayers.Controls.Clear();
            }

            playersList = await Data.GetPlayersForCountry($"https://worldcup.sfg.io/matches/country?fifa_code={selectedCountry.FifaCode}", selectedCountry.FifaCode);

            foreach (var player in playersList)
            {
                PlayerProfile playerCard = CreateNewPlayerCard(player);
                playerCard.MouseDown += PlayerCard_MouseDown;
                flpPlayers.Controls.Add(playerCard);
            }
            flpFavoritePlayers.AllowDrop = true;
            btnAttendence.Enabled = true;
            btnPlayerRanking.Enabled = true;


            // FileRepo.SaveFavoriteTeam(favTeamFolder,favTeamFile,selectedCountry);
            FileRepo.WriteToFile(new[] { listTeams.Text }, FileRepo.FAV_COUNTRY);
        }

        private PlayerProfile CreateNewPlayerCard(Player player)
        {
            PlayerProfile playerCard = new PlayerProfile();

            playerCard.Controls["lblPlayerName"].Text = player.Name;
            playerCard.Controls["lblPlayerName"].ForeColor = Color.Red;            
            playerCard.Controls["lblPosition"].Text = player.Position;            
            playerCard.Controls["lblNumber"].Text = player.Number;

            if (player.IsCaptain)
            {
                playerCard.Controls["lblCaptain"].Text = "Captain"; 
            }

            return playerCard;
        }

        #region
        private void PlayerCard_MouseDown(object sender, MouseEventArgs e)
        {
            //DRAG AND DROP CONTROLS
            PlayerProfile selectedPlayer = sender as PlayerProfile;
            if (e.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                //checks if 4th non-selected player is selected
                if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count == 3 && !selectedPlayers.Contains(selectedPlayer))
                {
                    toolTip.Show("Max 3 favorite players!", selectedPlayer, 2000);
                }
                //deselects only the currently selected player
                else if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count <= 3 && selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.BackColor = SystemColors.Control;
                    selectedPlayers.Remove(selectedPlayer);
                }
                //selects a new player
                else if (!selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.BackColor = Color.LightBlue;
                    selectedPlayers.Add(selectedPlayer);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                //checks if 4th non-selected player is selected
                if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count == 3 && !selectedPlayers.Contains(selectedPlayer))
                {
                    toolTip.Show("Max 3 favorite players!", selectedPlayer, 2000);
                }
                //allows drag & drop on an already selected player if up to 3 players are selected
                else if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count <= 3 && selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.DoDragDrop(selectedPlayer, DragDropEffects.Move);
                }
                //deselects all already selected players and selects the currently selected player
                else if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count <= 3 && !selectedPlayers.Contains(selectedPlayer))
                {
                    foreach (PlayerProfile player in selectedPlayers)
                    {
                        player.BackColor = SystemColors.Control;
                    }
                    selectedPlayers.Clear();
                    selectedPlayer.BackColor = Color.LightBlue;
                    selectedPlayers.Add(selectedPlayer);
                    selectedPlayer.DoDragDrop(selectedPlayer, DragDropEffects.Move);
                }
            }

            //CONTEXT MENU CONTROLS
            else if (e.Button == MouseButtons.Right && ModifierKeys == Keys.Control)
            {
                ContextMenuStrip cms = cmsAddPlayer;
                //checks if 4th non-selected player is selected
                if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count == 3 && !selectedPlayers.Contains(selectedPlayer))
                {
                    toolTip.Show("Max 3 favorite players!", selectedPlayer, 2000);
                }
                //deselects only the currently selected player
                else if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count <= 3 && selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.BackColor = SystemColors.Control;
                    selectedPlayers.Remove(selectedPlayer);
                    selectedPlayer.ContextMenuStrip = null;
                }
                //selects a new player
                else if (!selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.BackColor = Color.LightBlue;
                    selectedPlayers.Add(selectedPlayer);
                    selectedPlayer.ContextMenuStrip = cms;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cms = cmsAddPlayer;
                //checks if 4th non-selected player is selected
                if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count == 3 && !selectedPlayers.Contains(selectedPlayer))
                {
                    toolTip.Show("Max 3 favorite players!", selectedPlayer, 2000);
                }
                //enables context menu to move up to 3 players
                else if (flpFavoritePlayers.Controls.Count + selectedPlayers.Count <= 3 && selectedPlayers.Contains(selectedPlayer))
                {
                    selectedPlayer.ContextMenuStrip = cms;
                }
                //deselects all already selected players and selects the currently selected player
                else if (selectedPlayers.Count > 0 && (!selectedPlayers.Contains(selectedPlayer) || selectedPlayers.Contains(selectedPlayer)))
                {
                    foreach (PlayerProfile player in selectedPlayers)
                    {
                        player.BackColor = SystemColors.Control;
                        selectedPlayer.ContextMenuStrip = null;
                    }
                    selectedPlayers.Clear();
                    selectedPlayer.BackColor = Color.LightBlue;
                    selectedPlayers.Add(selectedPlayer);
                    selectedPlayer.ContextMenuStrip = cms;
                }
                //selects first selected player
                else
                {
                    selectedPlayer.BackColor = Color.LightBlue;
                    selectedPlayers.Add(selectedPlayer);
                    selectedPlayer.ContextMenuStrip = cms;
                }
            }
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            AddSelectedPlayersToFavorites();
        }

        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectedPlayersToFavorites();
        }

        private void AddSelectedPlayersToFavorites()
        {
            foreach (PlayerProfile player in selectedPlayers)
            {
                PictureBox goldstar = new PictureBox
                {
                    Name = "pbGoldstar",
                    Image = Properties.Resources.gold_star,
                    Size = new Size(40, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                player.BackColor = SystemColors.Control;
                player.Controls.Add(goldstar);
                player.Controls["pbGoldstar"].Location = new Point(190, 20);
                player.MouseDown -= PlayerCard_MouseDown;
                player.Click += Player_Click;
                flpFavoritePlayers.Controls.Add(player);
                lblCounter.Text = flpFavoritePlayers.Controls.Count.ToString();
            }
            selectedPlayers.Clear();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            PlayerProfile player = sender as PlayerProfile;
            flpFavoritePlayers.Controls.Remove(player);
            lblCounter.Text = flpFavoritePlayers.Controls.Count.ToString();
            player.Controls.RemoveByKey("pbGoldstar");
            player.BackColor = SystemColors.Control;
            player.Click -= Player_Click;
            player.MouseDown += PlayerCard_MouseDown;
            flpPlayers.Controls.Add(player);
        }

        #endregion

        private async void btnAttendence_Click(object sender, EventArgs e)
        {
            selectedCountryAttendance = await Knjiznica.Data.GetAttendanceInfoForCountry($"https://worldcup.sfg.io/matches/country?fifa_code={selectedCountry.FifaCode}");
            Attendance attendance = new Attendance(selectedCountryAttendance, selectedCountry);
            attendance.Shown += Ranking_Shown;
            attendance.FormClosed += Ranking_FormClosed;

            attendance.Show();

        }

        private void btnPlayerRanking_Click(object sender, EventArgs e)
        {
            PlayerRanking playerRanking = new PlayerRanking(playersList, selectedCountry);
            playerRanking.Shown += Ranking_Shown;
            playerRanking.FormClosed += Ranking_FormClosed;
            playerRanking.Show();            
        }

        private void Ranking_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }

        private void Ranking_Shown(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        private void listTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (listTeams.SelectedIndex != 0)
            {
             
                btnConfirmTeam.Enabled = true;
            }
            else
            {
                //btnConfirmTeam.Enabled = false;
            }
        }

        private void FavoriteTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Environment.Exit(0);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            string msg = Resources.Zatvaranje;
            DialogResult result = MessageBox.Show(msg, Resources.ZatvaranjeNaslov,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                FileRepo.WriteToFile(new[] { listTeams.Text }, FileRepo.FAV_COUNTRY);
            else if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void flpFavoritePlayers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileRepo.WriteToFile(new[] { flpFavoritePlayers.ToString()}, FileRepo.FAVPLAYERS_PATH);
        }
    }
}
