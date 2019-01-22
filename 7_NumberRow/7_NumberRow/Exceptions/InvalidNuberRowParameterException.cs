using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_NumberRow
{
    class InvalidNubmerRowParameterException : Exception
    {
        #region Constants
        private const string ERROR_MESSAGE = "Invalid Number row parameter. Number must be not less than";
        private const string INVALID_PARAM_MESSAGE = "Provided Number is";
        #endregion

        public InvalidNubmerRowParameterException()
        {            
        }

        public InvalidNubmerRowParameterException(uint numericParam, int minValidValue)
        {
            _errorMessageString = string.Format("{0}: {1} {2}: {3}", ERROR_MESSAGE, minValidValue,
                INVALID_PARAM_MESSAGE, numericParam);
        }

        public InvalidNubmerRowParameterException(string message)
            : base(message)
        {            
        }

        public InvalidNubmerRowParameterException(string message, Exception innerException)
            : base(message, innerException)
        {            
        }

        public override string ToString()
        {
            return _errorMessageString;
        }

        private string _errorMessageString = ERROR_MESSAGE;
    }
}
