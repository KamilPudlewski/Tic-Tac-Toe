using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    public class SettingsManager
    {
        private string configPath = "Configs";
        private string configFile = "settings.cfg";

        private int rowsCount;
        private int columnsCount;
        private int winingSeriesCount;

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
                        case "Rows:":
                            rowsCount = Int32.Parse(actualSetting[1]);
                            break;
                        case "Columns:":
                            columnsCount = Int32.Parse(actualSetting[1]);
                            break;
                        case "WiningSeries:":
                            winingSeriesCount = Int32.Parse(actualSetting[1]);
                            break;
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
            if (File.Exists(Path.Combine(configPath, configFile)))
            {
                List<string> lines = SetPlayersSettings();

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(configPath, configFile)))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(configPath);
                List<string> lines = SetDefaultPlayersSettings();

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

            settings.Add("Rows: " + rowsCount);
            settings.Add("Columns: " + columnsCount);
            settings.Add("WiningSeries: " + winingSeriesCount);
            settings.Add("Player1: " + player1Type);
            settings.Add("Player2: " + player2Type);

            return settings;
        }

        private List<string> SetDefaultPlayersSettings()
        {
            List<string> settings = new List<string>();

            settings.Add("Rows: " + 3);
            settings.Add("Columns: " + 3);
            settings.Add("WiningSeries: " + 3);
            settings.Add("Player1: " + 0);
            settings.Add("Player2: " + 3);

            return settings;
        }

        public void SetRows(int size)
        {
            rowsCount = size;
        }

        public int GetRows()
        {
            return rowsCount;
        }

        public void SetColumns(int size)
        {
            columnsCount = size;
        }

        public int GetColumns()
        {
            return columnsCount;
        }

        public void SetWiningSeriesCount(int winingSeries)
        {
            winingSeriesCount = winingSeries;
        }

        public int GetWiningSeriesCount()
        {
            return winingSeriesCount;
        }

        public void SetPlayer1(int index)
        {
            player1Type = index;
        }

        public int GetPlayer1()
        {
            return player1Type;
        }

        public void SetPlayer2(int index)
        {
            player2Type = index;
        }

        public int GetPlayer2()
        {
            return player2Type;
        }
    }
}
