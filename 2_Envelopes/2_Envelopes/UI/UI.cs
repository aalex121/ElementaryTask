using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    static class UI
    {
        const string INPUT_REQUEST_MESSAGE = "Please enter";
        const string FIRST_ENVELOPE_NAME = "First envelope";
        const string SECOND_ENVELOPE_NAME = "Second envelope";
        const string WIDTH_PARAM_NAME = "Width";
        const string HEIGHT_PARAM_NAME = "Height";
        const string COMPARE_RESULT_POSITIVE = "Yes! Second envelope fits into First";
        const string COMPARE_RESULT_NEGATIVE = "No! Second envelope doesn't fit into First";
        const string HELP_MESSAGE = "Envelope Width and Height must be positive numbers!";        

        public static void RequestParams(Envelpoes envelopeNumber, out double width, out double height)
        {
            string envelopeName = "";

            if (envelopeNumber == Envelpoes.First)
            {
                envelopeName = FIRST_ENVELOPE_NAME;
            }

            if (envelopeNumber == Envelpoes.Second)
            {
                envelopeName = SECOND_ENVELOPE_NAME;
            }

            string requestMessage = string.Format("{0} the {1} {2}:", INPUT_REQUEST_MESSAGE,
                envelopeName, WIDTH_PARAM_NAME);

            width = GetEnvelopeParam(requestMessage);

            requestMessage = string.Format("{0} the {1} {2}:", INPUT_REQUEST_MESSAGE,
                envelopeName, HEIGHT_PARAM_NAME);

            height = GetEnvelopeParam(requestMessage);
        }

        public static bool GetAppExitPrompt()
        {
            Console.WriteLine("Exit now?");

            string userInput = Console.ReadLine();
            userInput = userInput.Trim().ToLower();

            return userInput == "yes" || userInput == "y";
        }

        public static void ShowCompareResult(int res)
        {
            if (res == 1)
            {
                Console.WriteLine(COMPARE_RESULT_POSITIVE);
            }
            else
            {
                Console.WriteLine(COMPARE_RESULT_NEGATIVE);
            }

            Console.ReadKey();
        }

        private static double GetEnvelopeParam(string message)
        {
            string paramInput;
            double paramOutput;
            bool fOk = false;

            do
            {
                Console.WriteLine(message);

                paramInput = Console.ReadLine();

                if (double.TryParse(paramInput, out paramOutput) && paramOutput > 0)
                {
                    fOk = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(HELP_MESSAGE);
                    Console.WriteLine();
                }

            } while (!fOk);

            return paramOutput;
        }
    }
}
