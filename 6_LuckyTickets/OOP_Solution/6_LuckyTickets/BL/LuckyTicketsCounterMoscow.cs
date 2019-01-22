using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class LuckyTicketsCounterMoscow : LuckyTicketsCounter
    {
        #region Constants
        private const int MAX_RECURSION_DEPTH = 7100;
        #endregion

        public LuckyTicketsCounterMoscow(int digitsCount) 
            : base(digitsCount)
        {
        }

        public override ulong GetLuckyTicketsQuantity()
        {
            ulong result = 0;

            if (_luckyTicketsQuantity > 0)
            {
                result = _luckyTicketsQuantity;
            }
            else
            {
                result = CountLuckyTicketsMoscow(TicketDigitsCount);
            }

            return result;
        }

        /// <summary>
        /// This algorithm calculates the number of lucky tickets
        /// for the given digits count
        /// </summary>
        /// <param name="digits">Digits count</param>
        /// <returns></returns>
        private static ulong CountLuckyTicketsMoscow(int digits)
        {
            int maxValue = digits * MAX_ONE_DIGIT_NUMBER;
            ulong result = 0;
            digits >>= 1;

            for (int i = 0; i <= maxValue; i++)
            {
                int recursionDepth = 0;
                ulong temp = CountNumberCombinationsForValue(digits, i, ref recursionDepth);
                temp *= temp;
                result += temp;
            }

            return result;
        }

        /// <summary>        
        /// This method recursively calculates the quantity of possible number combinations,
        /// the sum of which is equal to to the examinated value for the set digits count.
        /// </summary>
        /// <param name="digits">Digits count</param>
        /// <param name="value">Examinated value</param>
        /// <returns></returns>
        private static ulong CountNumberCombinationsForValue(int digits, int value, ref int recursionDepth)
        {
            recursionDepth++;            

            if (recursionDepth >= MAX_RECURSION_DEPTH)
            {
                throw new RecursionDepthTooBigException();
            }

            ulong res = 0;

            //Trivial case #1
            //If the examined value has more digits than current digits number,
            //than we have no proper number combinations. I.e. we have no valid 2-digit 
            //combinations for 3-digit value like 100.
            //So returning 0.            
            if (GetDigitsCount(value) > digits)
            {
                recursionDepth--;
                return 0;
            }

            //Trivial case #2
            //If digits number reaches 1, or the examined value is 0, than we have only one 
            //proper number combination. I.e. the value of 2 has only one valid number combination: 2.
            //So returning 1.
            if (value == 0 || digits == 1)
            {
                recursionDepth--;
                return 1;
            }

            for (int i = 0; i <= MAX_ONE_DIGIT_NUMBER; i++)
            {
                if (value >= i)
                {
                    res += CountNumberCombinationsForValue(digits - 1, value - i, ref recursionDepth);
                }
                else
                {
                    break;
                }
            }

            recursionDepth--;
            return res;
        }

        private static int GetDigitsCount(int value)
        {
            int digitsCounter = 0;

            while (value > 0)
            {
                digitsCounter++;
                value /= TEN_VALUE;
            }

            return digitsCounter;
        }
    }
}
