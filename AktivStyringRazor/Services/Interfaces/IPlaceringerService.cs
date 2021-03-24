using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IPlaceringerService
    {
        Task<List<Placeringer>> GetPlaceringerByPlaceringAsync();
        Task<List<Placeringer>> GetPlaceringerAsync();
        Task<bool> AddPlaceringerAsync(Placeringer placeringer);
        Task<Placeringer> GetPlaceringerByIdAsync(int PlaceringID);
        Task<Placeringer> DeletePlaceringerAsync(int PlaceringID);
    }
}
