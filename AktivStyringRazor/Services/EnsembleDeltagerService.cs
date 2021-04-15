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
    public class EnsembleDeltagerService : Connection, IEnsembleDeltagerService
    {
        private string queryString = "select * from EnsembleDeltagere";
        private string queryById = "select * from EnsembleDeltagere where EnsDeltagerID = @ID";
        private string insertSql = "insert into EnsembleDeltagere(PersonID, EnsembleID, RolleID, Tilmeldt, Udmeldt) values(@PersonID, @EnsembleID, @RolleID, @Tilmeldt, @Udmeldt)";
        private string queryDelete = "delete from EnsembleDeltagere where EnsDeltagerID = @ID";


        
        public EnsembleDeltagerService(IConfiguration configuration) : base(configuration)
        {

        }

        
        public async Task<bool> AddEnsembleDeltagerAsync(EnsembleDeltager ensembleDeltager)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                //@PersonID, @EnsembleID, @RolleID, @Tilmeldt, @Udmeldt
                command.Parameters.AddWithValue("@PersonID", ensembleDeltager.PersonID);
                command.Parameters.AddWithValue("@EnsembleID", ensembleDeltager.EnsembleID);

                if (ensembleDeltager.RolleID == null)
                { command.Parameters.AddWithValue("@RolleID", null); }
                else
                { command.Parameters.AddWithValue("@RolleID", ensembleDeltager.RolleID); }

                if (ensembleDeltager.Tilmeldt == null)
                { command.Parameters.AddWithValue("@Tilmeldt", null); }
                else
                { command.Parameters.AddWithValue("@Tilmeldt", ensembleDeltager.Tilmeldt); }
                
                if (ensembleDeltager.Tilmeldt == null)
                { command.Parameters.AddWithValue("@Udmeldt", null); }
                else
                { command.Parameters.AddWithValue("@Udmeldt", ensembleDeltager.Udmeldt); }


                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        
        public async Task<EnsembleDeltager> DeleteEnsembleDeltagerAsync(int ensDeltagerID)
        {
            EnsembleDeltager ensembleDeltager = await GetEnsembleDeltagerByIdAsync(ensDeltagerID);
            if (ensembleDeltager == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", ensDeltagerID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return ensembleDeltager; }
                return null;
            }
        }
        
        public async Task<EnsembleDeltager> GetEnsembleDeltagerByIdAsync(int ensDeltagerID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", ensDeltagerID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int _ensDeltagerID = reader.GetInt32(0);

                    int personID = reader.GetInt32(1);

                    int ensembleID = reader.GetInt32(2);

                    int? rolleID = nullableGet.getNullableInt(3, reader);

                    DateTime? tilmeldt = nullableGet.getNullableDateTime(4, reader);

                    DateTime? udmeldt = nullableGet.getNullableDateTime(5, reader);

                    EnsembleDeltager ensembleDeltager = new EnsembleDeltager(_ensDeltagerID, personID, ensembleID, rolleID, tilmeldt, udmeldt);
                    return ensembleDeltager;
                }
                return null;
            }
        }
        
        public async Task<List<EnsembleDeltager>> GetEnsembleDeltagerAsync()
        {
            List<EnsembleDeltager> ensembleDeltagerList = new List<EnsembleDeltager>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int _ensDeltagerID = reader.GetInt32(0);

                    int personID = reader.GetInt32(1);

                    int ensembleID = reader.GetInt32(2);

                    int? rolleID = nullableGet.getNullableInt(3, reader);

                    DateTime? tilmeldt = nullableGet.getNullableDateTime(4, reader);

                    DateTime? udmeldt = nullableGet.getNullableDateTime(5, reader);

                    EnsembleDeltager ensembleDeltager = new EnsembleDeltager(_ensDeltagerID, personID, ensembleID, rolleID, tilmeldt, udmeldt);
                    ensembleDeltagerList.Add(ensembleDeltager);
                }
            }
            return ensembleDeltagerList;
        }
    }
}
