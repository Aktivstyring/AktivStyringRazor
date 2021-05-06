using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Personer
    {

        public int PersonId { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresse { get; set; }
        public int? MedlemsNr { get; set; }
        //public string note {get; set;}

        public Personer()
        {
        }

        public Personer(int personId, string navn, string email, string telefon, string adresse, int? medlemsNr)
        {
            PersonId = personId;
            Navn = navn;
            Email = email;
            Telefon = telefon;
            Adresse = adresse;
            MedlemsNr = medlemsNr;
        }


        public override string ToString()
        {
            return $"{nameof(PersonId)}: {PersonId}, {nameof(Navn)}: {Navn}, {nameof(Email)}: {Email}, {nameof(Telefon)}: {Telefon}, {nameof(Adresse)}: {Adresse}, {nameof(MedlemsNr)}: {MedlemsNr}";
        }
    }
}
