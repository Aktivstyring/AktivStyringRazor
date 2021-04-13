using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IEnsembleDeltagerService
    {
        //Task<List<EnsembleDeltager>> GetEnsembleDeltagerByNavnAsync();
        Task<List<EnsembleDeltager>> GetEnsembleDeltagerAsync();
        Task<bool> AddEnsembleDeltagerAsync(EnsembleDeltager ensembleDeltager);
        Task<EnsembleDeltager> GetEnsembleDeltagerByIdAsync(int ensDeltagerID);
        Task<EnsembleDeltager> DeleteEnsembleDeltagerAsync(int ensDeltagerID);
    }
}
