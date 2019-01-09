using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Envelopes
{
    static class Application
    {
        public static bool Run()
        {
            double envelopeWidth;
            double envelopeHeight;

            UI.RequestParams(Envelpoes.First, out envelopeWidth, out envelopeHeight);
            Envelope env1 = new Envelope(envelopeWidth, envelopeHeight);

            UI.RequestParams(Envelpoes.Second, out envelopeWidth, out envelopeHeight);
            Envelope env2 = new Envelope(envelopeWidth, envelopeHeight);

            int compareResult = env1.CompareTo(env2);

            UI.ShowCompareResult(compareResult);

            return UI.GetAppExitPrompt();
        }
    }
}
