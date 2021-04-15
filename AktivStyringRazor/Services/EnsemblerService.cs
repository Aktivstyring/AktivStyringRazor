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
    public class EnsemblerService : Connection, IEnsemblerService
    {
        private string queryString = "select * from Ensembler";
        private string queryById = "select * from Ensembler where EnsembleID = @ID";
        private string insertSql = "insert into Ensembler(Navn, Noter) values(@Navn, @Noter)";
        private string queryDelete = "delete from Ensembler where EnsembleID = @ID";

        public EnsemblerService(IConfiguration configuration) : base(configuration)
        {
            
        }
        
        public async Task<bool> AddEnsembleAsync(Ensemble ensemble)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (ensemble.Navn == null)
                { command.Parameters.AddWithValue("@Navn", "null"); }
                else
                { command.Parameters.AddWithValue("@Navn", ensemble.Navn); }

                if (ensemble.Noter == null)
                { command.Parameters.AddWithValue("@Noter", "null"); }
                else
                { command.Parameters.AddWithValue("@Noter", ensemble.Noter); }
                
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        
        public async Task<Ensemble> DeleteEnsembleAsync(int ensembleID)
        {
            Ensemble ensemble = await GetEnsembleByIDAsync(ensembleID);
            if (ensemble == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", ensembleID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return ensemble; }
                return null;
            }
        }
        

        public async Task<Ensemble> GetEnsembleByIDAsync(int ensembleID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", ensembleID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int ensembleId = reader.GetInt32(0);

                    string navn = reader.GetString(1);

                    string noter = nullableGet.getNullableString(2, reader);

                    Ensemble ensemble = new Ensemble(ensembleId, navn, noter);
                    return ensemble;
                }
                return null;
            }
        }


        
        public async Task<List<Ensemble>> GetEnsembleAsync()
        {
            List<Ensemble> ensembleList = new List<Ensemble>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int ensembleId = reader.GetInt32(0);

                    string navn = reader.GetString(1);

                    string noter = nullableGet.getNullableString(2, reader);

                    Ensemble ensemble = new Ensemble(ensembleId, navn, noter);
                    ensembleList.Add(ensemble);
                }
            }
            return ensembleList;
        }
    }
}
