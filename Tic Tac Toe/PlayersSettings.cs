using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class PlayersSettings : Form
    {
        private SettingsManager settings;

        public PlayersSettings(SettingsManager settings)
        {
            InitializeComponent();
            PrepareSettingsComboBoxes();
            this.settings = settings;
            settings.LoadSettings();

            player1ComboBox.SelectedIndex = settings.GetPlayer1();
            player2ComboBox.SelectedIndex = settings.GetPlayer2();
        }

        private void PrepareSettingsComboBoxes()
        {
            string[] playerTypes = { "Human", "Randomly", "MiniMax", "AlphaBeta" };

            player1ComboBox.Items.AddRange(playerTypes);
            player2ComboBox.Items.AddRange(playerTypes);
        }

        private void player1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.SetPlayer1(player1ComboBox.SelectedIndex);
            settings.SaveSettings();
        }

        private void player2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.SetPlayer2(player2ComboBox.SelectedIndex);
            settings.SaveSettings();
        }
    }
}
