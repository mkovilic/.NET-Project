using Knjiznica.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjiznica
{
    public class FileRepo
    {
        //private const string fileTeamPath = "teams.txt";
        //private const string fileFavoriteTeamPath = @"../../fav_team/fav.txt";
        //private const string fileLanguagePath = @"../../lang/language.txt";
        //private const string playersPicturesPath = @"players\img\";
        //private const string favoritePlayersPath = @"players\fav\";
        //public static readonly string SETTINGS_PATH = Path.Combine(PATH, "Settings.txt");
        //public static string ApplicationLanguage { get; set; }
        private static readonly char SPLITTER = '|';
        //public static int ApplicationWidth = -1;
        //public static int ApplicationHeight = -1;
        public static IDictionary<string, string> playerPicturesPath = new Dictionary<string, string>();
        public static IDictionary<string, Bitmap> playerPictures = new Dictionary<string, Bitmap>();
        public static IDictionary<string, Bitmap> favPlayerPictures = new Dictionary<string, Bitmap>();
        public static IDictionary<string, string> favPlayerPicturesPath = new Dictionary<string, string>();
        public static IList<string> playerPicturesForFile = new List<string>();
        private static IList<string> playerPicturesFromFile = new List<string>();
        public static IList<string> favPlayerPicturesForFile = new List<string>();
        private static IList<string> favPlayerPicturesFromFile = new List<string>();
        private static readonly string PATH = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        public static readonly string FAV_COUNTRY = Path.Combine(PATH, "Country.txt");     
        public static readonly string FAVPLAYERS_PATH = Path.Combine(PATH, "FavPlayers.txt");
        public static readonly string PLAYERS_PATH = Path.Combine(PATH, "Players.txt");
        public static readonly string PICTURE_DIR = $@"{PATH}\Slike\";

        static FileRepo()
        {
            //  ApplicationLanguage = "hr";
            playerPicturesFromFile = ReadFromFile(PLAYERS_PATH);
            playerPicturesFromFile.ToList().ForEach(item => StorePlayerPicture(item, playerPicturesPath));
            favPlayerPicturesFromFile = ReadFromFile(FAVPLAYERS_PATH);
            favPlayerPicturesFromFile.ToList().ForEach(item => StorePlayerPicture(item, favPlayerPicturesPath));
        }

        public static void SaveFavoriteTeam(string favTeamFolder, string favTeamFile, Country team)
        {
            string x = team.FormatForWriting();

            if (!Directory.Exists(favTeamFolder))
            {
                Directory.CreateDirectory(favTeamFolder);

            }
            if (!File.Exists(favTeamFile))
            {
                File.Create(favTeamFile);
            }
            File.WriteAllText(favTeamFile, x);
        }

        //public static bool FavTeamFileExists(string path)
        //{
        //    if (File.Exists(fileFavoriteTeamPath))
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        //public static void SaveLanguage(string language, int width, int height)
        //{
        //    WriteToFile(new[] { language + SPLITTER + width.ToString() + SPLITTER + height.ToString() }, SETTINGS_PATH);
        //    LoadLanguage();

        //}

        //private static void SetLanguage(string info)
        //{
        //    string language = info.Split(SPLITTER)[0];
        //    if (language == "Hrvatski")
        //    {
        //        ApplicationLanguage = "hr";
        //    }
        //    else if (language == "Engleski")
        //    {
        //        ApplicationLanguage = "en";
        //    }
        //    string width = info.Split(SPLITTER)[1];
        //    string height = info.Split(SPLITTER)[2];
        //    if (width != "-1" || height != "-1")
        //    {
        //        ApplicationWidth = int.Parse(width);
        //        ApplicationHeight = int.Parse(height);
        //    }
        //}
        //public static bool LoadLanguage()
        //{
        //    List<string> temp = ReadFromFile(SETTINGS_PATH);
        //    if (temp.Count == 0 || temp[0] == "")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        SetLanguage(temp[0]);
        //    }
        //    return true;
        //}


        //dadadada
        //public static bool CheckLanguage()
        //{
        //    if (!File.Exists(fileLanguagePath)) return false;

        //    if (ReadLanguagePreference() == "Hrvatski" || ReadLanguagePreference() == "English") return true;

        //    return false;
        //}

        public static bool LanguageExists(string langPath)
        {
            if (!Directory.Exists("../../lang"))
            {
                Directory.CreateDirectory("../../lang");
            }

            if (File.Exists(langPath))
            {
                if (File.ReadAllText(langPath) == "English" || File.ReadAllText(langPath) == "Hrvatski")
                {
                    return true;
                }
            }
            return false;
        }



        //public static string ReadLanguagePreference()
        //{
        //    if (!File.Exists(fileLanguagePath)) return null;

        //    return File.ReadAllText(fileLanguagePath);
        //}

        //public static void WriteLanguagePreference(string lang)
        //{
        //    using (StreamWriter tw = new StreamWriter(fileLanguagePath))
        //    {
        //        tw.Write(lang);
        //    }
        //}

        public static List<string> ReadFromFile(string PATH)
        {
            List<string> lines = new List<string>();
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(PATH))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
        public static void WriteToFile(string[] content, string path)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                for (int i = 0; i < content.Length; i++)
                {
                    file.WriteLine(content[i]);
                }
            }
        }
        // hahahahhaaahahahahahahah //
        public static List<Country> ReadFromTextFile(string path)
        {
            List<Country> loadingTeam = new List<Country>();
            using (StreamReader tr = new StreamReader(path))
            {
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    loadingTeam.Add(Country.ParseFromFileLine(line));
                }
            }
            return loadingTeam;
        }

        #region

        //public static void WriteToTextFile(List<Country> teams)
        //{
        //    using (StreamWriter tw = new StreamWriter(fileTeamPath))
        //    {
        //        foreach (var t in teams)
        //        {
        //            tw.WriteLine(t.FormatForWriting());
        //        }
        //    }
        //}

        //internal static string[] LoadPlayersImages()
        //{
        //    if (!Directory.Exists(playersPicturesPath))
        //        Directory.CreateDirectory(playersPicturesPath);

        //    List<String> loadPaths = new List<string>();

        //    string[] files = Directory.GetFiles(playersPicturesPath);
        //    if (files.Length == 0) return null;

        //    var picFiles = Directory.EnumerateFiles(playersPicturesPath);
        //    foreach (string curr in picFiles)
        //    {
        //        loadPaths.Add(curr);
        //    }
        //    return loadPaths.ToArray();
        //}

        //public static void SaveFavoritePlayers(List<Player> currentPlayers, Country favoriteTeam)
        //{

        //    if (!Directory.Exists(favoritePlayersPath))
        //        Directory.CreateDirectory(favoritePlayersPath);

        //    string filename = favoritePlayersPath + favoriteTeam.FifaCode + ".txt";

        //    if (File.Exists(filename))
        //        File.Delete(filename);

        //    using (StreamWriter tw = new StreamWriter(filename))
        //    {
        //        foreach (Player t in currentPlayers)
        //        {
        //            if (t.Favorite)
        //                tw.WriteLine(t.FormatForWriting());
        //        }
        //    }
        //}

        //internal static async Task<List<Player>> LoadFavoritePlayers(string fifa_code)
        //{
        //    if (!Directory.Exists(favoritePlayersPath))
        //        Directory.CreateDirectory(favoritePlayersPath);

        //    List<Player> fav = new List<Player>();


        //    if (!File.Exists($"{favoritePlayersPath}{fifa_code}.txt")) return fav;
        //    string[] currentFavTeamPath = Directory.GetFiles(favoritePlayersPath, fifa_code + ".txt");

        //    if (currentFavTeamPath.Length == 0 || currentFavTeamPath.Length > 1) return fav;
        //    if (currentFavTeamPath.Length > 1)
        //    {
        //        File.Delete(currentFavTeamPath + ".txt");
        //    }


        //    using (StreamReader sr = new StreamReader(currentFavTeamPath[0]))
        //    {

        //        string line;
        //        while (true)
        //        {
        //            line = await sr.ReadLineAsync();
        //            if (line == null) break;

        //            fav.Add(Player.ParseFromFileLine(line));
        //        }

        //    }


        //    return fav;
        //}
        #endregion
        public static Bitmap LoadPlayerPictureFromCache(string name, IDictionary<string, string> location)
        {
            foreach (var picture in location)
            {
                if (picture.Key == name)
                {
                    if (File.Exists(picture.Value))
                    {
                        return new Bitmap(picture.Value);
                    }
                }
            }
            return null;
        }
        public static void FillPlayerDictionary(string name, Bitmap image, IDictionary<string, Bitmap> location)
        {
            if (location.ContainsKey(name))
            {
                location[name] = image;
            }
            else
            {
                location.Add(name, image);
            }
        }
        public static void StorePlayerPicture(string picture, IDictionary<string, string> location)
        {
            var p_name = picture.Split(SPLITTER)[0];
            var path = picture.Split(SPLITTER)[1];
            if (location.ContainsKey(p_name))
            {
                location[p_name] = $"{path}";
            }
            else
            {
                location.Add(p_name, $"{path}");
            }
        }
        private static void StorePlayerPicture(string p_name, OpenFileDialog ofd, IDictionary<string, string> location)
        {
            if (location.ContainsKey(p_name) || favPlayerPicturesPath.ContainsKey(p_name))
            {
                location[p_name] = $"{PICTURE_DIR}{ofd.SafeFileName}";
            }
            else
            {
                location.Add(p_name, $"{PICTURE_DIR}{ofd.SafeFileName}");
            }
        }
        public static Bitmap ChoosePicture(string p_name, bool favorite)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (favorite)
                {
                    StorePlayerPicture(p_name, ofd, favPlayerPicturesPath);
                }
                else
                {
                    StorePlayerPicture(p_name, ofd, playerPicturesPath);
                }

                if (!File.Exists($"{PICTURE_DIR}{ofd.SafeFileName}"))
                {
                    File.Copy(ofd.FileName, $"{PICTURE_DIR}{ofd.SafeFileName}");
                }
                return new Bitmap(ofd.FileName);
            }
            return null;
        }
    }

}

