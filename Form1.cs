using System.Reflection.Metadata;

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
            setVisibility(false, true);
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
                globalVariables.player1Score += 1;
                player1Score.Text = $"Score: {globalVariables.player1Score}";
                ResetBallPosition();
                globalVariables.ballSpeed = 1;
                globalVariables.verticalMovement = 0;
            }
            else if (ball.Left <= 0)
            {
                globalVariables.player2Score += 1;
                player2Score.Text = $"Score: {globalVariables.player2Score}";
                ResetBallPosition();
                globalVariables.ballSpeed = -1;
                globalVariables.verticalMovement = 0;
            }

            ball.Left += globalVariables.ballSpeed;
            ball.Top += globalVariables.verticalMovement;
            leftPlayer.Top += globalVariables.player1Movement;
            rightPlayer.Top += globalVariables.player2Movement;

            if(ball.Top <=0 || ball.Bottom > ClientSize.Height)
            {
                globalVariables.verticalMovement = globalVariables.verticalMovement * -1;
            }
            if (leftPlayer.Top <= 0)
            {
                leftPlayer.Top = 0;
            }
            else if (leftPlayer.Bottom > ClientSize.Height)
            {
                leftPlayer.Top = ClientSize.Height - leftPlayer.Height;
            }

            if (rightPlayer.Top <= 0)
            {
                rightPlayer.Top = 0;
            }
            else if (rightPlayer.Bottom > ClientSize.Height)
            {
                rightPlayer.Top = ClientSize.Height - rightPlayer.Height;
            }

            //ball detection system
            if (ball.Left >= leftPlayer.Left && ball.Left <= leftPlayer.Right && ball.Bottom >= leftPlayer.Top && ball.Top <= leftPlayer.Bottom && ball.Bottom >= leftPlayer.Top)
            {
                int aboveSpace = ball.Top - leftPlayer.Top;
                int belowSpace = ball.Bottom - leftPlayer.Top;
                globalVariables.ballSpeed = 1;
                globalVariables.verticalMovement = (calculateHitPosition(aboveSpace, belowSpace)) / 10;
            }
            else if (ball.Right <= rightPlayer.Right && ball.Right >= rightPlayer.Left && ball.Bottom >= rightPlayer.Top && ball.Top <= rightPlayer.Bottom && ball.Bottom >= rightPlayer.Top)
            {
                int aboveSpace = ball.Top - rightPlayer.Top;
                int belowSpace = ball.Bottom - rightPlayer.Top;
                globalVariables.ballSpeed = -1;
                globalVariables.verticalMovement = (calculateHitPosition(aboveSpace, belowSpace)) / 10;
            }

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
                setVisibility(true, false);
                if (amountOfGames.Value != 0)
                {
                    globalVariables.gameTime = (int)amountOfGames.Value;
                }
                leftPlayer.Top = (ClientSize.Height) / 2;
                rightPlayer.Top = (ClientSize.Height) / 2;
                globalVariables.player1Score = 0;
                globalVariables.player2Score = 0;
                player1Score.Text = $"Score: {globalVariables.player1Score}";
                player2Score.Text = $"Score: {globalVariables.player2Score}";
                globalVariables.verticalMovement = 0;
                winner.Text = "";
        }
        private void ResetBallPosition()
        {
            ball.Left = (ClientSize.Width - ball.Width) / 2;
            ball.Top = (ClientSize.Height - ball.Height) / 2;
        }

        private void EndGame()
        {
            setVisibility(false, true);
            startGame.Text = "Restart game?";
        }
        private int calculateHitPosition(int aboveSpace, int belowSpace)
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
        private void setVisibility(bool visible1, bool visible2)
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
    }
}
