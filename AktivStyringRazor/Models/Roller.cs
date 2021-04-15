using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Roller
    {
        public int RolleID;
        public string Rolle;

        public Roller()
        {

        }

        public Roller(int rolleId, string rolle)
        {
            RolleID = rolleId;
            Rolle = rolle;
        }


    }
}
