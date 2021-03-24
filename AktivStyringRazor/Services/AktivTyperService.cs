using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AktivStyringRazor.Services
{
    public class AktivTyperService : Connection, IAktivTyperService
    {
        //SQLstatements
        private String queryString = "select * from AktivType";
        private string queryById = "select from AktivType where AktivTypeID = @ID";
        private string insertSql = "insert into AktivType(AktivType, AktivTypeOrder, AktivTypeID) values(@AktivType, @AktivTypeOrder, @AktivTypeID)";
        private string queryDelete = "delete from AktivType where AktivTypeID = @ID";



        public AktivTyperService(IConfiguration configuration) : base(configuration)
        {

        }


        public async Task<bool> AddAktivTyperAsync(AktivTyper aktivTyper)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@AktivType", aktivTyper.AktivType);
                command.Parameters.AddWithValue("@AktivTypeOrder", aktivTyper.AktivTypeOrder);
                command.Parameters.AddWithValue("@AktivTypeID", aktivTyper.AktivTypeID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false;
                }
            }
        }
        
        
        public async Task<AktivTyper> DeleteAktivTypeAsync(int aktivTypeID)
        {
            AktivTyper aktiv = await GetAktivTyperByIdAsync(aktivTypeID);
            if (aktiv == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", aktivTypeID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return aktiv; }
                return null;
            }
        }
        

        public async Task<List<AktivTyper>> GetAktivtyperAsync()
        {
            List<AktivTyper> aktivTyper = new List<AktivTyper>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string aktivType;
                    if (reader.IsDBNull(0))
                    { aktivType = "null"; }
                    else { aktivType = reader.GetString(0);}

                    int? aktivTypeOrder;
                    if (reader.IsDBNull(1))
                    { aktivTypeOrder = null; }
                    else
                    { aktivTypeOrder = reader.GetInt32(1);}

                    int aktivTypeId = reader.GetInt32(2);

                    AktivTyper aktivTypr = new AktivTyper(aktivType, aktivTypeOrder, aktivTypeId);
                    aktivTyper.Add(aktivTypr);
                }
            }

            return aktivTyper;
        }

        
        public async Task<AktivTyper> GetAktivTyperByIdAsync(int AktivTypeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("ID", AktivTypeID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    string aktivType;
                    if (reader.IsDBNull(0)) { aktivType = "null"; }
                    else { aktivType = reader.GetString(0); }

                    int? aktivTypeOrder;
                    if (reader.IsDBNull(1))
                    { aktivTypeOrder = null; }
                    else
                    { aktivTypeOrder = reader.GetInt32(1); }

                    int aktivTypeID = reader.GetInt32(2);

                }
            }
            return null;
        }


        public Task<List<AktivTyper>> GetAktivTyperByAktivTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
