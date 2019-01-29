using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_LuckyTickets
{
    public interface IAlgorithmReader
    {
        string GetAlgorithmLine(string filePath, params string[] validAlgorithmNames);
    }
}
