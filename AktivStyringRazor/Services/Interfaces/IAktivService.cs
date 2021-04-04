using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IAktivService
    {

        Task<List<Aktiv>> GetAktiverAsync();
        Task<bool> AddAktivAsync(Aktiv aktiv);
        Task<Aktiv> GetAktivByIdAsync(int aktivID);
        Task<Aktiv> DeleteAktivAsync(int aktivID);

    }
}
