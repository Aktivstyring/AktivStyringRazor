using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class StemmeBogStatus
    {
        public int StemmeBogStatusID { get; set; }
        public string? BogStatus { get; set; }

        public StemmeBogStatus() { }

        public StemmeBogStatus(int stemmeBogStatusID, string? bogStatus)
        {
            StemmeBogStatusID = stemmeBogStatusID;
            BogStatus = bogStatus;
        }

        public override string ToString()
        {
            return $"{nameof(StemmeBogStatusID)}: {StemmeBogStatusID}, {nameof(BogStatus)}: {BogStatus}";
        }
    }
}
