using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Eftersyn
    {
        public int AktivID { get; set; }
        public DateTime EftersynDato { get; set; }
        public string EftersynNote { get; set; }
        public int EftersynID { get; set; }
        public DateTime Oprettet { get; set; }


        public Eftersyn()
        {
        }

        public Eftersyn(int aktivId, DateTime eftersynDato, string eftersynNote, int eftersynId, DateTime oprettet)
        {
            AktivID = aktivId;
            EftersynDato = eftersynDato;
            EftersynNote = eftersynNote;
            EftersynID = eftersynId;
            Oprettet = oprettet;
        }

        public override string ToString()
        {
            return $"{nameof(AktivID)}: {AktivID}, {nameof(EftersynDato)}: {EftersynDato}, {nameof(EftersynNote)}: {EftersynNote}, {nameof(EftersynID)}: {EftersynID}, {nameof(Oprettet)}: {Oprettet}";
        }
    }
}
