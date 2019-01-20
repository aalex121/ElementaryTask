using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class InvalidTicketDigitsCountException : ArgumentException
    {
        const string ERROR_MESSAGE = "Ticket digit quantity must be positive and even!";
        const string INVALID_PARAM_MESSAGE = "Provided digit quantity is";        

        public InvalidTicketDigitsCountException()
        {
        }

        public InvalidTicketDigitsCountException(int digitQuantity)
        {
            _errorMessageString = string.Format("{0}\n{1}: {2}", ERROR_MESSAGE, INVALID_PARAM_MESSAGE,
                digitQuantity);            
        }

        public InvalidTicketDigitsCountException(string message)
            : base(message)
        {
        }

        public InvalidTicketDigitsCountException(string message, Exception innerException)
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
