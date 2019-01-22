﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    abstract class LuckyTicketsCounter
    {
        #region Constants
        public const int DEFAULT_DIGITS_COUNT = 6;
        protected const int TEN_VALUE = 10;
        protected const int MAX_ONE_DIGIT_NUMBER = 9;
        #endregion

        public LuckyTicketsCounter(int digitsCount)
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
        }

        public int TicketDigitsCount { get; private set; }

        public abstract ulong GetLuckyTicketsQuantity();

        protected static void ArgumentExceptionCheck(int digitsCount)
        {
            if (digitsCount % 2 != 0 || digitsCount <= 0)
            {
                throw new InvalidTicketDigitsCountException(digitsCount);
            }
        }

        protected ulong _luckyTicketsQuantity = 0;
    }
}
