using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_FileParser
{
    static class DataProviderFactory
    {
        public static ITxtFileProcessor GetFileProcessor(TxtFileParser parser)
        {
            ITxtFileProcessor dataProvider = null;

            switch (parser.DataProviderType)
            {
                case DataProviderTypes.Real:
                    dataProvider = new TxtFileProcessor(parser);
                    break;
                case DataProviderTypes.Fake:
                    dataProvider = new FakeFileProcessor(parser);
                    break;
                default:
                    break;
            }

            if (dataProvider != null)
            {
                if (!dataProvider.CheckFileExistance())
                {
                    dataProvider = null;
                }
            }

            return dataProvider;
        }
    }
}
