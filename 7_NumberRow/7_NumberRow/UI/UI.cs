using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    public static class UI
    {
        #region Constants
        private const string HELP_MESSAGE = "Plese provide a number in range from 2 to 2147483647 as first parameter";
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key...";
        private const string ERROR_MESSAGE = "Error!";
        #endregion

        public static void ShowMessage(MessageTypes messageType, params string[] moreInfo)
        {
            string message = string.Empty;            

            switch (messageType)
            {
                case MessageTypes.None:
                    break;
                case MessageTypes.Help:
                    message = HELP_MESSAGE;
                    break;
                case MessageTypes.Error:
                    message = string.Format("{0}\n{1}", ERROR_MESSAGE, moreInfo[0]);
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }

        public static void DisplayNumberRow(IEnumerable<uint> numRow)
        {
            Console.WriteLine();

            foreach (int item in numRow)
            {
                Console.Write("{0}, ", item);
            }

            Console.WriteLine();
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.ReadKey();
        }
    }
}
