using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    class RecursionDepthTooBigException : Exception
    {
        #region Constants
        private const string ERROR_MESSAGE = "Recursion depth limit reached!";        
        #endregion

        public RecursionDepthTooBigException()
        {
        }

        public RecursionDepthTooBigException(string message)
            : base(message)
        {
        }

        public RecursionDepthTooBigException(string message, Exception innerException)
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
