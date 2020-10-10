using System;
using System.Drawing;

namespace Pool
{
    public class Ball
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float R { get; set; }
        public double Angle { get; set; }
        public bool IsMoving { get; set; }
        public bool InRelation { get; set; }
        public double Speed { get; set; }
        public SolidBrush Brush { get; set; }
        public Ball(float x, float y, float r, double speed, double ang, bool isMov)
        {
            Init(x, y, r, speed, ang, isMov, false);
        }
        private void Init(float x, float y, float r, double speed, double angle, bool isMoving, bool inRelation)
        {
            if (r < 0) r = 1;
            this.X = x;
            this.Y = y;
            this.R = r;
            this.Speed = speed;
            this.Angle = angle;
            this.IsMoving = isMoving;
            this.InRelation = inRelation;
            this.Brush = new SolidBrush(Color.White);
        }
        public void Tick(int width, int height)
        {
            if (IsMoving)
            {
                X += (float)(Math.Cos(Angle) * R / (1 / Speed));
                Y += (float)(Math.Sin(Angle) * R / (1 / Speed));
                Speed -= Speed * 0.008;

                if (X + R >= width)
                {
                    X -= R - (width - X);
                    Angle = Math.PI - Angle;
                }
                if (X - R <= 0)
                {
                    X += R - X;
                    Angle = Math.PI - Angle;
                }
                if (Y + R >= height)
                {
                    Y -= R - (height - Y);
                    Angle += (Math.PI - Angle) * 2 ;
                }
                if (Y - R <= 0)
                {
                    Y += R - Y;
                    Angle += (Math.PI - Angle) * 2;
                }
                if (Math.Abs(Speed) < 0.008)
                    IsMoving = false;
            }
        }
    }
}
