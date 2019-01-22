using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    class NaturalNumberRow : IEnumerable<uint>
    {
        #region Constants
        private const int MIN_TARGET_VALUE = 2;
        #endregion

        public NaturalNumberRow(uint inputNumber)
        {
            if (inputNumber < MIN_TARGET_VALUE)
            {
                throw new InvalidNubmerRowParameterException(inputNumber, MIN_TARGET_VALUE);
            }

            TargetNumber = inputNumber;
            GenerateNumberRow(inputNumber);
        }

        public uint TargetNumber { get; private set; }

        public RowElement Head { get; private set; }        

        public bool GenerateNumberRow(uint targetNumber)
        {
            bool isRowGenerated = false;

            if (targetNumber < MIN_TARGET_VALUE)
            {
                return isRowGenerated;
            }

            RowElement previous = null;

            for (uint i = 1; i < targetNumber; i++)
            {
                if ((ulong)i * i >= targetNumber)
                {
                    break;
                }

                if (Head == null)
                {
                    Head = new RowElement(i);
                    previous = Head;
                    continue;
                }

                if (previous != null)
                {
                    previous.Next = new RowElement(i);
                    previous = previous.Next;
                }
            }

            return isRowGenerated;
        }

        public IEnumerator<uint> GetEnumerator()
        {
            return new NaturalNumberRowIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NaturalNumberRowIterator(this);
        }

        public class RowElement
        {
            public RowElement(uint inputValue)
            {
                NumValue = (uint)inputValue;
            }

            public uint NumValue { get; set; }

            public RowElement Next { get; set; }
        }
    }
}
