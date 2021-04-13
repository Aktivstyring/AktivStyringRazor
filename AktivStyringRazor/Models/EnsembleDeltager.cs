using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class EnsembleDeltager
    {
        public int EnsDeltager;
        public int PersonID;
        public int EnsembleID;
        public int RolleID;
        public DateTime Tilmeldt;
        public DateTime Udmeldt;


        public EnsembleDeltager()
        {

        }

        public EnsembleDeltager(int personID, int ensembleID, int rolleID)
        {
            PersonID = personID;
            EnsembleID = ensembleID;
            RolleID = rolleID;
        }
    }
}
