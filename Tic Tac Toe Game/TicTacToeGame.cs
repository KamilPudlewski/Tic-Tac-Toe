using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe;

namespace Tic_Tac_Toe_Game
{
    public partial class TicTacToeGame : Form
    {
        private SettingsManager settings = new SettingsManager();
        private TicTacToe game = new TicTacToe();
        private int timeBetweenComputerMoves = 200;

        public TicTacToeGame()
        {
            InitializeComponent();
            PrepareGameBoard();
            LoadPlayersSettings();

            ComputerMove();
        }

        private void PrepareGameBoard()
        {
            game.SetGameBoard(settings.GetRows(), settings.GetColumns(), settings.GetWiningSeriesCount());

            string buttonName = "boardButton";
            Point buttonStartLocation = new Point(10, 30);
            int locationXOffset = 80;
            int locationYOffset = 80;
            int tabIndex = 100;

            // Change main window size
            int width = (2 * buttonStartLocation.X) + (80 * game.GetGameBoard().columns) + 20;
            int height = (2 * buttonStartLocation.Y) + (80 * game.GetGameBoard().rows) + 20;

            this.Size = new System.Drawing.Size(width, height);

            Point buttonLocation = buttonStartLocation;

            for (int i = 0; i < game.GetGameBoard().rows; i++)
            {
                for (int j = 0; j < game.GetGameBoard().columns; j++)
                {
                    CreateButton(buttonName + i + j, buttonLocation, tabIndex);

                    tabIndex++;
                    buttonLocation = new Point(buttonLocation.X + locationXOffset, buttonLocation.Y);
                }
                buttonLocation = new Point(buttonStartLocation.X, buttonLocation.Y + locationYOffset);
            }
        }

        private void CreateButton(string buttonName, Point location, int tabIndex)
        {
            Button button = new Button();

            button.BackColor = System.Drawing.SystemColors.Window;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            button.Location = location;
            button.Name = buttonName;
            button.Size = new System.Drawing.Size(80, 80);
            button.TabIndex = tabIndex;
            button.TabStop = false;
            button.UseVisualStyleBackColor = false;
            button.Click += new System.EventHandler(this.button_Click);

            Controls.Add(button);
        }

        private void LoadPlayersSettings()
        {
            game.SetPlayer1(GetPlayerType(settings.GetPlayer1()));
            game.SetPlayer2(GetPlayerType(settings.GetPlayer2()));
        }

        private TicTacToe.PlayerType GetPlayerType(int playerType)
        {
            switch (playerType)
            {
                case 0:
                    return TicTacToe.PlayerType.Human;
                case 1:
                    return TicTacToe.PlayerType.Randomly;
                case 2:
                    return TicTacToe.PlayerType.MiniMax;
                case 3:
                    return TicTacToe.PlayerType.AlphaBeta;
                default:
                    return TicTacToe.PlayerType.Human;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPlayersSettings();
            ResetButtons();

            if (settings.GetRows() != game.GetGameBoard().rows || settings.GetColumns() != game.GetGameBoard().columns)
            {
                DeleteButtons();
                PrepareGameBoard();
                LoadPlayersSettings();
            }

            if (settings.GetWiningSeriesCount() != game.GetGameBoard().winingSeriesCount)
            {
                game.SetGameBoard(settings.GetRows(), settings.GetColumns(), settings.GetWiningSeriesCount());
                LoadPlayersSettings();
            }

            game.ResetGame();

            while (!CheckButtonResetStatus())
            {
                Thread.Sleep(1000);
            }

            ComputerMove();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSettings enemySettings = new GameSettings(settings);
            enemySettings.Show();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (game.IsHumanPlayerMove())
            {
                Tuple<int, int> move = GetButtonBoardPosition(sender);
                game.HumanPlayerNextMove(move);
                UpdateButton(move.Item1, move.Item2, game.GetNextPlayer().Mark);
            }

            CheckForWinner();
            ComputerMove();
        }

        void ComputerMove()
        {
            while (game.IsComputerPlayerMove() && !game.GetGameOverStatus())
            {
                Thread.Sleep(timeBetweenComputerMoves);

                game.ComputerPlayerNextMove();
                UpdateButton(game.GetLastMove().Item1, game.GetLastMove().Item2, game.GetNextPlayer().Mark);

                CheckForWinner();
            }
        }

        void UpdateButton(int row, int column, char mark)
        {
            Control button = new Control();

            string buttonName = "boardButton" + row + column;
            button = Controls[buttonName];

            button.Text = mark.ToString();
            button.Enabled = false;
        }


        void UpdateButtonColor(int row, int column, Color color)
        {
            Control button = new Control();

            string buttonName = "boardButton" + row + column;
            button = Controls[buttonName];
            button.BackColor = color;
        }

        Tuple<int, int> GetButtonBoardPosition(object button)
        {
            string buttonName = ((Control)button).Name;
            string buttonMark = "boardButton";

            if (buttonName.Contains(buttonMark))
            {
                int x = Int32.Parse(buttonName.Substring(buttonName.Length - 2, 1));
                int y = Int32.Parse(buttonName.Substring(buttonName.Length - 1));

                return new Tuple<int, int>(x, y);
            }

            throw new Exception("Bad button!");
        }

        private void CheckForWinner()
        {
            if (game.GetWinnerID() != 0)
            {
                ColorWinnerPosition();
                DisableButtons();
                MessageBox.Show(game.GetWinnerMark() + " Wins!", "Game Over!");
            }
            else if (game.GetGameOverStatus())
            {
                MessageBox.Show("Draw!", "Game Over!");
            }
        }

        private void ColorWinnerPosition()
        {
            List<Tuple<int, int>> winnerPositions = game.GetWinnerPositions();

            for (int i = 0; i < winnerPositions.Count; i++)
            {
                UpdateButtonColor(winnerPositions[i].Item1, winnerPositions[i].Item2, Color.Lime);
            }
        }

        private void ColorWinnerPositionReset()
        {
            List<Tuple<int, int>> winnerPositions = game.GetWinnerPositions();

            if (winnerPositions.Count != 0)
            {
                for (int i = 0; i < winnerPositions.Count; i++)
                {
                    UpdateButtonColor(winnerPositions[i].Item1, winnerPositions[i].Item2, Color.White);
                }
                winnerPositions.Clear();
            }
        }

        private void ResetButtons()
        {
            for (int i = 0; i < game.GetGameBoard().rows; i++)
            {
                for (int j = 0; j < game.GetGameBoard().columns; j++)
                {
                    Controls["boardButton" + i + j].Text = "";
                    Controls["boardButton" + i + j].Enabled = true;
                }
            }

            ColorWinnerPositionReset();
        }

        private bool CheckButtonResetStatus()
        {
            bool resetStatus = true;

            try
            {
                foreach (Component c in Controls)
                {
                    Button button = (Button)c;
                    button.Enabled = true;
                    if (button.Text != "")
                        resetStatus = false;
                }
            }
            catch { }

            return resetStatus;
        }

        private void DisableButtons()
        {
            for (int i = 0; i < game.GetGameBoard().rows; i++)
            {
                for (int j = 0; j < game.GetGameBoard().columns; j++)
                {
                    Controls["boardButton" + i + j].Enabled = false;
                }
            }
        }

        private void DeleteButtons()
        {
            for (int i = 0; i < game.GetGameBoard().rows; i++)
            {
                for (int j = 0; j < game.GetGameBoard().columns; j++)
                {
                    Control button = Controls["boardButton" + i + j];
                    Controls.Remove(button);
                }
            }
        }
    }
}
