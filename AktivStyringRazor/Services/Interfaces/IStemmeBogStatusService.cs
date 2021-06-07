using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IStemmeBogStatusService
    {
        Task<List<StemmeBogStatus>> GetStemmeBogStatusAsync();
        Task<bool> AddStemmeBogStatusAsync(StemmeBogStatus stemmeBogStatus);
        Task<StemmeBogStatus> GetStemmeBogStatusByIdAsync(int stemmmeBogStatusID);
        Task<StemmeBogStatus> DeleteStemmeBogStatusAsync(int stemmmeBogStatusID);

    }
}
