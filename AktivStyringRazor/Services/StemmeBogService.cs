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
    public class StemmeBogService : Connection, IStemmeBogService
    {

        private string queryString = "select * from StemmeBøger";
        private string queryById = "select * from StemmeBøger where StemmeBogID = @ID";
        private string insertSql = "insert into StemmeBøger(StemmeBogType, BogStatus, UddeltTil, Instrument, StemmeType) values(@StemmeBogType, @BogStatus, @UddeltTil, @Instrument, @StemmeType)";
        private string queryDelete = "delete from StemmeBøger where StemmeBogID = @ID";
        private string queryALLJoin = "select StemmeBøger.StemmeBogID, StemmeBogType.Bogtype, StemmmeBogStatus.BogStatus, Personer.Navn, AktivType.AktivType, StemmeNummer.StemmeNummerTal from (((((StemmeBøger INNER JOIN StemmeBogType ON StemmeBøger.StemmeBogType = StemmeBogType.StemmeBogTypeID) INNER JOIN StemmmeBogStatus ON StemmeBøger.BogStatus = StemmmeBogStatus.StemmmeBogStatusID) left JOIN Personer on StemmeBøger.UddeltTil = Personer.PersonID) inner join AktivType on StemmeBøger.Instrument = AktivType.AktivTypeID) inner join StemmeNummer on StemmeBøger.StemmeType = StemmeNummer.StemmeNummerID)";
        private string queryUDDELTJoin = "select StemmeBøger.StemmeBogID, StemmeBogType.Bogtype, StemmmeBogStatus.BogStatus, Personer.Navn, AktivType.AktivType, StemmeNummer.StemmeNummerTal from (((((StemmeBøger INNER JOIN StemmeBogType ON StemmeBøger.StemmeBogType = StemmeBogType.StemmeBogTypeID) INNER JOIN StemmmeBogStatus ON StemmeBøger.BogStatus = StemmmeBogStatus.StemmmeBogStatusID) INNER JOIN Personer on StemmeBøger.UddeltTil = Personer.PersonID) inner join AktivType on StemmeBøger.Instrument = AktivType.AktivTypeID) inner join StemmeNummer on StemmeBøger.StemmeType = StemmeNummer.StemmeNummerID)";




        public StemmeBogService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddStemmeBogAsync(StemmeBog stemmeBog)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (stemmeBog.StemmeBogTypeID == null)
                { command.Parameters.AddWithValue("@StemmeBogType", "null"); }
                else
                { command.Parameters.AddWithValue("@StemmeBogType", stemmeBog.StemmeBogTypeID); }

                if (stemmeBog.BogStatus == null)
                { command.Parameters.AddWithValue("@BogStatus", "null"); }
                else
                { command.Parameters.AddWithValue("@BogStatus", stemmeBog.BogStatus); }

                if (stemmeBog.UddeltTil == null)
                { command.Parameters.AddWithValue("@UddeltTil", "null"); }
                else
                { command.Parameters.AddWithValue("@UddeltTil", stemmeBog.UddeltTil); }

                if (stemmeBog.Instrument == null)
                { command.Parameters.AddWithValue("@Instrument", "null"); }
                else
                { command.Parameters.AddWithValue("@Instrument", stemmeBog.Instrument); }

                if (stemmeBog.StemmeType == null)
                { command.Parameters.AddWithValue("@StemmeType", "null"); }
                else
                { command.Parameters.AddWithValue("@StemmeType", stemmeBog.StemmeType); }

                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public async Task<StemmeBog> GetStemmeBogByIdAsync(int stemmeBogID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogId = reader.GetInt32(0);
                    int? stemmeBogType = nullableGet.getNullableInt(1, reader);
                    int? bogStatus = nullableGet.getNullableInt(2, reader);
                    int? uddeltTil = nullableGet.getNullableInt(3, reader);
                    int? instrument = nullableGet.getNullableInt(4, reader);
                    int? stemmeType = nullableGet.getNullableInt(5, reader);

                    StemmeBog stemmeBog = new StemmeBog(stemmeBogId, stemmeBogType, bogStatus, uddeltTil, instrument, stemmeType);
                    return stemmeBog;
                }
                return null;
            }
        }

        public async Task<StemmeBog> DeleteStemmeBogAsync(int stemmeBogID)
        {
            StemmeBog stemmeBog = await GetStemmeBogByIdAsync(stemmeBogID);
            if ( stemmeBog == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", stemmeBogID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return stemmeBog; }
                return null;
            }
        }

        public async Task<List<StemmeBog>> GetStemmeBogAsync()
        {
            List<StemmeBog> stemmeBogs = new List<StemmeBog>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogId = reader.GetInt32(0);
                    int? stemmeBogType = nullableGet.getNullableInt(1, reader);
                    int? bogStatus = nullableGet.getNullableInt(2, reader);
                    int? uddeltTil = nullableGet.getNullableInt(3, reader);
                    int? instrument = nullableGet.getNullableInt(4, reader);
                    int? stemmeType = nullableGet.getNullableInt(5, reader);

                    StemmeBog stemmeBog = new StemmeBog(stemmeBogId, stemmeBogType, bogStatus, uddeltTil, instrument, stemmeType);
                    stemmeBogs.Add(stemmeBog);
                }
            }
            return stemmeBogs;
        }

        public async Task<List<StemmeBogInJoLi>> GetStemmeBogInJoLiAsync()
        {
            List<StemmeBogInJoLi> stemmeBogInJoList = new List<StemmeBogInJoLi>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryALLJoin, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int stemmeBogId = reader.GetInt32(0);
                    string? stemmeBogType = nullableGet.getNullableString(1, reader);
                    string? bogStatus = nullableGet.getNullableString(2, reader);
                    string? uddeltTil = nullableGet.getNullableString(3, reader);
                    string? instrument = nullableGet.getNullableString(4, reader);
                    string? stemmeType = nullableGet.getNullableString(5, reader);

                    StemmeBogInJoLi stemmeBogInJoLi = new StemmeBogInJoLi(stemmeBogId, stemmeBogType, bogStatus, uddeltTil, instrument, stemmeType);
                    stemmeBogInJoList.Add(stemmeBogInJoLi);
                }
            }
            return stemmeBogInJoList;
        }


    }
}
