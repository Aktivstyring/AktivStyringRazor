using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Aktivudleveringer
    {
        public int AktivID { get; set; }
        public int PersonID { get; set; }
        public DateTime AktivUddelt { get; set; }
        public DateTime AktivIndsamlet { get; set; }
        public int UdleveringsID { get; set; }

        public Aktivudleveringer()
        {
        }

        public Aktivudleveringer(int aktivId, int personId, DateTime aktivUddelt, DateTime aktivIndsamlet, int udleveringsId)
        {
            AktivID = aktivId;
            PersonID = personId;
            AktivUddelt = aktivUddelt;
            AktivIndsamlet = aktivIndsamlet;
            UdleveringsID = udleveringsId;
        }

        public override string ToString()
        {
            return $"{nameof(AktivID)}: {AktivID}, {nameof(PersonID)}: {PersonID}, {nameof(AktivUddelt)}: {AktivUddelt}, {nameof(AktivIndsamlet)}: {AktivIndsamlet}, {nameof(UdleveringsID)}: {UdleveringsID}";
        }
    }
}
