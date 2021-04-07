using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Models.SamleObjekter
{
    public class ProfilData
    {
        public Personer Person { get; set; }
        public List<Aktivudlevering> AktivUdleveringer { get; set; }
    }
}
