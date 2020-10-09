using System;
using System.Collections.Generic;
using System.Drawing;

namespace Pool
{
    public class Table
    {
        private readonly System.Windows.Forms.PictureBox board;
        private readonly System.Windows.Forms.Label amountOfBallsLabel;

        private int amountOfBalls;
        private Size size;
        private readonly List<Ball> balls = new List<Ball>();
        private readonly List<Hole> holes = new List<Hole>();

        public Table(System.Windows.Forms.PictureBox board, System.Windows.Forms.Label amountOfBallsLabel)
        {
            this.board = board;
            this.amountOfBallsLabel = amountOfBallsLabel;
            SetSize(board.Size);
        }
        public void SetSize(Size size) // Can be used to rerender holes on resize
        {
            this.size = size;
            SpawnHoles();
        }
        public void SpawnBall()
        {
            Random rand = new Random();

            balls.Add(new Ball(500, 200, 18, 1, rand.NextDouble() * Math.PI * 2, true));
            this.amountOfBallsLabel.Text = (++this.amountOfBalls).ToString();
        }
        public void ResizeAllBalls()
        {
            Random rand = new Random();
            float r = 1 + (float)rand.Next(49);
            foreach (Ball ball in balls)
            {
                ball.R = r;
            }
        }
        private void SpawnHoles()
        {
            holes.Add(new Hole(0, 0, 20));
            holes.Add(new Hole(0, size.Height, 20));
            holes.Add(new Hole(size.Width, 0, 20));
            holes.Add(new Hole(size.Width, size.Height, 20));
            holes.Add(new Hole(size.Width / 2, 0, 20));
            holes.Add(new Hole(size.Width / 2, size.Height, 20));
        }
        private void DrawBoard()
        {
            Bitmap frame = new Bitmap(size.Width, size.Height);
            Graphics gr = Graphics.FromImage(frame);

            foreach (Hole hole in holes)
            {
                gr.FillEllipse(Brushes.Black, hole.X - hole.R, hole.Y - hole.R, hole.R * 2, hole.R * 2);
            }

            foreach (Ball ball in balls)
            {
                gr.FillEllipse(ball.Brush, ball.X - ball.R, ball.Y - ball.R, ball.R * 2, ball.R * 2);
                ball.Tick(size.Width, size.Height);
            }

            this.board.Image = frame;
        }
        public void UpdateTick()
        {
            DrawBoard();
            ProcessBallCollisions();
            ProcessHoleCollisions();
        }
        private void ProcessBallCollisions()
        {
            foreach (Ball ball1 in balls)
            {
                foreach (Ball ball2 in balls)
                {
                    if (Collide(ball1, ball2))
                    {
                        if (!ball1.IsMoving)
                        {
                            ball1.Angle = ball2.Angle + Math.PI;
                            ball1.IsMoving = true;
                            ball1.Speed = ball2.Speed;
                        }
                        if (!ball2.IsMoving)
                        {
                            ball2.Angle = ball1.Angle + Math.PI;
                            ball2.IsMoving = true;
                            ball2.Speed = ball1.Speed;
                        }

                        double gamma;
                        if (Math.Abs(ball2.X - ball1.X) > 0.001)
                            gamma = Math.Atan((ball2.Y - ball1.Y) / (ball2.X - ball1.X));
                        else
                            gamma = Math.PI / 2;

                        ball1.Angle = 2 * Math.PI - ball1.Angle - 2 * gamma;
                        ball2.Angle = 2 * Math.PI - ball2.Angle - 2 * gamma;

                        ball1.InRelation = true;
                        break;
                    }
                    else
                    {
                        ball1.InRelation = false;
                    }
                }
            }
        }
        private void ProcessHoleCollisions()
        {
            foreach (Hole hole in holes)
            {
                foreach (Ball ball in balls)
                {
                    double d = hole.R + ball.R - Math.Sqrt(Math.Pow(ball.X - hole.X, 2) + Math.Pow(ball.Y - hole.Y, 2));

                    if (d > ball.R / 4)
                    {
                        balls.Remove(ball);
                        this.amountOfBallsLabel.Text = (--this.amountOfBalls).ToString();
                        break;
                    }
                }
            }
        }
        private bool Collide(Ball ball1, Ball ball2)
        {
            return ball1 != ball2 &&
                !ball1.InRelation &&
                !ball2.InRelation &&
                Math.Sqrt(Math.Pow(ball1.X - ball2.X, 2) + Math.Pow((ball1.Y - ball2.Y), 2)) <= ball1.R + ball2.R;
        }
    }
}
