using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    static class UI
    {
        #region Constants
        private const string NAME_INPUT_PROMPT = "Please enter Triangle Name";
        private const string LENGTH_INPUT_PROMPT = "Please enter the length of";
        private const string HELP_MESSAGE = "Side Length must be positive number!";
        private const string EXIT_PROMPT = "Exit now? (y/n)";
        private const string TRIANGLE_INPUT_PROMPT = "Add one more triangle? (y/n)";
        private const string YES_PROMPT_FULL = "yes";
        private const string YES_PROMPT_SHORT = "y";
        private const string TRIANGLE_LIST_HEADER = "=============== Triangle List ===============";
        private const string PRESS_ANY_KEY_MESSAGE = "Press any key to continue...";
        private const string EMPTY_LIST_MESSAGE = "No triangles found!";
        #endregion

        public static void ReqestTriangleParams(out string name, out double side1, out double side2,
            out double side3) 
        {
            Console.WriteLine(NAME_INPUT_PROMPT);

            name = Console.ReadLine();

            side1 = GetSideLength(TriangleSides.Side1);
            side2 = GetSideLength(TriangleSides.Side2);
            side3 = GetSideLength(TriangleSides.Side3);
        }

        public static bool GetUserConfirmation(PromptTypes pType)
        {
            string message = "";

            switch (pType)
            {                
                case PromptTypes.AddTriangle:
                    message = TRIANGLE_INPUT_PROMPT;
                    break;
                case PromptTypes.ExitApp:
                    message = EXIT_PROMPT;
                    break;
                default:
                    break;
            }

            Console.WriteLine(message);

            string userInput = Console.ReadLine();
            userInput = userInput.Trim().ToLower();

            return userInput == YES_PROMPT_FULL || userInput == YES_PROMPT_SHORT;
        }

        public static void ShowSortedTriangles(List<Triangle> triangleList)
        {
            Console.Clear();

            Console.WriteLine(TRIANGLE_LIST_HEADER);
            Console.WriteLine();

            if (triangleList.Count == 0)
            {
                Console.WriteLine(EMPTY_LIST_MESSAGE);
                Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            }
            else
            {
                foreach (Triangle item in triangleList)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }

        public static void PrintWarning(string warning)
        {
            Console.WriteLine();
            Console.WriteLine(warning);
            Console.WriteLine(PRESS_ANY_KEY_MESSAGE);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static double GetSideLength(TriangleSides side)
        {
            string message = string.Format("{0} {1}: ", LENGTH_INPUT_PROMPT, side);
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
