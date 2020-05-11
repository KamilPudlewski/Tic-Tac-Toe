using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class SettingsManager
    {
        private string configPath = "Configs";
        private string configFile = "players.cfg";

        private int player1Type;
        private int player2Type;

        public SettingsManager()
        {
            LoadSettings();
        }

        public void LoadSettings()
        {
            if (File.Exists(Path.Combine(configPath, configFile)))
            {
                string[] settings = System.IO.File.ReadAllLines(Path.Combine(configPath, configFile));

                foreach (string line in settings)
                {
                    String[] actualSetting = line.Split();

                    switch (actualSetting[0])
                    {
                        case "Player1:":
                            player1Type = Int32.Parse(actualSetting[1]);
                            break;
                        case "Player2:":
                            player2Type = Int32.Parse(actualSetting[1]);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            List<string> lines = SetPlayersSettings();

            if (File.Exists(Path.Combine(configPath, configFile)))
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(configPath, configFile)))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(configPath);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(configPath, configFile)))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
        }

        private List<string> SetPlayersSettings()
        {
            List<string> settings = new List<string>();

            settings.Add("Player1: " + player1Type);
            settings.Add("Player2: " + player2Type);

            return settings;
        }

        public void SetPlayer1(int index)
        {
            player1Type = index;
        }

        public void SetPlayer2(int index)
        {
            player2Type = index;
        }

        public int GetPlayer1()
        {
            return player1Type;
        }

        public int GetPlayer2()
        {
            return player2Type;
        }
    }
}
