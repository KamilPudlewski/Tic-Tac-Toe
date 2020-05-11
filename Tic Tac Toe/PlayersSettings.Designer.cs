namespace Tic_Tac_Toe
{
    partial class PlayersSettings
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
            this.player1ComboBox = new System.Windows.Forms.ComboBox();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.player2ComboBox = new System.Windows.Forms.ComboBox();
            this.versusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1ComboBox
            // 
            this.player1ComboBox.FormattingEnabled = true;
            this.player1ComboBox.Location = new System.Drawing.Point(12, 95);
            this.player1ComboBox.Name = "player1ComboBox";
            this.player1ComboBox.Size = new System.Drawing.Size(175, 24);
            this.player1ComboBox.TabIndex = 1;
            this.player1ComboBox.SelectedIndexChanged += new System.EventHandler(this.player1ComboBox_SelectedIndexChanged);
            // 
            // player1Label
            // 
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player1Label.Location = new System.Drawing.Point(12, 45);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(175, 23);
            this.player1Label.TabIndex = 2;
            this.player1Label.Text = "Player 1";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2Label
            // 
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.player2Label.Location = new System.Drawing.Point(315, 45);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(175, 23);
            this.player2Label.TabIndex = 3;
            this.player2Label.Text = "Player 2";
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2ComboBox
            // 
            this.player2ComboBox.FormattingEnabled = true;
            this.player2ComboBox.Location = new System.Drawing.Point(315, 95);
            this.player2ComboBox.Name = "player2ComboBox";
            this.player2ComboBox.Size = new System.Drawing.Size(175, 24);
            this.player2ComboBox.TabIndex = 4;
            this.player2ComboBox.SelectedIndexChanged += new System.EventHandler(this.player2ComboBox_SelectedIndexChanged);
            // 
            // versusLabel
            // 
            this.versusLabel.AutoSize = true;
            this.versusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versusLabel.Location = new System.Drawing.Point(217, 56);
            this.versusLabel.Name = "versusLabel";
            this.versusLabel.Size = new System.Drawing.Size(74, 46);
            this.versusLabel.TabIndex = 6;
            this.versusLabel.Text = "VS";
            // 
            // PlayersSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 164);
            this.Controls.Add(this.versusLabel);
            this.Controls.Add(this.player2ComboBox);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.player1ComboBox);
            this.Name = "PlayersSettings";
            this.Text = "Players Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox player1ComboBox;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.ComboBox player2ComboBox;
        private System.Windows.Forms.Label versusLabel;
    }
}