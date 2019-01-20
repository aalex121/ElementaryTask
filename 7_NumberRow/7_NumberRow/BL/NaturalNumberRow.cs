using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    class NaturalNumberRow : IEnumerable<int>
    {
        const int MIN_TARGET_VALUE = 2;

        public NaturalNumberRow(int inputNumber)
        {
            if (inputNumber < MIN_TARGET_VALUE)
            {
                throw new InvalidNubmerRowParameterException(inputNumber, MIN_TARGET_VALUE);
            }

            GenerateNumberRow(inputNumber, ref _head, ref _tail);
        }

        public int TargetNumber { get; private set; }

        public RowElement Head
        {
            get
            {
                return _head;
            }
        }

        public static bool GenerateNumberRow(int targetNumber, ref RowElement head, ref RowElement tail)
        {
            bool isRowGenerated = false;

            if (targetNumber < MIN_TARGET_VALUE)
            {
                return isRowGenerated;
            }

            RowElement previous = null;

            for (int i = 1; i < targetNumber; i++)
            {
                if (i * i < targetNumber)
                {                    
                    if (head == null)
                    {
                        head = new RowElement(i);
                        previous = head;
                        continue;
                    }

                    if (previous != null)
                    {
                        previous.Next = new RowElement(i);
                        previous = previous.Next;
                    }
                }
            }

            tail = previous.Next;

            return isRowGenerated;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new NaturalNumberRowIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NaturalNumberRowIterator(this);
        }

        public class RowElement
        {
            public RowElement(int inputValue)
            {
                NumValue = inputValue;
            }

            public int NumValue { get; set; }

            public RowElement Next { get; set; }
        }

        private RowElement _head = null;

        private RowElement _tail = null;
    }
}
