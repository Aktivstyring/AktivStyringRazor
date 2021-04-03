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
    public class LageroptællingService : Connection, ILageroptællingService
    {


        private String queryString = "select * from Lageroptælling";
        private string queryById = "select * from Lageroptælling where LinkID = @ID";
        private string insertSql = "insert into Lageroptælling(AktivID, PlaceringID, PlaceringDato, PlaceringNote, LinkID) values(@AktivID, @PlaceringID, @PlaceringDato, @PlaceringNote, @LinkID)";
        private string queryDelete = "delete from Lageroptælling where LinkID = @ID";

        public LageroptællingService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddLageroptællingAsync(Lageroptælling lageroptælling)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                if (lageroptælling.AktivID == null) { command.Parameters.AddWithValue("@AktivID", "null"); } else { command.Parameters.AddWithValue("@AktivID", lageroptælling.AktivID); }
                if (lageroptælling.Placering == null) { command.Parameters.AddWithValue("@PlaceringID", "null"); } else { command.Parameters.AddWithValue("@PlaceringID", lageroptælling.Placering); }
                if (lageroptælling.PlaceringDato == null) { command.Parameters.AddWithValue("@PlaceringDato", "null"); } else { command.Parameters.AddWithValue("@PlaceringDato", lageroptælling.PlaceringDato); }
                if (lageroptælling.PlaceringNote == null) { command.Parameters.AddWithValue("@PlaceringNote", "null"); } else { command.Parameters.AddWithValue("@PlaceringNote", lageroptælling.PlaceringNote); }
                if (lageroptælling.LinkID == null) { command.Parameters.AddWithValue("@LinkID", "null"); } else { command.Parameters.AddWithValue("@LinkID", lageroptælling.LinkID); }
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public async Task<Lageroptælling> DeleteLageroptællingAsync(int linkID)
        {
            Lageroptælling lageroptælling = await GetLageroptællingByIdAsync(linkID);
            if (lageroptælling == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", linkID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return lageroptælling; }
                return null;
            }


        }


        public async Task<List<Lageroptælling>> GetLageroptællingAsync()
        {
            List<Lageroptælling> lageroptællingList = new List<Lageroptælling>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int aktivID = reader.GetInt32(0);

                    int placering = reader.GetInt32(1);

                    DateTime placeringDato = reader.GetDateTime(2);

                    string placeringNote;
                    if (reader.IsDBNull(1)) { placeringNote = "null"; }
                    else { placeringNote = reader.GetString(3); }

                    int linkID = reader.GetInt32(4);


                    Lageroptælling lageroptælling = new Lageroptælling(aktivID, placering, placeringDato, placeringNote, linkID);
                    lageroptællingList.Add(lageroptælling);
                }
            }
            return lageroptællingList;
        }


        public async Task<Lageroptælling> GetLageroptællingByIdAsync(int linkID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", linkID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int aktivID = reader.GetInt32(0);

                    int placering = reader.GetInt32(1);

                    DateTime placeringDato;
                    if (reader.IsDBNull(1)) { placeringDato = null; }
                    else { placeringDato = reader.GetDateTime(2); }

                    string placeringNote;
                    if (reader.IsDBNull(1)) { placeringNote = "null"; }
                    else { placeringNote = reader.GetString(3); }

                    int linkId = reader.GetInt32(4);


                    Lageroptælling lageroptælling = new Lageroptælling();
                    return lageroptælling;
                }
                return null;
            }
        }

        public Task<List<Lageroptælling>> GetLageroptællingByLinkIDAsync()
        {
            throw new NotImplementedException();
        }
    }
}
