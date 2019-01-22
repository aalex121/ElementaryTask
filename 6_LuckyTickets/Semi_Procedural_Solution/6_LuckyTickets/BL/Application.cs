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
        public const string ALGORITHM_NAME_MOSCOW = "moscow";
        public const string ALGORITHM_NAME_PITER = "piter";
        const string VALID_ALGORITHM_FILE_EXTENSION = ".txt";
        const int DEFAULT_DIGITS_NUMBER = 6; 

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

            if (!ValidateFilePath(algorithmFilePath))
            {
                UI.PrintHelp(algorithmFilePath);
                return;
            }

            TicketCountAlgorithms currentAlgorhytm;

            if (TryGetAlgorhytm(algorithmFilePath, out currentAlgorhytm))
            {
                LuckyTicketsCounter ticketCounter = new LuckyTicketsCounter(DEFAULT_DIGITS_NUMBER, currentAlgorhytm);
                ulong ticketCount = ticketCounter.GetLuckyTicketsQuantity();

                UI.PrintTicketsCount(ticketCount);
            }
            else
            {
                UI.PrintHelp(algorithmFilePath);
            }
        }

        private static bool ValidateFilePath(string filePath)
        {
            bool isValid = false;

            if (File.Exists(filePath))
            {
                isValid = Path.GetExtension(filePath) == VALID_ALGORITHM_FILE_EXTENSION;
            }

            return isValid;
        }

        private static bool TryGetAlgorhytm(string filePath, out TicketCountAlgorithms result)
        {
            bool isAlgorhithmFound = false;
            result = TicketCountAlgorithms.None;

            using (StreamReader file = new StreamReader(filePath))
            {
                string currentLine = null;

                do
                {
                    currentLine = file.ReadLine();

                    if (currentLine != null)
                    {
                        currentLine = currentLine.Trim().ToLower();

                        if (currentLine == ALGORITHM_NAME_MOSCOW)
                        {
                            isAlgorhithmFound = true;
                            result = TicketCountAlgorithms.Moscow;
                            break;
                        }

                        if (currentLine == ALGORITHM_NAME_PITER)
                        {
                            isAlgorhithmFound = true;
                            result = TicketCountAlgorithms.Piter;
                            break;
                        }
                    }

                } while (currentLine != null);
            }

            return isAlgorhithmFound;
        }
    }
}
