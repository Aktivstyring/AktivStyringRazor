using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class AktivTyper
    {
        public string AktivType { get; set; }
        public int? AktivTypeOrder { get; set; }
        public int AktivTypeID { get; set; }

        public AktivTyper()
        {
        }

        public AktivTyper(string aktivType, int? aktivTypeOrder, int aktivTypeId)
        {
            AktivType = aktivType;
            AktivTypeOrder = aktivTypeOrder;
            AktivTypeID = aktivTypeId;
        }


        public override string ToString()
        {
            return $"{nameof(AktivType)}: {AktivType}, {nameof(AktivTypeOrder)}: {AktivTypeOrder}, {nameof(AktivTypeID)}: {AktivTypeID}";
        }
    }
}
