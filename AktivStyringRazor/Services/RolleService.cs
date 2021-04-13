using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.handlers;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AktivStyringRazor.Services
{
    public class RolleService : Connection, IRollerService
    {
        private string queryString = "select * from Roller";
        private string queryById = "select * from Roller where RolleID = @ID";
        private string insertSql = "insert into Roller(Rolle) values(@Rolle)";
        private string queryDelete = "delete from Roller where RolleID = @ID";



        public RolleService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddRollerAsync(Roller roller)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                command.Parameters.AddWithValue("@Rolle", roller.Rolle);

                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public async Task<Roller> DeleteRollerAsync(int rolleID)
        {
            Roller rolle = await GetRollerByIdAsync(rolleID);
            if (rolle == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", rolleID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return rolle; }
                return null;
            }
        }
        
        public async Task<Roller> GetRollerByIdAsync(int rolleID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", rolleID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int rolleId = reader.GetInt32(0);

                    string rolle = nullableGet.getNullableString(1, reader); 

                    
                    Roller roller = new Roller(rolleId, rolle);
                    return roller;
                }
                return null;
            }
        }
        public async Task<List<Roller>> GetRollerAsync()
        {
            List<Roller> roller = new List<Roller>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int rolleId = reader.GetInt32(0);

                    string rolle = nullableGet.getNullableString(1, reader); 
                           
        
                    Roller rolleList = new Roller();
                    roller.Add(rolleList);
                }
            }

            return roller;
        }
    }
}
