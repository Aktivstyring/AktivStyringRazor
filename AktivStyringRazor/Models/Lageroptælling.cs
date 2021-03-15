using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Lageroptælling
    {
        public int AktivID { get; set; }
        public int Placering { get; set; }
        public DateTime PlaceringDato { get; set; }
        public string PlaceringNote { get; set; }
        public int LinkID { get; set; }

        public Lageroptælling()
        {
        }

        public Lageroptælling(int aktivId, int placering, DateTime placeringDato, string placeringNote, int linkId)
        {
            AktivID = aktivId;
            Placering = placering;
            PlaceringDato = placeringDato;
            PlaceringNote = placeringNote;
            LinkID = linkId;
        }

        public override string ToString()
        {
            return $"{nameof(AktivID)}: {AktivID}, {nameof(Placering)}: {Placering}, {nameof(PlaceringDato)}: {PlaceringDato}, {nameof(PlaceringNote)}: {PlaceringNote}, {nameof(LinkID)}: {LinkID}";
        }
    }
}
