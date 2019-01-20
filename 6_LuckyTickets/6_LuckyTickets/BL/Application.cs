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
        public const string ALGORYTHM_NAME_MOSCOW = "moscow";
        public const string ALGORYTHM_NAME_PITER = "piter";
        const string VALID_ALGORYTHM_FILE_EXTENSION = ".txt";
        const int DEFAULT_DIGITS_NUMBER = 6; 

        public static void Run(string[] args)
        {
            string algorytmFilePath = string.Empty;

            if (args.Length == 0)
            {
                algorytmFilePath = UI.RequestFilePath();
            }
            else
            {
                algorytmFilePath = args[0];
            }

            algorytmFilePath = Path.GetFullPath(algorytmFilePath);

            if (!ValidateFilePath(algorytmFilePath))
            {
                UI.PrintHelp(algorytmFilePath);
                return;
            }

            TicketCountAlgorhytmTypes currentAlgorhytm;

            if (TryGetAlgorhytm(algorytmFilePath, out currentAlgorhytm))
            {
                LuckyTicketsCounter ticketCounter = new LuckyTicketsCounter(DEFAULT_DIGITS_NUMBER, currentAlgorhytm);
                ulong ticketCount = ticketCounter.GetLuckyTicketsQuantity();

                UI.PrintTicketsCount(ticketCount);
            }
            else
            {
                UI.PrintHelp(algorytmFilePath);
            }
        }

        private static bool ValidateFilePath(string filePath)
        {
            bool isValid = false;

            if (File.Exists(filePath))
            {
                isValid = Path.GetExtension(filePath) == VALID_ALGORYTHM_FILE_EXTENSION;
            }

            return isValid;
        }

        private static bool TryGetAlgorhytm(string filePath, out TicketCountAlgorhytmTypes result)
        {
            bool isAlgorhytmFound = false;
            result = TicketCountAlgorhytmTypes.None;

            using (StreamReader file = new StreamReader(filePath))
            {
                string currentLine = null;

                do
                {
                    currentLine = file.ReadLine();

                    if (currentLine != null)
                    {
                        currentLine = currentLine.Trim().ToLower();

                        if (currentLine == ALGORYTHM_NAME_MOSCOW)
                        {
                            isAlgorhytmFound = true;
                            result = TicketCountAlgorhytmTypes.Moscow;
                            break;
                        }

                        if (currentLine == ALGORYTHM_NAME_PITER)
                        {
                            isAlgorhytmFound = true;
                            result = TicketCountAlgorhytmTypes.Piter;
                            break;
                        }
                    }

                } while (currentLine != null);
            }

            return isAlgorhytmFound;
        }
    }
}
