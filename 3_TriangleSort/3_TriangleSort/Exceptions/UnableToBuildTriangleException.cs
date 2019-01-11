using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    class UnableToBuildTriangleException : Exception
    {
        public UnableToBuildTriangleException()
        {                
        }

        public UnableToBuildTriangleException(string message)
            : base(message)
        {

        }
        
        public UnableToBuildTriangleException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
