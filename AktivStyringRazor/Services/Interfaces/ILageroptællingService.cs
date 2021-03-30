using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public class ILageroptællingService
    {
        Task<List<Lageroptælling>> GetLageroptællingByLinkIDAsync();
        Task<List<Lageroptælling>> GetLageroptællingAsync();
        Task<bool> AddLageroptællingAsync(Lageroptælling lageroptælling);
        Task<Lageroptælling> GetLageroptællingByIdAsync(int linkID);
        Task<Lageroptælling> DeleteLageroptællingAsync(int linkID);
    }
}
