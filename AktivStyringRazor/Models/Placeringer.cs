using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Placeringer
    {
        public int PlaceringID { get; set; }
        public string Placering { get; set; }
        public int? PlaceringSort { get; set; }


        public Placeringer()
        {
        }


        public Placeringer(int placeringId, string placering, int? placeringSort)
        {
            PlaceringID = placeringId;
            Placering = placering;
            PlaceringSort = placeringSort;
        }

        public override string ToString()
        {
            return $"{nameof(PlaceringID)}: {PlaceringID}, {nameof(Placering)}: {Placering}, {nameof(PlaceringSort)}: {PlaceringSort}";
        }
    }
}
