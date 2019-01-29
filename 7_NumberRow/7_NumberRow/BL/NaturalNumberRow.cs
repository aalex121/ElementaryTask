using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    public class NaturalNumberRow : IEnumerable<uint>
    {
        #region Constants
        public const int MIN_TARGET_VALUE = 1;
        #endregion

        public NaturalNumberRow()
            :this(0)
        {
        }

        public NaturalNumberRow(uint inputNumber)
        {
            TargetNumber = inputNumber;
            GenerateNumberRow(inputNumber);
        }

        public uint TargetNumber { get; private set; }

        public RowElement Head { get; private set; }
        
        public void SetNewTargetNumber(uint targetNumber)
        {
            TargetNumber = targetNumber;
            Head = null;

            GenerateNumberRow(targetNumber);
        }

        public int GetRowLength()
        {
            if (Head == null)
            {
                return 0;
            }

            int elementCounter = 0;

            IEnumerator<uint> iterator = GetEnumerator();

            while (iterator.MoveNext())
            {
                elementCounter++;
            }

            return elementCounter;
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

        private void GenerateNumberRow(uint targetNumber)
        {
            if (targetNumber < MIN_TARGET_VALUE)
            {
                Head = new RowElement(0);
                return;
            }

            RowElement previous = null;

            for (uint i = 0; i < targetNumber; i++)
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
        }
    }
}
