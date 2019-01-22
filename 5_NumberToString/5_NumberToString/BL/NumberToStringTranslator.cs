using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToString
{
    class NumberToStringTranslator
    {
        #region Constants
        private const int MAX_FIXED_NAME_NUMBER = 19;
        private const int THREE_DIGIT = 1000;
        private const int TWO_DIGIT = 100;
        private const int ONE_DIGIT = 10;
        private const string MINUS_MARKER = "minus ";
        private const string HUNDRED_MARKER = "hundred";
        #endregion

        public NumberToStringTranslator(int numericInput)
        {
            NumberIntValue = numericInput;
            NumberStringValue = TranslateNumberToString(numericInput);
        }

        public int NumberIntValue { get; private set; }
        public string NumberStringValue { get; private set; }

        public static string TranslateNumberToString(int numericInput)
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
                    string currentNumberString = TranslateThreeDigitNuberToString(numericInput % THREE_DIGIT);

                    if (threeDigitalsCounter >= 1)
                    {
                        string threeDigitals = string.Format("{0} ",
                            Enum.GetName(typeof(ThreeDigitals), threeDigitalsCounter));

                        currentNumberString = string.Format("{0}{1}", currentNumberString, threeDigitals);
                    }                    

                    outputBuilder.Insert(0, currentNumberString);

                    numericInput /= THREE_DIGIT;
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

            if (numericInput / TWO_DIGIT > 0)
            {
                string hundreds = string.Format("{0} {1} ",
                    Enum.GetName(typeof(Numbers), numericInput / TWO_DIGIT),
                    HUNDRED_MARKER);

                outputBuilder.Append(hundreds);
            }

            if ((numericInput % TWO_DIGIT > 0) && (numericInput % TWO_DIGIT <= MAX_FIXED_NAME_NUMBER))
            {
                string numbers = string.Format("{0} ",
                    Enum.GetName(typeof(Numbers), numericInput % TWO_DIGIT));

                outputBuilder.Append(numbers);
            }
            else
            {
                if ((numericInput % TWO_DIGIT) / ONE_DIGIT > 0)
                {
                    string dozens = string.Format("{0} ",
                        Enum.GetName(typeof(Dozens), (numericInput % TWO_DIGIT) / ONE_DIGIT));

                    outputBuilder.Append(dozens);
                }

                if ((numericInput % ONE_DIGIT) % ONE_DIGIT > 0)
                {
                    string numbers = string.Format("{0} ",
                        Enum.GetName(typeof(Numbers), (numericInput % ONE_DIGIT) % ONE_DIGIT));

                    outputBuilder.Append(numbers);
                }
            }

            return outputBuilder.ToString();
        }
    }
}
