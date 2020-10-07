namespace Pool
{
    class Hole
    {
        private float x;
        private float y;
        private float r;

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

        public Hole(float X, float Y, float R)
        {
            Init(X, Y, R);
        }
        private void Init(float X, float Y, float R)
        {
            if (R < 0) R = 1;
            x = X;
            y = Y;
            r = R;
        }
    }
}
