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
        Task AddAktivAsync(Aktiv aktiv);
        Task DeleteAktivAsync(Aktiv aktiv);
        Task<Aktiv> GetAktivById();

    }
}
