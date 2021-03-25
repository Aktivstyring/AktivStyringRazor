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
    public class PlaceringService : Connection, IPlaceringerService
    {
        //SQLstatements
        private String queryString = "select * from Placeringer";
        private string queryById = "select from Placeringer where PlaceringID = @ID";
        private string insertSql = "insert into Placeringer(PlaceringID, Placering, PlaceringSort) values(@PlaceringID, @Placering, @PlaceringSort)";
        private string queryDelete = "delete from Placeringer where PlaceringID = @ID";

        

        public PlaceringService(IConfiguration configuration) : base(configuration)
        {

        }


        public async Task<bool> AddPlaceringerAsync(Placeringer placeringer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@PlaceringID", placeringer.PlaceringID);
                command.Parameters.AddWithValue("@Placering", placeringer.Placering);
                command.Parameters.AddWithValue("@PlaceringSort", placeringer.PlaceringSort);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public async Task<Placeringer> DeletePlaceringerAsync(int placeringID)
        {
            Placeringer aktiv = await GetPlaceringerByIdAsync(placeringID);
            if (aktiv == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", placeringID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return aktiv; }
                return null;
            }
        }


        public async Task<List<Placeringer>> GetPlaceringerAsync()
        {
            List<Placeringer> placeringList = new List<Placeringer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int placeringId = reader.GetInt32(0);

                    string placering;
                    if (reader.IsDBNull(1)) { placering = "null"; }
                    else { placering = reader.GetString(1); }

                    int? placeringSort;
                    if (reader.IsDBNull(1)) { placeringSort = null; }
                    else { placeringSort = reader.GetInt32(2); }


                    Placeringer placeringer = new Placeringer(placeringId, placering, placeringSort);
                    placeringList.Add(placeringer);
                }
            }

            return placeringList;
        }


        public async Task<Placeringer> GetPlaceringerByIdAsync(int PlaceringID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("ID", PlaceringID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    int placeringId = reader.GetInt32(0);

                    string placering;
                    if (reader.IsDBNull(1)) { placering = "null"; }
                    else { placering = reader.GetString(1); }

                    int? placeringSort;
                    if (reader.IsDBNull(1)) { placeringSort = null; }
                    else { placeringSort = reader.GetInt32(2); }

                }
            }
            return null;
        }


        public Task<List<Placeringer>> GetPlaceringerByPlaceringAsync()
        {
            throw new NotImplementedException();
        }
    }
}
