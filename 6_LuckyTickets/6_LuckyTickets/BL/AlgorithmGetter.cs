using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6_LuckyTickets
{
    public class AlgorithmGetter
    {
        #region Constants
        public const string ALGORITHM_NAME_MOSCOW = "moscow";
        public const string ALGORITHM_NAME_PITER = "piter";
        #endregion

        public AlgorithmGetter(IAlgorithmReader algorithmReader)
        {
            _algorithmReader = algorithmReader;
        }

        public TicketCountAlgorithms GetAlgorhytm(string filePath)
        {
            TicketCountAlgorithms result = TicketCountAlgorithms.None;

            string data = _algorithmReader.GetAlgorithmLine(filePath,
                ALGORITHM_NAME_MOSCOW, ALGORITHM_NAME_PITER);

            if (data == ALGORITHM_NAME_MOSCOW)
            {
                result = TicketCountAlgorithms.Moscow;
            }

            if (data == ALGORITHM_NAME_PITER)
            {
                result = TicketCountAlgorithms.Piter;
            }

            return result;
        }

        private readonly IAlgorithmReader _algorithmReader;
    }
}
