using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeBogInJoLi
    {
        public int StemmeBogID { get; set; }
        public string? StemmeBogTypeID { get; set; }
        public string? BogStatus { get; set; }
        public string? UddeltTil { get; set; }
        public string? Instrument { get; set; }
        public string? StemmeType { get; set; }

        public StemmeBogInJoLi() { }

        public StemmeBogInJoLi(int stemmeBogID, string? stemmeBogTypeID, string? bogStatus, string? uddeltTil, string? instrument, string? stemmeType)
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
