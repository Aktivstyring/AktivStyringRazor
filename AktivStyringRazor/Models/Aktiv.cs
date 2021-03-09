using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Aktiv
    {
        public int AktivTypeID { get; set; }
        public string Maerke { get; set; }
        public string Model { get; set; }
        public string ModelUddyb { get; set; }
        public string SerieNr { get; set; }
        public string Kaldenavn { get; set; }
        public int HarStregkode { get; set; }
        public int FraKommando { get; set; }
        public int Privat { get; set; }
        public DateTime Købt { get; set; }
        public DateTime Udskrevet { get; set; }
        public DateTime Oprettet { get; set; }
        public DateTime Opdateret { get; set; }


    }
}
