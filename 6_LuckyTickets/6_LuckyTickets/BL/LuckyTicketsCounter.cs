using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class LuckyTicketsCounter
    {
        public const string ALGORYTHM_NAME_MOSCOW = "moscow";
        public const string ALGORYTHM_NAME_PITER = "piter";
        const int TEN_VALUE = 10;
        const int MAX_ONE_DIGIT_NUMBER = 9;

        public LuckyTicketsCounter(int digitsCount)
        {
            if (digitsCount % 2 != 0 || digitsCount <= 0)
            {
                throw new InvalidTicketDigitsCountException(digitsCount);
            }

            TicketDigitsCount = digitsCount;
        }

        public int TicketDigitsCount { get; private set; }        
        
        public ulong GetLuckyTicketsQuantity(string algorythmName)
        {
            ulong result = 0;

            if (algorythmName.Length == 0)
            {
                throw new Exception();
            }

            algorythmName = algorythmName.Trim().ToLower();

            if (algorythmName != ALGORYTHM_NAME_MOSCOW && algorythmName != ALGORYTHM_NAME_PITER)
            {
                throw new Exception();
            }

            if (algorythmName == ALGORYTHM_NAME_MOSCOW)
            {
                result = CountLuckyTicketsMoscow(TicketDigitsCount);
            }

            if (algorythmName == ALGORYTHM_NAME_PITER)
            {
                result = CountLuckyTicketsPiter(TicketDigitsCount);
            }

            return result;
        }

        /// <summary>
        /// Данный алгоритм рассчитвает количество комбинаций
        /// "счастливых" билетов для любого чётного колисечтва разрядов
        /// </summary>
        /// <param name="digits">Количество разрядов</param>
        /// <returns></returns>
        public static ulong CountLuckyTicketsMoscow(int digits)
        {
            if (digits % 2 != 0 || digits <= 0)
            {
                throw new InvalidTicketDigitsCountException(digits);
            }

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
        ///Для подсчета количества "счастливых билетов по-питерски" можно перенести все четные
        ///разряды в левую половину номера билета, а нечетные - в правую (или наборот),
        ///после чего использовать "московский" алгоритм подсчета.
        ///Таким образом, количество "счастливых билетов по-питерски" и "счастливых билетов по-московски" равны 
        ///при одинаковом количестве разрядов.
        ///Следовательно, написание отдельного алгоритма подсчета "по-питерски" не имеет смысла.
        ///Подтверждение: http://kvant.mccme.ru/1975/07/razgovor_v_tramvae.htm
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static ulong CountLuckyTicketsPiter(int digits)        {
            
            return CountLuckyTicketsMoscow(digits);
        }

        /// <summary>
        /// Данный метод рекурсивно рассчитывает количество возможных комбинаций цифр,
        /// сумма которых равна анализируемому значению при заданном количестве разрядов
        /// </summary>
        /// <param name="digits">Количество разрядов</param>
        /// <param name="value">Анализируемое значение</param>
        /// <returns></returns>
        private static ulong CountNumberCombinationsForValue(int digits, int value)
        {
            ulong res = 0;

            //Тривиальный случай №1 - если разрядность исследуемого числа больше,
            //чем заданная разрядность - подходящих комбинаций нет
            if (GetDigitsCount(value) > digits)
            {
                return 0;
            }

            //Тривиальный случай №2 - если исследуемое число = 0, или мы дошли
            //до одноразрядных значений - число возможных комбинаций всегда = 1
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
    }
}
