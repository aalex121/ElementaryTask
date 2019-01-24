using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Fibonacci
{
    public class FibonacciRow : IEnumerable<int>
    {
        public FibonacciRow() 
            : this(0, 0)
        {
        }

        public FibonacciRow(int start, int end)
        {
            _fibonacciRow = GenerateFibonacciRow(start, end);
        }        

        public int RowStartValue { get; private set; }

        public int RowEndValue { get; private set; }

        public SortedSet<int> GenerateFibonacciRow(int start, int end)
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

            SortedSet<int> output = new SortedSet<int>();
            
            if (RowStartValue < 0)
            {   
                foreach (int number in GenerateFibonacciRowNegative(RowStartValue, RowEndValue))
                {
                    output.Add(number);
                }
            }

            if (RowEndValue > 0)
            {
                foreach (int number in GenerateFibonacciRowPositive(RowStartValue, RowEndValue))
                {
                    output.Add(number);
                }
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

        private static IEnumerable<int> GenerateFibonacciRowPositive(int start, int end)
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
                    yield return fib2;
                }
            }
        }

        private static IEnumerable<int> GenerateFibonacciRowNegative(int start, int end)
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
                    yield return fib2;
                }
            }
        }

        private IEnumerable<int> _fibonacciRow = null;
    }
}
