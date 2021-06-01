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
    public class StemmeBogSideService : Connection, IStemmeBogSideService
    {
        private string queryString = "select * from StemmeBogSide";
        private string queryById = "select * from StemmeBogSide where StemmeBogSideID = @ID";
        private string insertSql = "insert into StemmeBogSide(MusikID, StemmeBogTypeID, Sidetal) values(@MusikID, @StemmeBogTypeID, @Sidetal)";
        private string queryDelete = "delete from StemmeBogSide where StemmeBogSideID = @ID";


        public StemmeBogSideService(IConfiguration configuration) : base(configuration)
        {

        }
        
        public async Task<bool> AddStemmeBogSideAsync(StemmeBogSide stemmeBogSide)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (stemmeBogSide.MusikID == null)
                { command.Parameters.AddWithValue("@MusikID", "null"); }
                else
                { command.Parameters.AddWithValue("@MusikID", stemmeBogSide.MusikID); }

                if (stemmeBogSide.StemmeBogTypeID == null)
                { command.Parameters.AddWithValue("@StemmeBogTypeID", "null"); }
                else
                { command.Parameters.AddWithValue("@StemmeBogTypeID", stemmeBogSide.StemmeBogTypeID); }

                if (stemmeBogSide.SideTal == null)
                { command.Parameters.AddWithValue("@SideTal", "null"); }
                else
                { command.Parameters.AddWithValue("@SideTal", stemmeBogSide.SideTal); }
                
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public async Task<StemmeBogSide> GetStemmeBogSideByIdAsync(int stemmeBogSideID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogSideID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogSideId = reader.GetInt32(0);
                    int? musikID = nullableGet.getNullableInt(2, reader);
                    int? stemmeBogType = nullableGet.getNullableInt(1, reader);
                    int? sideTal = nullableGet.getNullableInt(3, reader);
                    
                    StemmeBogSide stemmeBogSide = new StemmeBogSide(stemmeBogSideId, musikID, stemmeBogType, sideTal);
                    return stemmeBogSide;
                }
                return null;
            }
        }

        public async Task<StemmeBogSide> DeleteStemmeBogSideAsync(int stemmeBogSideID)
        {
            StemmeBogSide stemmeBogSide = await GetStemmeBogSideByIdAsync(stemmeBogSideID);
            if (stemmeBogSide == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogSideID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return stemmeBogSide; }
                return null;
            }
        }

        public async Task<List<StemmeBogSide>> GetStemmeBogSideAsync()
        {
            List<StemmeBogSide> stemmeBogSider = new List<StemmeBogSide>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogSideId = reader.GetInt32(0);
                    int? musikID = nullableGet.getNullableInt(2, reader);
                    int? stemmeBogType = nullableGet.getNullableInt(1, reader);
                    int? sideTal = nullableGet.getNullableInt(3, reader);

                    StemmeBogSide stemmeBogSide = new StemmeBogSide(stemmeBogSideId, musikID, stemmeBogType, sideTal);
                    stemmeBogSider.Add(stemmeBogSide);
                }
            }
            return stemmeBogSider;
        }
    }
}
