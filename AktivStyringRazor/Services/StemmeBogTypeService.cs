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
    public class StemmeBogTypeService : Connection, IStemmeBogTypeService
    {
        
        private string queryString = "select * from StemmeBogType";
        private string queryById = "select * from StemmeBogType where StemmeBogTypeID = @ID";
        private string insertSql = "insert into StemmeBogType(BogType) values(@BogType)";
        private string queryDelete = "delete from StemmeBogType where StemmeBogTypeID = @ID";


        public StemmeBogTypeService(IConfiguration configuration) : base(configuration)
        {

        }
        
        public async Task<bool> AddStemmeBogTypeAsync(StemmeBogType stemmeBogType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (stemmeBogType.BogType == null)
                { command.Parameters.AddWithValue("@BogType", "null"); }
                else
                { command.Parameters.AddWithValue("@BogType", stemmeBogType.BogType); }

                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        
        public async Task<StemmeBogType> GetStemmeBogTypeByIdAsync(int stemmeBogTypeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogTypeID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogTypeId = reader.GetInt32(0);
                    string? bogType = nullableGet.getNullableString(1, reader);


                    StemmeBogType stemmeBogType = new StemmeBogType(stemmeBogTypeId, bogType);
                    return stemmeBogType;
                }
                return null;
            }
        }
        
        public async Task<StemmeBogType> DeleteStemmeBogTypeAsync(int stemmeBogTypeID)
        {
            StemmeBogType stemmeBogType = await GetStemmeBogTypeByIdAsync(stemmeBogTypeID);
            if (stemmeBogType == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogTypeID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return stemmeBogType; }
                return null;
            }
        }
        
        public async Task<List<StemmeBogType>> GetStemmeBogTypeAsync()
        {
            List<StemmeBogType> stemmeBogTyper = new List<StemmeBogType>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogTypeId = reader.GetInt32(0);
                    string? bogType = nullableGet.getNullableString(1, reader);
        
                    StemmeBogType stemmeBogType = new StemmeBogType(stemmeBogTypeId, bogType);
                    stemmeBogTyper.Add(stemmeBogType);
                }
            }
            return stemmeBogTyper;
        }
    }
}
