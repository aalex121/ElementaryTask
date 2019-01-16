using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    static class Application
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                UI.ShowMessage(MessageTypes.Help);
                return;
            }

            string stringInput = args[0];
            int numinput;

            if (int.TryParse(stringInput, out numinput))
            {
                try
                {
                    NaturalNumberRow numRow = new NaturalNumberRow(numinput);
                    UI.DisplayNumberRow(numRow);
                }
                catch (InvalidNubmerRowParameterException ex)
                {
                    UI.ShowMessage(MessageTypes.Error, ex.ToString());
                }               
            }
            else
            {
                UI.ShowMessage(MessageTypes.Help);
            }
        }        
    }
}
