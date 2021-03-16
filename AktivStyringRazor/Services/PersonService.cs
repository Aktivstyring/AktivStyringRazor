using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services
{
    public class PersonService : Connection, IPersonerService
    {


        private String queryString = "select * from Personer";

        public PersonService(IConfiguration configuration) : base(configuration)
        {

        }

        public Task AddPersonerAsync(Personer personer)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Personer>> GetPersonerAsync()
        {
            List<Personer> personer = new List<Personer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int personId = reader.GetInt32(0);
                    string navn;
                    if (reader.IsDBNull(1)) { navn = "null"; }
                    else { navn = reader.GetString(1);}

                    string telefonNr;
                    if (reader.IsDBNull(2)) { telefonNr = "null"; }
                    else { telefonNr = reader.GetString(2); }

                    string email;
                    if (reader.IsDBNull(3)) { email = "null"; }
                    else { email = reader.GetString(3); }

                    string adresse;
                    if (reader.IsDBNull(4)) { adresse = "null"; }
                    else { adresse = reader.GetString(4); }

                    string medlemsNr;
                    if (reader.IsDBNull(5)) { medlemsNr = "null"; }
                    else { medlemsNr = reader.GetString(5); }
                    Personer person = new Personer(personId, navn, email,telefonNr,adresse,medlemsNr);
                    personer.Add(person);
                }
            }
            return personer;
        }


        public Task<Personer> GetPersonerByIdAsync(string MedlemsNr)
        {
            throw new NotImplementedException();
        }

        public Task<List<Personer>> GetPersonerByNavnAsync()
        {
            throw new NotImplementedException();
        }
    }
}
