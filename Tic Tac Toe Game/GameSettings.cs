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

namespace Tic_Tac_Toe_Game
{
    public partial class GameSettings : Form
    {
        private SettingsManager settings;

        public GameSettings(SettingsManager settings)
        {
            InitializeComponent();
            PrepareSettingsComboBoxes();
            this.settings = settings;
            settings.LoadSettings();

            rowsTextBox.Text = settings.GetRows().ToString();
            columnsTextBox.Text = settings.GetColumns().ToString();
            winingSeriesTextBox.Text = settings.GetWiningSeriesCount().ToString();
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

        private void rowsTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(rowsTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                rowsTextBox.Text = rowsTextBox.Text.Remove(rowsTextBox.Text.Length - 1);
            }

            if (Int32.Parse(rowsTextBox.Text) < 3)
                rowsTextBox.Text = "3";

            settings.SetRows(Int32.Parse(rowsTextBox.Text));
            settings.SaveSettings();
            WiningSerieCheckBoundaryCondition();
        }

        private void columnsTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(columnsTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                columnsTextBox.Text = columnsTextBox.Text.Remove(columnsTextBox.Text.Length - 1);
            }

            if (Int32.Parse(columnsTextBox.Text) < 3)
                columnsTextBox.Text = "3";

            settings.SetColumns(Int32.Parse(columnsTextBox.Text));
            settings.SaveSettings();
            WiningSerieCheckBoundaryCondition();
        }

        private void winingSeriesTextBox_KeyPress(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(winingSeriesTextBox.Text, "[^0-9,.]"))
            {
                MessageBox.Show("Please enter numbers only!", "Input value error");
                winingSeriesTextBox.Text = winingSeriesTextBox.Text.Remove(winingSeriesTextBox.Text.Length - 1);
            }

            if (Int32.Parse(winingSeriesTextBox.Text) < 3)
                winingSeriesTextBox.Text = "3";
            else if (Int32.Parse(winingSeriesTextBox.Text) > Math.Min(settings.GetRows(), settings.GetColumns()))
                winingSeriesTextBox.Text = Math.Min(settings.GetRows(), settings.GetColumns()).ToString();

            settings.SetWiningSeriesCount(Int32.Parse(winingSeriesTextBox.Text));
            settings.SaveSettings();
        }

        private void WiningSerieCheckBoundaryCondition()
        {
            if (settings.GetWiningSeriesCount() > Math.Min(settings.GetRows(), settings.GetColumns()))
            {
                winingSeriesTextBox.Text = Math.Min(settings.GetRows(), settings.GetColumns()).ToString();
                settings.SetWiningSeriesCount(Int32.Parse(winingSeriesTextBox.Text));
                settings.SaveSettings();
            }
        }
    }
}
