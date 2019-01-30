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

        public LinkedList<int> GenerateFibonacciRow(int start, int end)
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

            LinkedList<int> output = new LinkedList<int>();
            
            if (RowStartValue < 0)
            {   
                foreach (int number in GenerateFibonacciRowNegative(RowStartValue, RowEndValue))
                {
                    output.AddFirst(number);
                }
            }

            if (RowEndValue >= 0)
            {
                foreach (int number in GenerateFibonacciRowPositive(RowStartValue, RowEndValue))
                {
                    output.AddLast(number);
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
            int number1 = 0;
            int number2 = 1;
            int numberSum = 0;

            while (numberSum <= end)
            {
                numberSum = number1 + number2;

                if (number1 == 0 && start <= 0)
                {
                    yield return 0;
                }

                number1 = number2;
                number2 = numberSum;

                if (numberSum >= start && numberSum <= end)
                {
                    if (number2 == 1)
                    {
                        yield return 1;
                    }

                    yield return numberSum;
                }
            }            
        }

        private static IEnumerable<int> GenerateFibonacciRowNegative(int start, int end)
        {
            int number1 = 0;
            int number2 = -1;
            int numberSum = 0;

            while (numberSum >= start)
            {
                numberSum = number1 + number2;
                number1 = number2;
                number2 = numberSum;

                if (numberSum >= start && numberSum <= end)
                {
                    if (number2 == -1)
                    {
                        yield return -1;
                    }

                    yield return numberSum;
                }
            }
        }

        private IEnumerable<int> _fibonacciRow = null;
    }
}
