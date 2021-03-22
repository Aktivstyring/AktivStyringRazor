using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AktivStyringRazor.Services
{
    public class AktivTyperService : Connection, IAktivTyperService
    {
        //SQLstatements
        private String queryString = "select * from AktivType";



        public AktivTyperService(IConfiguration configuration) : base(configuration) { }

        public Task AddAktivTyperAsync(AktivTyper aktivTyper)
        {
            throw new NotImplementedException();
        }
        
        public Task<List<AktivTyper>> GetAktivTyperByAktivTypeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AktivTyper>> GetAktivtyperAsync()
        {
            List<AktivTyper> aktivTyper = new List<AktivTyper>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string aktivType;
                    if (reader.IsDBNull(0))
                    { aktivType = "null"; }
                    else { aktivType = reader.GetString(0);}

                    int? aktivTypeOrder;
                    if (reader.IsDBNull(1))
                    { aktivTypeOrder = null; }
                    else
                    { aktivTypeOrder = reader.GetInt32(1);}

                    int aktivTypeId = reader.GetInt32(2);

                    AktivTyper aktivTypr = new AktivTyper(aktivType, aktivTypeOrder, aktivTypeId);
                    aktivTyper.Add(aktivTypr);
                }
            }

            return aktivTyper;
        }

        
        public Task addAktivTyperAsync(AktivTyper aktivTyper)
        {
            throw new NotImplementedException();
        }

        public Task<AktivTyper> GetAktivTyperByIdAsync(string AktivTypeID)
        {
            throw new NotImplementedException();
        }
    }
}
