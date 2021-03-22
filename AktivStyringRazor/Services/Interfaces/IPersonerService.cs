using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface IPersonerService
    {
        Task<List<Personer>> GetPersonerByNavnAsync();
        Task<List<Personer>>GetPersonerAsync();
        Task<bool> AddPersonerAsync(Personer personer);
        Task<Personer> GetPersonerByIdAsync(int personId);

    }
}
