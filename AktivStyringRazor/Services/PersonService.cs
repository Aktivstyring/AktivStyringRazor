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
        private string queryById = "select * from Personer where PersonId = @ID";
        private string insertSql = "insert into Personer(Navn, Telefon, Email, Adresse, MedlemsNr) values(@Navn, @Telefon, @Email, @Adresse, @MedlemsNr)";
        private string queryDelete = "delete from Personer where PersonId = @ID";

        public PersonService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddPersonerAsync(Personer personer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@Navn", personer.Navn);
                command.Parameters.AddWithValue("@Telefon", personer.Telefon);
                command.Parameters.AddWithValue("@Email", personer.Email);
                command.Parameters.AddWithValue("@Adresse", personer.Adresse);
                command.Parameters.AddWithValue("@MedlemsNr", personer.MedlemsNr);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public async Task<Personer> DeletePersonerAsync(int personId)
        {
            Personer person = await GetPersonerByIdAsync(personId);
            if(person == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", personId);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return person; }
                return null;
            }


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


        public async Task<Personer> GetPersonerByIdAsync(int personId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", personId);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int id = reader.GetInt32(0);
                    string navn;
                    if (reader.IsDBNull(1)) { navn = "null"; }
                    else { navn = reader.GetString(1); }

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
                    Personer person = new Personer(id, navn, email, telefonNr, adresse, medlemsNr);
                    return person;
                }
                return null;
            }
        }

        public Task<List<Personer>> GetPersonerByNavnAsync()
        {
            throw new NotImplementedException();
        }
    }
}
