using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        List<Ball> balls = new List<Ball>();
        List<Hole> holes = new List<Hole>();
        Ball tempBall;
        public Form1()
        {
            InitializeComponent();
            holes.Add(new Hole(100, 400, 50));
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            balls.Add(new Ball(500, 200, 30, 1, rand.NextDouble() * Math.PI * 2, true));
            /*
            balls.Add(new Ball(500, 200, 30, 0.1, 0, true));
            balls.Add(new Ball(500, 600, 30, 0.1, Math.PI, true));
       
            balls.Add(new Ball(200, 450, 30, 0.5, Math.PI / 2 + 0.01, true));
            balls.Add(new Ball(800, 450, 30, 0.5, 3 * Math.PI / 2, true)); 
            */ 
        }

        private void GlobalAction()
        {
            Bitmap map = new Bitmap(board.Width, board.Height);
            Graphics gr = Graphics.FromImage(map);
            
            foreach (Hole hole in holes)
            {
                gr.FillEllipse(Brushes.Black, hole.X - hole.R, hole.Y - hole.R, hole.R * 2, hole.R * 2);
            }

            foreach (Ball ball in balls)
            {

                gr.FillEllipse(Brushes.Green, ball.X - ball.R, ball.Y - ball.R, ball.R * 2, ball.R * 2);
                ball.Tick(board.Width, board.Height);
            }

            board.Image = map;
            foreach (Ball ball1 in balls)
            {
                foreach (Ball ball2 in balls)
                {
                    if (Math.Sqrt(Math.Pow((ball1.X - ball2.X), 2) + Math.Pow((ball1.Y - ball2.Y), 2)) <= ball1.R + ball2.R &&
                        !ball1.inRel && !ball2.inRel && ball1 != ball2)
                    // в этом случае шары вошли друг в друга и их необходимо оттолкнуть
                    {
                        if (!ball1.isMov)
                        {
                            ball1.Angle = ball2.Angle + Math.PI;
                            ball1.isMov = true;
                            ball1.Speed = ball2.Speed;
                        }
                        if (!ball2.isMov)
                        {
                            ball2.Angle = ball1.Angle + Math.PI;
                            ball2.isMov = true;
                            ball2.Speed = ball1.Speed;
                        }
                  
                        double gamma;
                        if (Math.Abs(ball2.X - ball1.X) > 0.001)
                            gamma = Math.Atan((ball2.Y - ball1.Y) / (ball2.X - ball1.X));
                        else
                            gamma = Math.PI / 2;

                        ball1.Angle = 2 * Math.PI - ball1.Angle - 2 * gamma;
                        ball2.Angle = 2 * Math.PI - ball2.Angle - 2 * gamma;
                        
                        ball1.inRel = true;
                        break;
                    }
                    else
                    {
                        ball1.inRel = false;
                    }
                }              
            }
            foreach (Hole hole in holes)
            {               
                foreach (Ball ball in balls)
                {
                    double d = hole.R + ball.R - Math.Sqrt(Math.Pow(ball.X - hole.X, 2) + Math.Pow(ball.Y - hole.Y, 2));
                    
                    if (d > ball.R / 4)
                    {
                        tempBall = ball;
                        break;
                    }
                }
                balls.Remove(tempBall);
            }
            
        }

        private void TimerTick(object sender, EventArgs e)
        {
            GlobalAction();
        }

        private void ResizeAllBalls(object sender, EventArgs e)
        {
            Random rand = new Random();
            float r = 1 + (float)rand.Next(49);
            foreach (Ball ball in balls)
            {
                ball.R = r;
            }
        }
    }
}
