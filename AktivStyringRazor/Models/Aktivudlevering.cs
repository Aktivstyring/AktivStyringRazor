using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Aktivudlevering
    {
        public int UdleveringsID { get; set; }
        public string? AktivType { get; set; }
        public string? Maerke { get; set; }
        public string? SerieNr { get; set; }
        public DateTime? AktivUddelt { get; set; }
        public DateTime? AktivIndsamlet { get; set; }

        public Aktivudlevering()
        {
        }

        public Aktivudlevering(int udleveringsId, string? aktivType, string? maerke, string serieNr, DateTime? aktivUddelt, DateTime? aktivIndsamlet)
        {
            UdleveringsID = udleveringsId;
            AktivType = aktivType;
            Maerke = maerke;
            SerieNr = serieNr;
            AktivUddelt = aktivUddelt;
            AktivIndsamlet = aktivIndsamlet;
        }

        public override string ToString()
        {
            return $"{nameof(UdleveringsID)}: {UdleveringsID}, {nameof(AktivType)}: {AktivType}, {nameof(Maerke)}: {Maerke}, {nameof(SerieNr)}: {SerieNr}, {nameof(AktivUddelt)}: {AktivUddelt}, {nameof(AktivIndsamlet)}: {AktivIndsamlet}";
        }
    }
}
