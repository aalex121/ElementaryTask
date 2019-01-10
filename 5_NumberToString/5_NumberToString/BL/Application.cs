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
            if (ValidateUserInput(args))
            {
                NumberToStringTranslator translator = new NumberToStringTranslator(int.Parse(args[0]));
                UI.ShowResult(translator.NumberIntValue, translator.NumberStringValue);
            }
            else
            {
                UI.ShowMessage(UIMessageTypes.HelpMessage);
            }
        }

        private static bool ValidateUserInput(string[] args)
        {
            bool IsValid = false;

            if (args != null && args.Length > 0)
            {
                int numerInt;

                if (int.TryParse(args[0], out numerInt))
                {
                    IsValid = true;
                }
            }            
            
            return IsValid;
        }
    }
}
