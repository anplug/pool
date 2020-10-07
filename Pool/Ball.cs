using System;

namespace Pool
{
    public class Ball
    {
        private float x;
        private float y;
        private float r;
        private double speed;
        private double angle;
        private bool isMoving;
        private bool inRelation;

        public Ball(float X, float Y, float R, double Speed, double Ang, bool isMov)
        {
            Init(X, Y, R, Speed, Ang, isMov, false);
        }
        public Ball()
        {
            Init(0, 0, 0, 0, 0, false, false);
        }
        private void Init(float X, float Y, float R, double Speed, double Ang, bool isMov, bool inRel)
        {
            if (R < 0) R = 1;
            x = X;
            y = Y;
            r = R;
            speed = Speed;
            angle = Ang;
            isMoving = isMov;
            inRelation = inRel;
        }

        public void Tick(int width, int height)
        {
            if (isMoving)
            {
                x += (float)(Math.Sin(angle) * r / (1 / speed));
                y += (float)(Math.Cos(angle) * r / (1 / speed));
                speed -= speed*0.01;

                if (x + r >= width)
                {
                    x -= r - (width - x);
                    angle = -angle;
                }
                if (x - r <= 0)
                {
                    x += r - x;
                    angle = -angle;
                }
                if (y + r >= height)
                {
                    y -= r - (height - y);
                    angle = Math.PI - angle;
                }
                if (y - r <= 0)
                {
                    y += r - y;
                    angle = Math.PI - angle;
                }
                if (Math.Abs(speed) < 0.01)
                    isMoving = false;
            }
        }
        public float X
        {
            get { return x; }
        }
        public float Y
        {
            get { return y; }
        }
        public float R
        {
            get { return r; }
            set { r = value; }
        }
        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }
        public bool isMov
        {
            get { return isMoving; }
            set { isMoving = value; }
        }
        public bool inRel
        {
            get { return inRelation; }
            set { inRelation = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
