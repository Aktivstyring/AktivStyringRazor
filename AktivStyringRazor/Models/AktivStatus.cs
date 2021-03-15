using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class AktivStatus
    {
        public int AktivStatusID { get; set; }
        public string StatusAktiv { get; set; }
        public int AktivStatusGrad { get; set; }
        public int AktivStatusOrder { get; set; }

        public AktivStatus()
        {
        }

        public AktivStatus(int aktivStatusID, string statusAktiv, int aktivStatusGrad, int aktivStatusOrder)
        {
            AktivStatusID = aktivStatusID;
            StatusAktiv = statusAktiv;
            AktivStatusGrad = aktivStatusGrad;
            AktivStatusOrder = aktivStatusOrder;
        }

        public override string ToString()
        {
            return $"{nameof(AktivStatusID)}: {AktivStatusID}, {nameof(StatusAktiv)}: {StatusAktiv}, {nameof(AktivStatusGrad)}: {AktivStatusGrad}, {nameof(AktivStatusOrder)}: {AktivStatusOrder}";
        }
    }
}
