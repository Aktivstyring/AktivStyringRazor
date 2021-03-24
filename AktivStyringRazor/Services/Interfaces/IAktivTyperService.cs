using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IAktivTyperService
    {
        Task<List<AktivTyper>> GetAktivTyperByAktivTypeAsync();
        Task<List<AktivTyper>> GetAktivtyperAsync();
        Task<bool> AddAktivTyperAsync(AktivTyper aktivTyper);
        Task<AktivTyper> GetAktivTyperByIdAsync(int AktivTypeID);
        Task<AktivTyper> DeleteAktivTypeAsync(int aktivTypeID);
    }
}
