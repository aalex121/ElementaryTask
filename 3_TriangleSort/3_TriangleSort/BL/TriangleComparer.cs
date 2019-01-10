using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    class TriangleComparer : IComparer<Triangle>
    {

        public int Compare(Triangle x, Triangle y)
        {
            return y.CompareTo(x);
        }
    }
}
