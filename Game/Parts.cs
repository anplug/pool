using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Ball
    {
        private int x;
        private int y;
        private int weight;
        private int r;
        private int speed;
        private int angle;
        public int X { 
            get
            {return x;}
            set
            {
                if (value < 0) value = 0;
                x = value;
            }
        }
        public int Y
        {
            get
            { return y; }
            set
            {
                if (value < 0) value = 0;
                y = value;
            }
        }
        public int Weight
        {
            get
            { return weight; }
            set
            {
                if (value < 1) value = 1;
                weight = value;
            }
        }
        public int R
        {
            get
            { return r; }
            set
            {
                if (value < 1) value = 1;
                r = value;
            }
        }
        public int Speed
        {
            get
            { return speed; }
            set
            {
                if (value < 0) value = 0;
                speed = value;
            }
        }
        public int Angle
        {
            get
            { return angle; }
            set
            {
                if (value < 0 || value > 360) value = 0;
                speed = value;
            }
        }

        public Ball()
        {
            x = 300;
            y = 300;
            r = 10;
            weight = 1;
            speed = 0;
            angle = 90;
        }
    }
}
