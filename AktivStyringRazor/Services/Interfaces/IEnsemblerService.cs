using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IEnsemblerService
    {
        Task<List<Ensemble>> GetEnsembleAsync();
        Task<bool> AddEnsembleAsync(Ensemble ensemble);
        Task<Ensemble> GetEnsembleByIDAsync(int ensembleID);
        Task<Ensemble> DeleteEnsembleAsync(int ensembleID);
    }
}
