namespace Pong
{
    public partial class Form1 : Form
    {
        public static class globalVariables
        {
            public static int ballSpeed = 1;
            public static int playerSpeed = 2;
            public static int player1Movement = 0, player2Movement = 0;
            public static int player1Score = 0, player2Score = 0;
            public static int verticalMovement = 0;
            public static int gameTime = 3;
        }

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetVisibility(false, true);
        }

        public void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && leftPlayer.Top > 0)
            {
                globalVariables.player1Movement = -globalVariables.playerSpeed;
            }
            else if (e.KeyCode == Keys.S && leftPlayer.Bottom < ClientSize.Height)
            {
                globalVariables.player1Movement = globalVariables.playerSpeed;
            }

            if (e.KeyCode == Keys.Up && rightPlayer.Top > 0)
            {
                globalVariables.player2Movement = -globalVariables.playerSpeed;
            }
            else if (e.KeyCode == Keys.Down && rightPlayer.Bottom <ClientSize.Height)
            {
                globalVariables.player2Movement = globalVariables.playerSpeed;
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                globalVariables.player1Movement = 0;
            } else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                globalVariables.player2Movement = 0;
            }
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            //scoring detection
            if (ball.Right >= ClientSize.Width)
            {
                UpdateScore(player1Score, 1, ref globalVariables.player1Score);
            }
            else if (ball.Left <= 0)
            {
                UpdateScore(player2Score, -1, ref globalVariables.player2Score);
            }

            ball.Left += globalVariables.ballSpeed;
            ball.Top += globalVariables.verticalMovement;
            leftPlayer.Top += globalVariables.player1Movement;
            rightPlayer.Top += globalVariables.player2Movement;

            if(ball.Top <=0 || ball.Bottom > ClientSize.Height)
            {
                globalVariables.verticalMovement = globalVariables.verticalMovement * -1;
            }

            //ball detection system
            PlayerBoundDetector(leftPlayer);
            PlayerBoundDetector(rightPlayer);

            PlayerHitDetection(ball.Left >= leftPlayer.Left, ball.Left <= leftPlayer.Right, ball.Bottom >= leftPlayer.Top, ball.Top <= leftPlayer.Bottom, ball.Bottom >= leftPlayer.Top, leftPlayer, 1);
            PlayerHitDetection(ball.Right <= rightPlayer.Right, ball.Right >= rightPlayer.Left, ball.Bottom >= rightPlayer.Top, ball.Top <= rightPlayer.Bottom, ball.Bottom >= rightPlayer.Top, rightPlayer, -1);

            //winning detection
            if (globalVariables.player1Score == globalVariables.gameTime)
            {
                winner.Text = "PLAYER 1 WINS";
                EndGame();
            }
            else if (globalVariables.player2Score == globalVariables.gameTime)
            {
                winner.Text = "PLAYER 2 WINS";
                EndGame();
            }
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
                SetVisibility(true, false);
                if (amountOfGames.Value != 0)
                {
                    globalVariables.gameTime = (int)amountOfGames.Value;
                }
                leftPlayer.Top = (ClientSize.Height) / 2;
                rightPlayer.Top = (ClientSize.Height) / 2;
                UpdateScore(player1Score, ref globalVariables.player1Score, 0);
                UpdateScore(player2Score, ref globalVariables.player2Score, 0);
                globalVariables.verticalMovement = 0;
                winner.Text = "";
        }
        private void ResetBallPosition()
        {
            ball.Left = (ClientSize.Width - ball.Width) / 2;
            ball.Top = (ClientSize.Height - ball.Height) / 2;
        }

        private static void UpdateScore(Label player, ref int currentScore, int newScore)
        {
            currentScore = newScore;
            player.Text = $"Score: {currentScore}";
        }
        private void EndGame()
        {
            SetVisibility(false, true);
            startGame.Text = "Restart game?";
            globalVariables.gameTime = 3;
            amountOfGames.Value = 0;
        }
        private void SetVisibility(bool visible1, bool visible2)
        {
            clockTimer.Enabled = visible1;
            rightPlayer.Visible = visible1;
            leftPlayer.Visible = visible1;
            ball.Visible = visible1;
            player1Score.Visible = visible1;
            player2Score.Visible = visible1;
            gameLabel.Visible = visible2;
            startGame.Enabled = visible2;
            startGame.Visible = visible2;
            amountOfGames.Visible = visible2;
            amountOfGames.Enabled = visible2;
        }
        private void PlayerBoundDetector(PictureBox player)
        {
            if (player.Top <= 0)
            {
                player.Top = 0;
            }
            else if (player.Bottom > ClientSize.Height)
            {
                player.Top = ClientSize.Height - player.Height;
            }
        }
        private void PlayerHitDetection(bool comparision1, bool comparision2, bool comparision3, bool comparision4, bool comparision5, PictureBox player, int direction)
        {
            if (comparision1 && comparision2 && comparision3 && comparision4 && comparision5)
            {
                int aboveSpace = ball.Top - player.Top;
                int belowSpace = ball.Bottom - player.Top;
                globalVariables.ballSpeed = direction;
                globalVariables.verticalMovement = CalculateHitPosition(aboveSpace, belowSpace) / 10;
            }
        }
        private static int CalculateHitPosition(int aboveSpace, int belowSpace)
        {
            if (aboveSpace > belowSpace)
            {
                return aboveSpace;
            }
            else
            {
                return belowSpace;
            }
        }
        private void UpdateScore(Label scoreLabel, int dir, ref int score)
        {
            score += 1;
            UpdateScore(scoreLabel, ref score, score);
            ResetBallPosition();
            globalVariables.ballSpeed = dir;
            globalVariables.verticalMovement = 0;
        }
    }
}
