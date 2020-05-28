namespace Tic_Tac_Toe_Game
{
    partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardSettingsLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.winingSeriesLabel = new System.Windows.Forms.Label();
            this.winingSeriesTextBox = new System.Windows.Forms.TextBox();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.playerSettingsLabel = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.player1ComboBox = new System.Windows.Forms.ComboBox();
            this.versusLabel = new System.Windows.Forms.Label();
            this.player2ComboBox = new System.Windows.Forms.ComboBox();
            this.player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardSettingsLabel
            // 
            this.boardSettingsLabel.AutoSize = true;
            this.boardSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.boardSettingsLabel.Location = new System.Drawing.Point(121, 22);
            this.boardSettingsLabel.Name = "boardSettingsLabel";
            this.boardSettingsLabel.Size = new System.Drawing.Size(275, 46);
            this.boardSettingsLabel.TabIndex = 0;
            this.boardSettingsLabel.Text = "Board settings";
            // 
            // rowsLabel
            // 
            this.rowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rowsLabel.Location = new System.Drawing.Point(29, 86);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(175, 23);
            this.rowsLabel.TabIndex = 1;
            this.rowsLabel.Text = "Rows";
            this.rowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rowsTextBox.Location = new System.Drawing.Point(34, 132);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(175, 27);
            this.rowsTextBox.TabIndex = 2;
            this.rowsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rowsTextBox.TextChanged += new System.EventHandler(this.rowsTextBox_KeyPress);
            // 
            // columnsLabel
            // 
            this.columnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.columnsLabel.Location = new System.Drawing.Point(308, 86);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(170, 23);
            this.columnsLabel.TabIndex = 3;
            this.columnsLabel.Text = "Columns";
            this.columnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.columnsTextBox.Location = new System.Drawing.Point(303, 132);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(175, 27);
            this.columnsTextBox.TabIndex = 4;
            this.columnsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnsTextBox.TextChanged += new System.EventHandler(this.columnsTextBox_KeyPress);
            // 
            // winingSeriesLabel
            // 
            this.winingSeriesLabel.AutoSize = true;
            this.winingSeriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.winingSeriesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.winingSeriesLabel.Location = new System.Drawing.Point(167, 180);
            this.winingSeriesLabel.Name = "winingSeriesLabel";
            this.winingSeriesLabel.Size = new System.Drawing.Size(183, 25);
            this.winingSeriesLabel.TabIndex = 5;
            this.winingSeriesLabel.Text = "Wining series count";
            // 
            // winingSeriesTextBox
            // 
            this.winingSeriesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.winingSeriesTextBox.Location = new System.Drawing.Point(159, 210);
            this.winingSeriesTextBox.Name = "winingSeriesTextBox";
            this.winingSeriesTextBox.Size = new System.Drawing.Size(201, 27);
            this.winingSeriesTextBox.TabIndex = 6;
            this.winingSeriesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.winingSeriesTextBox.TextChanged += new System.EventHandler(this.winingSeriesTextBox_KeyPress);
            // 
            // separatorLabel
            // 
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(10, 252);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(480, 2);
            this.separatorLabel.TabIndex = 7;
            // 
            // playerSettingsLabel
            // 
            this.playerSettingsLabel.AutoSize = true;
            this.playerSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.playerSettingsLabel.Location = new System.Drawing.Point(121, 274);
            this.playerSettingsLabel.Name = "playerSettingsLabel";
            this.playerSettingsLabel.Size = new System.Drawing.Size(281, 46);
            this.playerSettingsLabel.TabIndex = 8;
            this.playerSettingsLabel.Text = "Player settings";
            // 
            // player1Label
            // 
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player1Label.Location = new System.Drawing.Point(29, 334);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(175, 23);
            this.player1Label.TabIndex = 9;
            this.player1Label.Text = "Player 1";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1ComboBox
            // 
            this.player1ComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.player1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player1ComboBox.FormattingEnabled = true;
            this.player1ComboBox.Location = new System.Drawing.Point(34, 373);
            this.player1ComboBox.Name = "player1ComboBox";
            this.player1ComboBox.Size = new System.Drawing.Size(175, 28);
            this.player1ComboBox.TabIndex = 10;
            this.player1ComboBox.SelectedIndexChanged += new System.EventHandler(this.player1ComboBox_SelectedIndexChanged);
            // 
            // versusLabel
            // 
            this.versusLabel.AutoSize = true;
            this.versusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versusLabel.Location = new System.Drawing.Point(227, 355);
            this.versusLabel.Name = "versusLabel";
            this.versusLabel.Size = new System.Drawing.Size(74, 46);
            this.versusLabel.TabIndex = 11;
            this.versusLabel.Text = "VS";
            // 
            // player2ComboBox
            // 
            this.player2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player2ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player2ComboBox.FormattingEnabled = true;
            this.player2ComboBox.Location = new System.Drawing.Point(315, 373);
            this.player2ComboBox.Name = "player2ComboBox";
            this.player2ComboBox.Size = new System.Drawing.Size(175, 28);
            this.player2ComboBox.TabIndex = 13;
            this.player2ComboBox.SelectedIndexChanged += new System.EventHandler(this.player2ComboBox_SelectedIndexChanged);
            // 
            // player2Label
            // 
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player2Label.Location = new System.Drawing.Point(315, 334);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(175, 23);
            this.player2Label.TabIndex = 12;
            this.player2Label.Text = "Player 2";
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(502, 423);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player2ComboBox);
            this.Controls.Add(this.versusLabel);
            this.Controls.Add(this.player1ComboBox);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.playerSettingsLabel);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.winingSeriesTextBox);
            this.Controls.Add(this.winingSeriesLabel);
            this.Controls.Add(this.columnsTextBox);
            this.Controls.Add(this.columnsLabel);
            this.Controls.Add(this.rowsTextBox);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.boardSettingsLabel);
            this.Name = "GameSettings";
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardSettingsLabel;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.Label winingSeriesLabel;
        private System.Windows.Forms.TextBox winingSeriesTextBox;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label playerSettingsLabel;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.ComboBox player1ComboBox;
        private System.Windows.Forms.Label versusLabel;
        private System.Windows.Forms.ComboBox player2ComboBox;
        private System.Windows.Forms.Label player2Label;
    }
}