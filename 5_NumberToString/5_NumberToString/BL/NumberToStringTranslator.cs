using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToString
{
    class NumberToStringTranslator
    {
        const int MAX_FIXED_NAME_NUMBER = 19;        
        const string MINUS_MARKER = "minus ";
        const string HUNDRED_MARKER = "hundred";

        public NumberToStringTranslator(int numericInput)
        {
            NumberIntValue = numericInput;
            NumberStringValue = TranslateNuberToString(numericInput);
        }

        public int NumberIntValue { get; private set; }

        public string NumberStringValue { get; private set; }

        public static string TranslateNuberToString(int numericInput)
        {
            StringBuilder outputBuilder = new StringBuilder();

            bool minusFlag = numericInput < 0;
            
            numericInput = Math.Abs(numericInput);           

            if (numericInput <= MAX_FIXED_NAME_NUMBER)
            {                
                outputBuilder.Append(Enum.GetName(typeof(Numbers), numericInput));
            }
            else
            {
                int threeDigitalsCounter = 0;                
                
                while (numericInput > 0)
                {
                    string currentNumber = TranslateThreeDigitNuberToString(numericInput % 1000);

                    if (threeDigitalsCounter >= 1)
                    {
                        string threeDigitals = string.Format("{0} ",
                            Enum.GetName(typeof(ThreeDigitals), threeDigitalsCounter));

                        currentNumber = string.Format("{0}{1}", currentNumber, threeDigitals);
                    }                    

                    outputBuilder.Insert(0, currentNumber);

                    numericInput /= 1000;
                    threeDigitalsCounter++;
                }
            }

            if (minusFlag)
            {
                outputBuilder.Insert(0, MINUS_MARKER);
            }

            return outputBuilder.ToString();
        }

        private static string TranslateThreeDigitNuberToString(int numericInput)
        {
            StringBuilder outputBuilder = new StringBuilder();            

            if (numericInput / 100 > 0)
            {
                string hundreds = string.Format("{0} {1} ",
                    Enum.GetName(typeof(Numbers), numericInput / 100),
                    HUNDRED_MARKER);

                outputBuilder.Append(hundreds);
            }

            if (numericInput % 100 > 0 && numericInput % 100 <= MAX_FIXED_NAME_NUMBER)
            {
                string numbers = string.Format("{0} ",
                    Enum.GetName(typeof(Numbers), numericInput % 100));

                outputBuilder.Append(numbers);
            }
            else
            {
                if ((numericInput % 100) / 10 > 0)
                {
                    string dozens = string.Format("{0} ",
                        Enum.GetName(typeof(Dozens), (numericInput % 100) / 10));

                    outputBuilder.Append(dozens);
                }

                if ((numericInput % 10) % 10 > 0)
                {
                    string numbers = string.Format("{0} ",
                        Enum.GetName(typeof(Numbers), (numericInput % 10) % 10));

                    outputBuilder.Append(numbers);
                }
            }

            return outputBuilder.ToString();
        }
    }
}
