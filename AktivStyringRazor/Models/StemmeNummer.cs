using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeNummer
    {
        public int StemmeNummerID { get; set; }
        public string StemmeNummerTal { get; set; }

        public StemmeNummer() { }

        public StemmeNummer(int stemmeNummerID, string stemmeNummerTal)
        {
            StemmeNummerID = stemmeNummerID;
            StemmeNummerTal = stemmeNummerTal;
        }

        public override string ToString()
        {
            return $"{nameof(StemmeNummerID)}: {StemmeNummerID}, {nameof(StemmeNummerTal)}: {StemmeNummerTal}";
        }
    }
}
