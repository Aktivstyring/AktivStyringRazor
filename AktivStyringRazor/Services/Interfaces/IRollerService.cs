using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IRollerService
    {
        //Task<List<Roller>> GetRollerByRolleAsync();
        Task<List<Roller>> GetRollerAsync();
        Task<bool> AddRollerAsync(Roller roller);
        Task<Roller> GetRollerByIdAsync(int rolleID);
        Task<Roller> DeleteRollerAsync(int rolleID);
    }
}
