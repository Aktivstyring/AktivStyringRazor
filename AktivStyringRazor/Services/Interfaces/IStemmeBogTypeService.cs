using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IStemmeBogTypeService
    {
        Task<List<StemmeBogType>> GetStemmeBogTypeAsync();
        Task<bool> AddStemmeBogTypeAsync(StemmeBogType stemmeBogType);
        Task<StemmeBogType> GetStemmeBogTypeByIdAsync(int stemmeBogTypeID);
        Task<StemmeBogType> DeleteStemmeBogTypeAsync(int stemmeBogTypeID);
        
    }
}
