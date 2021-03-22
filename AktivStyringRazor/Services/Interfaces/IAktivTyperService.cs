using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    interface IAktivTyperService
    {
        Task<List<AktivTyper>> GetAktivTyperByAktivTypeAsync();
        Task<List<AktivTyper>> GetAktivtyperAsync();
        Task addAktivTyperAsync(AktivTyper aktivTyper);
        Task<AktivTyper> GetAktivTyperByIdAsync(string AktivTypeID);
    }
}
