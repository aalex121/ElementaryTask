using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_LuckyTickets
{
    public class AlgorithmFileReaderStub : IAlgorithmReader
    {
        #region Constants
        const string VALID_ALGORITHM_FILE_EXTENSION = ".txt";
        #endregion

        public AlgorithmFileReaderStub(params string[] fakeContent)
        {
            _fakeContent = fakeContent;
        }

        public string GetAlgorithmLine(string filePath, params string[] validAlgorithmNames)
        {
            filePath = Path.GetFullPath(filePath);
            string output = string.Empty;

            if (validAlgorithmNames.Length == 0 || !ValidateFilePath(filePath))
            {
                return output;
            }

            for (int i = 0; i < _fakeContent.Length; i++)
            {
                string item = _fakeContent[i].Trim().ToLower();

                if (validAlgorithmNames.Contains(item))
                {
                    output = item;
                    break;
                }
            }

            return output;
        }

        private static bool ValidateFilePath(string filePath)
        {
            bool isValid = false;

            if (filePath.Length > 0)
            {   
                 isValid = Path.GetExtension(filePath) == VALID_ALGORITHM_FILE_EXTENSION;
            }

            return isValid;
        }

        private string[] _fakeContent = null;
    }
}
