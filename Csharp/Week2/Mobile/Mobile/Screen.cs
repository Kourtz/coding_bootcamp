using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{

    public struct Resolution
    {
        public int Height { get; private set;}
        public int Width { get; private set;}

        public Resolution(int h, int w)
        {
            Height = h;
            Width = w;
        }
    }
    
    class Screen
    {
        public Resolution resolution { get; private set; }
        public int Pixel_d { get; private set; }

        public Screen(Resolution r, int pixel_d)
        {
            resolution = r;
            Pixel_d = pixel_d;
        }

    }
}
