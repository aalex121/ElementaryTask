using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    class FibonacciRow : IEnumerable<int>
    {
        public FibonacciRow(int start, int end)
        {
            if (start < end)
            {
                RowStartValue = start;
                RowEndValue = end;
            }
            else
            {
                RowStartValue = end;
                RowEndValue = start;
            }
            
            _fibonacciRow = GenerateFibonacciRow(RowStartValue, RowEndValue);
        }

        public int RowStartValue { get; private set; }

        public int RowEndValue { get; private set; }

        public static List<int> GenerateFibonacciRow(int start, int end)
        {
            List<int> output = new List<int>();

            if (start < 0)
            {
                GenerateFibonacciRowNegative(output, start, end);
            }

            if (end > 0)
            {
                GenerateFibonacciRowPositive(output, start, end);
            }

            return output;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _fibonacciRow.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _fibonacciRow.GetEnumerator();
        }

        private static void GenerateFibonacciRowPositive(List<int> row, int start, int end)
        {
            int fib1 = 0;
            int fib2 = 1;

            while (fib2 < end)
            {
                int temp = fib2;
                fib2 += fib1;
                fib1 = temp;

                if (fib2 >= start && fib2 <= end)
                {
                    row.Add(fib2);
                }
            }
        }

        private static void GenerateFibonacciRowNegative(List<int> row, int start, int end)
        {
            int fib1 = 0;
            int fib2 = -1;

            while (fib2 > start)
            {
                int temp = fib2;
                fib2 += fib1;
                fib1 = temp;

                if (fib2 >= start && fib2 <= end)
                {
                    row.Add(fib2);
                }
            }

            row.Sort();
        }

        private List<int> _fibonacciRow = new List<int>();
    }
}
