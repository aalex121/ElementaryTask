using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToString
{
    static class Application
    {
        public static void Run(string[] args)
        {
            int inputNumber;

            if (ConfirmInputValidation(args, out inputNumber))
            {
                NumberToStringTranslator translator = new NumberToStringTranslator(inputNumber);
                UI.ShowResult(translator.NumberIntValue, translator.NumberStringValue);
            }
            else
            {
                UI.ShowMessage(UIMessageTypes.HelpMessage);
            }
        }

        private static bool ConfirmInputValidation(string[] args, out int numberInt)
        {
            bool IsValid = false;
            numberInt = 0;

            if (args.Length > 0)
            {   
                if (int.TryParse(args[0], out numberInt))
                {
                    IsValid = true;
                }
            }            
            
            return IsValid;
        }
    }
}
