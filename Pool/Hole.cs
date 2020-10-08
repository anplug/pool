namespace Pool
{
    class Hole
    {
        public float X { get; }
        public float Y { get; }
        public float R { get; }

        public Hole(float x, float y, float r)
        {
            if (r < 0) r = 1;
            this.X = x;
            this.Y = y;
            this.R = r;
        }
    }
}
