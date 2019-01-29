using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    public static class Application
    {
        public static void Run(string[] args)
        {
            if (args.Length == 0)
            {
                UI.ShowMessage(MessageTypes.Help);
                return;
            }

            string stringInput = args[0];
            uint numinput;

            if (uint.TryParse(stringInput, out numinput)
                    && numinput >= NaturalNumberRow.MIN_TARGET_VALUE)
            {
                NaturalNumberRow numRow = new NaturalNumberRow(numinput);
                UI.DisplayNumberRow(numRow);                              
            }
            else
            {
                UI.ShowMessage(MessageTypes.Help);
            }
        }        
    }
}
