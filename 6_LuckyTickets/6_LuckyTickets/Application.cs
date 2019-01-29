using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_LuckyTickets
{
    static class Application
    {
        #region Constants
        public const string ALGORITHM_NAME_MOSCOW = "moscow";
        public const string ALGORITHM_NAME_PITER = "piter";
        const string VALID_ALGORITHM_FILE_EXTENSION = ".txt";
        const int DEFAULT_DIGITS_NUMBER = 6;
        #endregion

        public static void Run(string[] args)
        {
            string algorithmFilePath = string.Empty;
            TicketCountAlgorithms currentAlgorhytm = TicketCountAlgorithms.None;

            if (args.Length == 0)
            {
                algorithmFilePath = UI.RequestFilePath();
            }
            else
            {
                algorithmFilePath = args[0];
            }

            AlgorithmGetter algorithmGet = new AlgorithmGetter(new AlgorithmFileReader());
            currentAlgorhytm = algorithmGet.GetAlgorhytm(algorithmFilePath);

            if (currentAlgorhytm != TicketCountAlgorithms.None)
            {
                ulong ticketCount = 0;
                LuckyTicketsCounter counter;

                try
                {
                    switch (currentAlgorhytm)
                    {
                        case TicketCountAlgorithms.Moscow:
                            counter = new LuckyTicketsCounterMoscow(DEFAULT_DIGITS_NUMBER);
                            ticketCount = counter.GetLuckyTicketsQuantity();
                            break;
                        case TicketCountAlgorithms.Piter:
                            counter = new LuckyTicketsCounterPiter(DEFAULT_DIGITS_NUMBER);
                            ticketCount = counter.GetLuckyTicketsQuantity();
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidTicketDigitsCountException ex)
                {
                    UI.PrintExceptionMessage(ex);
                }
                catch (RecursionDepthTooBigException ex)
                {
                    UI.PrintExceptionMessage(ex);
                }

                UI.PrintTicketsCount(ticketCount);
            }
            else
            {
                UI.PrintHelp(Path.GetFullPath(algorithmFilePath));
            }
        }
    }
}
