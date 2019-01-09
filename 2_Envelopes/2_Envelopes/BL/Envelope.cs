using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    class Envelope : IComparable<Envelope>
    {
        public Envelope(double inputWidth, double inputHeight)
        {
            Width = inputWidth;
            Height = inputHeight;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }               

        public int CompareTo(Envelope other)
        {
            int result = 0;
            
            if (Width > other.Width && Height > other.Height)
            {
                result = 1;
            }

            if (Width < other.Width || Height < other.Height)
            {
                result = -1;
            }

            return result;
        }
    }
}
