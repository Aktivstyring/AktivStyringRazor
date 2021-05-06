using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Node
    {
        public int MusikID { get; set; }
        public string Titel { get; set; }
        public string Komponist { get; set; }
        public string Forfatter { get; set; }
        public string Forlag { get; set; }

        public Node() { }

        public Node(int musikID, string titel, string komponist, string forfatter, string forlag)
        {
            MusikID = musikID;
            Titel = titel;
            Komponist = komponist;
            Forfatter = forfatter;
            Forlag = forlag;
        }


        public override string ToString()
        {
            return $"{nameof(MusikID)}: {MusikID}, {nameof(Titel)}: {Titel}, {nameof(Komponist)}: {Komponist}, {nameof(Forfatter)}: {Forfatter}, {nameof(Forlag)}: {Forlag}";
        }
    }
}
