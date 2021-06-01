using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeBogType
    {
        public int StemmeBogTypeID { get; set; }
        public string? BogType { get; set; }


        public StemmeBogType()
        {
        }


        public StemmeBogType(int stemmeBogTypeID, string? bogType)
        {
            StemmeBogTypeID = stemmeBogTypeID;
            BogType = bogType;
        }

        public override string ToString()
        {
            return $"{nameof(StemmeBogTypeID)}: {StemmeBogTypeID}, {nameof(BogType)}: {BogType}";
        }
    }
}
