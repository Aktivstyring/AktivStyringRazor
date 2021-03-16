using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services.AktivService
{
    public class AktivService: IAktivService
    {
        List<Aktiv> aktiver;
        string connectionString;
        public IConfiguration Configuration { get; }
        public AktivService(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConfiguration"];
            aktiver = new List<Aktiv>();
        }

        public Task AddAktivAsync(Aktiv aktiv)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAktivAsync(Aktiv aktiv)
        {
            throw new NotImplementedException();
        }

        public Task<Aktiv> GetAktivById()
        {
            throw new NotImplementedException();
        }

        public Task<List<Aktiv>> GetAktiverAsync()
        {
            throw new NotImplementedException();
        }
    }
}
