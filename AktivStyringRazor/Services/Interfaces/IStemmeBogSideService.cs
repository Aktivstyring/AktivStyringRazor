using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IStemmeBogSideService
    {
        Task<List<StemmeBogSide>> GetStemmeBogSideAsync();
        Task<bool> AddStemmeBogSideAsync(StemmeBogSide stemmeBogSide);
        Task<StemmeBogSide> GetStemmeBogSideByIdAsync(int stemmeBogSideID);
        Task<StemmeBogSide> DeleteStemmeBogSideAsync(int stemmeBogSideID);

    }
}
