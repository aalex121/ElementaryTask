using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_LuckyTickets
{
    static class AlgorithmFileReader
    {
        public static string GetAlgorithmLine(string filePath)
        {
            string output = null;

            using (StreamReader file = new StreamReader(filePath))
            {
                string currentLine = null;

                do
                {
                    currentLine = file.ReadLine();

                    if (currentLine != null)
                    {
                        currentLine = currentLine.Trim().ToLower();

                        if (currentLine == Application.ALGORITHM_NAME_MOSCOW 
                                || currentLine == Application.ALGORITHM_NAME_PITER)
                        {
                            output = currentLine;
                        }
                    }

                } while (currentLine != null);
            }

            return output;
        }
    }
}
