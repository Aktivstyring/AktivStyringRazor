using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeBogSide
    {
        public int StemmeBogSideID { get; set; }
        public int? MusikID { get; set; }
        public int? StemmeBogTypeID { get; set; }
        public int? SideTal { get; set; }

        public StemmeBogSide() { }

        public StemmeBogSide(int stemmeBogSideID, int? musikID, int? stemmeBogTypeID, int? sideTal)
        {
            StemmeBogSideID = stemmeBogSideID;
            MusikID = musikID;
            StemmeBogTypeID = stemmeBogTypeID;
            SideTal = sideTal;
        }

        public override string ToString()
        {
            return $"{nameof(StemmeBogSideID)}: {StemmeBogSideID}, {nameof(MusikID)}: {MusikID}, {nameof(StemmeBogTypeID)}: {StemmeBogTypeID}, {nameof(SideTal)}: {SideTal}";
        }
    }
}
