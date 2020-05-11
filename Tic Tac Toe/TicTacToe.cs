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

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        private SettingsManager settings = new SettingsManager();

        private static GameBoard gameBoard = new GameBoard();
        private IPlayer player1;
        private IPlayer player2;

        private bool gameOverStatus = false;
        private List<Tuple<int, int>> winnerPositions = new List<Tuple<int, int>>();
        private int timeBetweenComputerMoves = 200;
        
        public TicTacToe()
        {
            InitializeComponent();
            LoadPlayersSettings();
            ComputerMove();
        }

        private void LoadPlayersSettings()
        {
            SetPlayerType(ref player1, settings.GetPlayer1(), 1, 'X');
            SetPlayerType(ref player2, settings.GetPlayer2(), 2, 'O');
        }

        private void SetPlayerType(ref IPlayer player, int playerType, int playerNumber, char playerMark)
        {
            switch (playerType)
            {
                case 0:
                    player = new Human(playerNumber, playerMark);
                    break;
                case 1:
                    player = new Randomly(gameBoard, playerNumber, playerMark);
                    break;
                case 2:
                    player = new MiniMax(gameBoard, playerNumber, playerMark);
                    break;
                case 3:
                    player = new AlphaBeta(gameBoard, playerNumber, playerMark);
                    break;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetButtons();
            LoadPlayersSettings();
            gameOverStatus = false;
            gameBoard.Reset();

            while (!CheckButtonResetStatus())
            {
                Thread.Sleep(100);
            }

            ComputerMove();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayersSettings enemySettings = new PlayersSettings(settings);
            enemySettings.Show();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(gameBoard.IsPlayer1Turn())
            {
                if (player1.GetType().Equals(typeof(Human)))
                {
                    Tuple<int, int> move = GetButtonBoardPosition(sender);
                    gameBoard.Move(move.Item1, move.Item2, player1.ID);
                    UpdateButton(move.Item1, move.Item2, player1.Mark);
                }
                else
                {
                    Tuple<int, int> move = player1.NextMove();
                    UpdateButton(move.Item1, move.Item2, player1.Mark);
                }
            }
            else
            {
                if (player2.GetType().Equals(typeof(Human)))
                {
                    Tuple<int, int> move = GetButtonBoardPosition(sender);
                    gameBoard.Move(move.Item1, move.Item2, player2.ID);
                    UpdateButton(move.Item1, move.Item2, player2.Mark);
                }
                else
                {
                    Tuple<int, int> move = player2.NextMove();
                    UpdateButton(move.Item1, move.Item2, player2.Mark);
                }
            }

            CheckForWinner();
            ComputerMove();
        }

        void ComputerMove()
        {
            while (IsComputerTurn() && !gameOverStatus)
            {
                Thread.Sleep(timeBetweenComputerMoves);
                if (gameBoard.IsPlayer1Turn())
                {
                    Tuple<int, int> move = player1.NextMove();
                    UpdateButton(move.Item1, move.Item2, player1.Mark);
                }
                else
                {
                    Tuple<int, int> move = player2.NextMove();
                    UpdateButton(move.Item1, move.Item2, player2.Mark);
                }

                CheckForWinner();
            }
        }

        void UpdateButton(int row, int column, char mark)
        {
            Control button = new Control();

            if (row.Equals(0) && column.Equals(0))
                button = this.Controls["a1Button"];
            else if (row.Equals(0) && column.Equals(1))
                button = this.Controls["a2Button"];
            else if (row.Equals(0) && column.Equals(2))
                button = this.Controls["a3Button"];
            else if (row.Equals(1) && column.Equals(0))
                button = this.Controls["b1Button"];
            else if (row.Equals(1) && column.Equals(1))
                button = this.Controls["b2Button"];
            else if (row.Equals(1) && column.Equals(2))
                button = this.Controls["b3Button"];
            else if (row.Equals(2) && column.Equals(0))
                button = this.Controls["c1Button"];
            else if (row.Equals(2) && column.Equals(1))
                button = this.Controls["c2Button"];
            else if (row.Equals(2) && column.Equals(2))
                button = this.Controls["c3Button"];

            button.Text = mark.ToString();
            button.Enabled = false;
        }


        void UpdateButtonColor(int row, int column, Color color)
        {
            Control button = new Control();

            if (row.Equals(0) && column.Equals(0))
                button = this.Controls["a1Button"];
            else if (row.Equals(0) && column.Equals(1))
                button = this.Controls["a2Button"];
            else if (row.Equals(0) && column.Equals(2))
                button = this.Controls["a3Button"];
            else if (row.Equals(1) && column.Equals(0))
                button = this.Controls["b1Button"];
            else if (row.Equals(1) && column.Equals(1))
                button = this.Controls["b2Button"];
            else if (row.Equals(1) && column.Equals(2))
                button = this.Controls["b3Button"];
            else if (row.Equals(2) && column.Equals(0))
                button = this.Controls["c1Button"];
            else if (row.Equals(2) && column.Equals(1))
                button = this.Controls["c2Button"];
            else if (row.Equals(2) && column.Equals(2))
                button = this.Controls["c3Button"];

            button.BackColor = color;
        }

        Tuple<int,int> GetButtonBoardPosition(object button)
        {
            switch (((Control)button).Name)
            {
               case "a1Button":
                    return new Tuple<int, int>(0, 0);
                case "a2Button":
                    return new Tuple<int, int>(0, 1);
                case "a3Button":
                    return new Tuple<int, int>(0, 2);
                case "b1Button":
                    return new Tuple<int, int>(1, 0);
                case "b2Button":
                    return new Tuple<int, int>(1, 1);
                case "b3Button":
                    return new Tuple<int, int>(1, 2);
                case "c1Button":
                    return new Tuple<int, int>(2, 0);
                case "c2Button":
                    return new Tuple<int, int>(2, 1);
                case "c3Button":
                    return new Tuple<int, int>(2, 2);
                default:
                    throw new Exception("Bad button!");
            }
        }

        private bool IsComputerTurn()
        {
            if(gameBoard.IsPlayer1Turn())
            {
                if (!player1.GetType().Equals(typeof(Human)))
                    return true;
            }
            else
            {
                if (!player2.GetType().Equals(typeof(Human)))
                    return true;
            }
            return false;
        }

        private void CheckForWinner()
        {
            if (gameBoard.CheckWinner() != 0)
            {
                ColorWinnerPosition();
                gameOverStatus = true;
                DisableButtons();
                string winner = "";
                if (gameBoard.IsPlayer1Turn())
                    winner = player2.Mark.ToString();
                else
                    winner = player1.Mark.ToString();
                MessageBox.Show(winner + " Wins!", "Game Over!");
            }
            else if (gameBoard.turnCount == 9)
            {
                gameOverStatus = true;
                MessageBox.Show("Draw!", "Game Over!");
            }
        }

        private void ColorWinnerPosition()
        {
            winnerPositions = gameBoard.GetWinnerPositions();

            for (int i = 0; i < winnerPositions.Count; i++)
            {
                UpdateButtonColor(winnerPositions[i].Item1, winnerPositions[i].Item2, Color.Lime);
            }
        }

        private void ColorWinnerPositionReset()
        {
            if (winnerPositions.Count != 0)
            {
                for (int i = 0; i < winnerPositions.Count; i++)
                {
                    UpdateButtonColor(winnerPositions[i].Item1, winnerPositions[i].Item2, Color.White);
                }
                winnerPositions = new List<Tuple<int, int>>();
            }
        }

        private void ResetButtons()
        {
            a1Button.Text = "";
            a2Button.Text = "";
            a3Button.Text = "";
            b1Button.Text = "";
            b2Button.Text = "";
            b3Button.Text = "";
            c1Button.Text = "";
            c2Button.Text = "";
            c3Button.Text = "";

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
            try
            {
                foreach (Component c in Controls)
                {
                    Button button = (Button)c;
                    button.Enabled = false;
                }
            }
            catch { }
        }
    }
}
