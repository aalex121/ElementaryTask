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

            if (args.Length == 0)
            {
                algorithmFilePath = UI.RequestFilePath();
            }
            else
            {
                algorithmFilePath = args[0];
            }

            algorithmFilePath = Path.GetFullPath(algorithmFilePath);

            if (!TryValidateFilePath(ref algorithmFilePath))
            {
                UI.PrintHelp(algorithmFilePath);
                return;
            }

            TicketCountAlgorithms currentAlgorhytm;

            if (TryGetAlgorhytm(algorithmFilePath, out currentAlgorhytm))
            {
                ulong ticketCount = 0;

                try
                {
                    if (currentAlgorhytm == TicketCountAlgorithms.Moscow)
                    {
                        ticketCount = new LuckyTicketsCounterMoscow(DEFAULT_DIGITS_NUMBER).GetLuckyTicketsQuantity();
                    }

                    if (currentAlgorhytm == TicketCountAlgorithms.Piter)
                    {
                        ticketCount = new LuckyTicketsCounterPiter(DEFAULT_DIGITS_NUMBER).GetLuckyTicketsQuantity();
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
                UI.PrintHelp(algorithmFilePath);
            }
        }

        private static bool TryValidateFilePath(ref string filePath)
        {
            bool isValid = false;

            if (filePath.Length > 0)
            {
                filePath = Path.GetFullPath(filePath);

                if (File.Exists(filePath))
                {
                    isValid = Path.GetExtension(filePath) == VALID_ALGORITHM_FILE_EXTENSION;
                }
            }

            return isValid;
        }

        private static bool TryGetAlgorhytm(string filePath, out TicketCountAlgorithms result)
        {
            bool isAlgorhithmFound = false;
            result = TicketCountAlgorithms.None;

            if (AlgorithmFileReader.GetAlgorithmLine(filePath) == ALGORITHM_NAME_MOSCOW)
            {
                result = TicketCountAlgorithms.Moscow;
                isAlgorhithmFound = true;
            }

            if (AlgorithmFileReader.GetAlgorithmLine(filePath) == ALGORITHM_NAME_PITER)
            {
                result = TicketCountAlgorithms.Piter;
                isAlgorhithmFound = true;
            }

            return isAlgorhithmFound;
        }
    }
}
