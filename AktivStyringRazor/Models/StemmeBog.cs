using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeBog
    {
        public int StemmeBogID { get; set; }
        public int StemmeBogTypeID { get; set; }
        public int BogStatus { get; set; }
        public int UddeltTil { get; set; }
        public int Instrument { get; set; }
        public int StemmeType { get; set; }

        public StemmeBog() { }

        public StemmeBog(int stemmeBogID, int stemmeBogTypeID, int bogStatus, int uddeltTil, int instrument, int stemmeType)
        {
            StemmeBogID = stemmeBogID;
            StemmeBogTypeID = stemmeBogTypeID;
            BogStatus = bogStatus;
            UddeltTil = uddeltTil;
            Instrument = instrument;
            StemmeType = stemmeType;
        }

        public override string ToString()
        {
            return $"{nameof(StemmeBogID)}: {StemmeBogID}, {nameof(StemmeBogTypeID)}: {StemmeBogTypeID}, {nameof(BogStatus)}: {BogStatus},{nameof(UddeltTil)}: {UddeltTil}, {nameof(Instrument)}: {Instrument}, {nameof(StemmeType)}: {StemmeType}";
        }
    }
}
