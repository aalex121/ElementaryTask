using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class LuckyTicketsCounterPiter : LuckyTicketsCounter
    {
        public LuckyTicketsCounterPiter(int digitsCount)
            : base(digitsCount)
        {
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
        public override ulong GetLuckyTicketsQuantity()
        {
            LuckyTicketsCounterMoscow ticketCounter = new LuckyTicketsCounterMoscow(TicketDigitsCount);
            return ticketCounter.GetLuckyTicketsQuantity();
        }
    }
}
