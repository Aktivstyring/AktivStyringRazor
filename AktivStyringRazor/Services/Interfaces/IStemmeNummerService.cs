using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IStemmeNummerService
    {
        Task<List<StemmeNummer>> GetStemmeNummerAsync();
        Task<bool> AddStemmeNummerAsync(StemmeNummer stemmeNummer);
        Task<StemmeNummer> GetStemmeNummerByIdAsync(int stemmeNummerID);
        Task<StemmeNummer> DeleteStemmeNummerAsync(int stemmeNummerID);
    }
}
