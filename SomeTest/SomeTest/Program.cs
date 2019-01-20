using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int pos = 2;

            for (int i = 0; i < pos - 1; ++i)
            {
                Console.WriteLine(i); ;
            }

            Console.ReadKey();
        }
    }
}
