using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    class NaturalNumberRowIterator : IEnumerator<uint>
    {
        public NaturalNumberRowIterator(NaturalNumberRow numRow)
        {
            _numberRow = numRow;
        }

        public uint Current => _current.NumValue;

        object IEnumerator.Current => _current.NumValue;

        public void Dispose()
        {
            GC.Collect();
        }

        public bool MoveNext()
        {
            if (_numberRow.Head == null)
            {
                return false;
            }

            bool isNotTail = false;

            if (_current == null)
            {
                _current = _numberRow.Head;
                isNotTail = true;
            }
            else
            {
                if (_current.Next != null)
                {
                    _current = _current.Next;
                    isNotTail = true;
                }
            }

            return isNotTail;
        }

        public void Reset()
        {
            _current = null;
        }

        private NaturalNumberRow.RowElement _current;

        private readonly NaturalNumberRow _numberRow;
    }
}
