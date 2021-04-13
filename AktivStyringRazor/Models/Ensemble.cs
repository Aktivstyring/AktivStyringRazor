using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Ensemble
    {
        public int EnsembleID;
        public string Navn;
        public string Noter;

        public Ensemble()
        {

        }


        public Ensemble(int ensembleID, string navn, string noter)
        {
            EnsembleID = ensembleID;
            Navn = navn;
            Noter = noter;
        }


    }
}
