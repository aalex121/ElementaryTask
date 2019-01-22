using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    class UnableToBuildTriangleException : Exception
    {
        #region Constants
        private const string SIDES_MESSAGE = "Triangle sides:";
        private const string DEFAULT_ERROR_MESSAGE = "Unable to build a triangle";
        #endregion

        public UnableToBuildTriangleException()
        {                
        }

        public UnableToBuildTriangleException(string message)
            : base(message)
        {
        }

        public UnableToBuildTriangleException(string message, double side1, double side2, double side3)
            : base(message)
        {
            _triangleErrorMessage = string.Format("{0}\n{1} {2}, {3}, {4}",
                message, SIDES_MESSAGE, side1, side2, side3);
        }

        public UnableToBuildTriangleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return _triangleErrorMessage;
        }

        private string _triangleErrorMessage = DEFAULT_ERROR_MESSAGE;
    }
}
