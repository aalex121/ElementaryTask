using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_LuckyTickets
{
    public class AlgorithmFileReader : IAlgorithmReader
    {
        #region Constants
        const string VALID_ALGORITHM_FILE_EXTENSION = ".txt";
        #endregion

        public string GetAlgorithmLine(string filePath, params string[] validAlgorithmNames)
        {
            filePath = Path.GetFullPath(filePath);
            string output = string.Empty;

            if (validAlgorithmNames.Length == 0 || !ValidateFilePath(filePath))
            {
                return output;
            }

            using (StreamReader file = new StreamReader(filePath))
            {
                string currentLine = null;

                do
                {
                    currentLine = file.ReadLine();

                    if (currentLine != null)
                    {
                        currentLine = currentLine.Trim().ToLower();

                        if (validAlgorithmNames.Contains(currentLine))
                        {
                            output = currentLine;
                        }
                    }

                } while (currentLine != null);
            }

            return output;
        }

        private static bool ValidateFilePath(string filePath)
        {
            bool isValid = false;

            if (filePath.Length > 0)
            {
                if (File.Exists(filePath))
                {
                    isValid = Path.GetExtension(filePath) == VALID_ALGORITHM_FILE_EXTENSION;
                }
            }

            return isValid;
        }
    }
}
