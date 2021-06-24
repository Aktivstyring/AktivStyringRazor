using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IStemmeBogService
    {
        Task<List<StemmeBog>> GetStemmeBogAsync();
        Task<List<StemmeBogInJoLi>> GetStemmeBogInJoLiAsync();
        Task<bool> AddStemmeBogAsync(StemmeBog stemmeBog);
        Task<StemmeBog> GetStemmeBogByIdAsync(int stemmeBogID);
        Task<StemmeBog> DeleteStemmeBogAsync(int stemmeBogID);
        //Task<List<Node>> GetStemmeBogByTypeAsync();
    }
}
