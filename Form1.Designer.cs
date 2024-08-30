namespace Pong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            rightPlayer = new PictureBox();
            leftPlayer = new PictureBox();
            ball = new PictureBox();
            clockTimer = new System.Windows.Forms.Timer(components);
            startGame = new Button();
            winner = new Label();
            player1Score = new Label();
            player2Score = new Label();
            ((System.ComponentModel.ISupportInitialize)rightPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // rightPlayer
            // 
            rightPlayer.BackColor = Color.White;
            rightPlayer.Location = new Point(759, 162);
            rightPlayer.Name = "rightPlayer";
            rightPlayer.Size = new Size(29, 74);
            rightPlayer.TabIndex = 0;
            rightPlayer.TabStop = false;
            // 
            // leftPlayer
            // 
            leftPlayer.BackColor = Color.White;
            leftPlayer.Location = new Point(12, 161);
            leftPlayer.Name = "leftPlayer";
            leftPlayer.Size = new Size(29, 74);
            leftPlayer.TabIndex = 1;
            leftPlayer.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.White;
            ball.Location = new Point(386, 188);
            ball.Name = "ball";
            ball.Size = new Size(28, 28);
            ball.TabIndex = 2;
            ball.TabStop = false;
            // 
            // clockTimer
            // 
            clockTimer.Interval = 10;
            clockTimer.Tick += ClockTimer_Tick;
            // 
            // startGame
            // 
            startGame.Location = new Point(337, 173);
            startGame.Name = "startGame";
            startGame.Size = new Size(130, 54);
            startGame.TabIndex = 3;
            startGame.Text = "Start Game?";
            startGame.UseVisualStyleBackColor = true;
            startGame.Click += StartGame_Click;
            // 
            // winner
            // 
            winner.AutoSize = true;
            winner.Font = new Font("Segoe UI", 30F);
            winner.ForeColor = Color.White;
            winner.Location = new Point(258, 116);
            winner.Name = "winner";
            winner.Size = new Size(0, 54);
            winner.TabIndex = 4;
            // 
            // player1Score
            // 
            player1Score.AutoSize = true;
            player1Score.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            player1Score.ForeColor = Color.White;
            player1Score.Location = new Point(12, 9);
            player1Score.Name = "player1Score";
            player1Score.Size = new Size(68, 25);
            player1Score.TabIndex = 5;
            player1Score.Text = "Score: ";
            // 
            // player2Score
            // 
            player2Score.AutoSize = true;
            player2Score.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            player2Score.ForeColor = Color.White;
            player2Score.Location = new Point(720, 9);
            player2Score.Name = "player2Score";
            player2Score.Size = new Size(68, 25);
            player2Score.TabIndex = 6;
            player2Score.Text = "Score: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 400);
            Controls.Add(rightPlayer);
            Controls.Add(leftPlayer);
            Controls.Add(player2Score);
            Controls.Add(player1Score);
            Controls.Add(winner);
            Controls.Add(startGame);
            Controls.Add(ball);
            MaximizeBox = false;
            MaximumSize = new Size(816, 439);
            MinimumSize = new Size(816, 439);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pong";
            Load += Form1_Load;
            KeyDown += Form_KeyDown;
            KeyUp += Form_KeyUp;
            ((System.ComponentModel.ISupportInitialize)rightPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox ball;
        private System.Windows.Forms.Timer clockTimer;
        private Button startGame;
        private PictureBox rightPlayer;
        private PictureBox leftPlayer;
        private Label winner;
        private Label player1Score;
        private Label player2Score;
    }
}
