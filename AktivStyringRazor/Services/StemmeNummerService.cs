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
    public class StemmeNummerService : Connection, IStemmeNummerService
    {
        
        private string queryString = "select * from StemmeNummer";
        private string queryById = "select * from StemmeNummer where StemmeNummerID = @ID";
        private string insertSql = "insert into StemmeNummer(StemmeNummerTal) values(@StemmeNummerTal)";
        private string queryDelete = "delete from StemmeNummer where StemmeNummerID = @ID";


        public StemmeNummerService(IConfiguration configuration) : base(configuration)
        {

        }
        
        public async Task<bool> AddStemmeNummerAsync(StemmeNummer stemmeNummer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (stemmeNummer.StemmeNummerTal == null)
                { command.Parameters.AddWithValue("@StemmeNummerTal", "null"); }
                else
                { command.Parameters.AddWithValue("@StemmeNummerTal", stemmeNummer.StemmeNummerTal); }

                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        
        public async Task<StemmeNummer> GetStemmeNummerByIdAsync(int stemmeNummerID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", stemmeNummerID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeNrID = reader.GetInt32(0);
                    string? stemmeNummerTal = nullableGet.getNullableString(1, reader);

                    StemmeNummer stemmeNummer = new StemmeNummer(stemmeNrID, stemmeNummerTal);
                    return stemmeNummer;
                }
                return null;
            }
        }
        
        public async Task<StemmeNummer> DeleteStemmeNummerAsync(int stemmeNummerID)
        {
            StemmeNummer stemmeNummer = await GetStemmeNummerByIdAsync(stemmeNummerID);
            if (stemmeNummer == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", stemmeNummerID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return stemmeNummer; }
                return null;
            }
        }
        
        public async Task<List<StemmeNummer>> GetStemmeNummerAsync()
        {
            List<StemmeNummer> StemmeNummre = new List<StemmeNummer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeNrID = reader.GetInt32(0);
                    string? stemmeNummerTal = nullableGet.getNullableString(1, reader);

                    StemmeNummer stemmeNummer = new StemmeNummer(stemmeNrID, stemmeNummerTal);
                    StemmeNummre.Add(stemmeNummer);
                }
            }
            return StemmeNummre;
        }
    }
}
