using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class LuckyTicketsCounter
    {
        #region Constants
        public const int DEFAULT_DIGITS_COUNT = 6;
        private const int TEN_VALUE = 10;
        private const int MAX_ONE_DIGIT_NUMBER = 9;
        #endregion

        public LuckyTicketsCounter(int digitsCount, TicketCountAlgorithms inputAlgorithmType)
        {
            ArgumentExceptionCheck(digitsCount);

            if (digitsCount == 0)
            {
                TicketDigitsCount = DEFAULT_DIGITS_COUNT;
            }
            else
            {
                TicketDigitsCount = digitsCount;
            }
            
            AlgorithmType = inputAlgorithmType;
        }

        public int TicketDigitsCount { get; private set; }

        public TicketCountAlgorithms AlgorithmType { get; private set; }

        public ulong GetLuckyTicketsQuantity()
        {
            if (_luckyTicketsQuantity > 0)
            {
                return _luckyTicketsQuantity;
            }

            ulong result = 0;

            if (AlgorithmType == TicketCountAlgorithms.Moscow)
            {
                result = CountLuckyTicketsMoscow(TicketDigitsCount);
            }

            if (AlgorithmType == TicketCountAlgorithms.Piter)
            {
                result = CountLuckyTicketsPiter(TicketDigitsCount);
            }

            _luckyTicketsQuantity = result;

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
                ulong temp = CountNumberCombinationsForValue(digits, i);
                temp *= temp;
                result += temp;
            }

            return result;
        }

        /// <summary>        
        /// Calculating the number of "Petersburg-type" lucky tickets can be done by transferring
        /// all the even digits to the right part of the number, while transferring all the odd
        /// digits to the left part (or vice-versa), then using the "Moscow-type" tickets calculating
        /// algorithm.
        /// So the quantity of "Petersburg-type" tickets is always equal to "Moscow-type" tickets quantity.
        /// Thus, creating the scpecific algorithm for calculating "Petersburg-type" tickets quantity
        /// is redundant.
        /// 
        ///Proof: http://kvant.mccme.ru/1975/07/razgovor_v_tramvae.htm
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        private static ulong CountLuckyTicketsPiter(int digits)        {
            
            return CountLuckyTicketsMoscow(digits);
        }

        /// <summary>        
        /// This method recursively calculates the quantity of possible number combinations,
        /// the sum of which is equal to to the examinated value for the set digits count.
        /// </summary>
        /// <param name="digits">Digits count</param>
        /// <param name="value">Examinated value</param>
        /// <returns></returns>
        private static ulong CountNumberCombinationsForValue(int digits, int value)
        {
            ulong res = 0;

            //Trivial case #1
            //If the examined value has more digits than current digits number,
            //than we have no proper number combinations. I.e. we have no valid 2-digit 
            //combinations for 3-digit value like 100.
            //So returning 0.            
            if (GetDigitsCount(value) > digits)
            {
                return 0;
            }

            //Trivial case #2
            //If digits number reaches 1, or the examined value is 0, than we have only one 
            //proper number combination. I.e. the value of 2 has only one valid number combination: 2.
            //So returning 1.
            if (value == 0 || digits == 1)
            {
                return 1;
            }
            
            for (int i = 0; i <= MAX_ONE_DIGIT_NUMBER; i++)
            {
                if (value >= i)
                {
                    res += CountNumberCombinationsForValue(digits - 1, value - i);                    
                }
                else
                {
                    break;
                }
            }                       

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

        private static void ArgumentExceptionCheck(int digitsCount)
        {
            if (digitsCount % 2 != 0 || digitsCount <= 0)
            {
                throw new InvalidTicketDigitsCountException(digitsCount);
            }
        }

        private ulong _luckyTicketsQuantity = 0;
    }
}
