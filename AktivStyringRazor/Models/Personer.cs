using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Personer
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresse { get; set; }
        public string MedlemsNr { get; set; }

        public Personer()
        {
        }

        public Personer(string navn, string email, string telefon, string adresse, string medlemsNr)
        {
            Navn = navn;
            Email = email;
            Telefon = telefon;
            Adresse = adresse;
            MedlemsNr = medlemsNr;
        }


        public override string ToString()
        {
            return $"{nameof(Navn)}: {Navn}, {nameof(Email)}: {Email}, {nameof(Telefon)}: {Telefon}, {nameof(Adresse)}: {Adresse}, {nameof(MedlemsNr)}: {MedlemsNr}";
        }
    }
}
