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
    public class StemmeBogStatusService : Connection, IStemmeBogStatusService
    {
        
        private string queryString = "select * from StemmmeBogStatus";
        private string queryById = "select * from StemmmeBogStatus where StemmmeBogStatusID = @ID";
        private string insertSql = "insert into StemmmeBogStatus(BogStatus) values(@BogStatus)";
        private string queryDelete = "delete from StemmmeBogStatus where StemmmeBogStatusID = @ID";

        
        public StemmeBogStatusService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddStemmeBogStatusAsync(StemmeBogStatus stemmeBogStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (stemmeBogStatus.BogStatus == null)
                { command.Parameters.AddWithValue("@StemmeBogTypeID", "null"); }
                else
                { command.Parameters.AddWithValue("@StemmeBogTypeID", stemmeBogStatus.BogStatus); }
        
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        
        public async Task<StemmeBogStatus> GetStemmeBogStatusByIdAsync(int stemmmeBogStatusID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", stemmmeBogStatusID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmmeBogStatusId = reader.GetInt32(0);
                    string? bogStatus = nullableGet.getNullableString(1, reader);

                    StemmeBogStatus stemmeBogStatus = new StemmeBogStatus(stemmmeBogStatusId, bogStatus);
                    return stemmeBogStatus;
                }
                return null;
            }
        }
        
        public async Task<StemmeBogStatus> DeleteStemmeBogStatusAsync(int stemmmeBogStatusID)
        {
            StemmeBogStatus stemmeBogStatus = await GetStemmeBogStatusByIdAsync(stemmmeBogStatusID);
            if (stemmeBogStatus == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", stemmmeBogStatusID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return stemmeBogStatus; }
                return null;
            }
        }
        
        public async Task<List<StemmeBogStatus>> GetStemmeBogStatusAsync()
        {
            List<StemmeBogStatus> stemmeBogStatuser = new List<StemmeBogStatus>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmmeBogStatusId = reader.GetInt32(0);
                    string? bogStatus = nullableGet.getNullableString(1, reader);

                    StemmeBogStatus stemmeBogStatus = new StemmeBogStatus(stemmmeBogStatusId, bogStatus);
                    stemmeBogStatuser.Add(stemmeBogStatus);
                }
            }
            return stemmeBogStatuser;
        }

    }
}
