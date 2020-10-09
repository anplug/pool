using System;
using System.Drawing;

namespace Pool
{
    class Utils
    {
        static public Color GenerateColor()
        {
            Random rand = new Random();
            byte[] rgb = new byte[3];
            rand.NextBytes(rgb);
            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }
    }
}
