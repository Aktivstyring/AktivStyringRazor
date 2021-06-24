using AktivStyringRazor.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.handlers;

namespace AktivStyringRazor.Services
{
    public class AktivudleveringService : Connection
    {
        private string queryByPId = "select * from AktivUdleveringer where PersonID = @personID";
        private string insertSql = "insert into AktivUdleveringer(PersonID, AktivID, AktivUddelt) values(@PersonID,@AktivID,GETDATE())";
        private string qByPIdJoin = "select AktivUdleveringer.AktivID, AktivType.AktivType, Aktiver.Maerke, Aktiver.SerieNr, AktivUdleveringer.AktivUddelt, AktivUdleveringer.AktivIndsamlet from ((AktivUdleveringer INNER JOIN Aktiver on AktivUdleveringer.AktivID=Aktiver.AktivID) INNER JOIN AktivType on Aktiver.AktivTypeID = AktivType.AktivTypeID) where PersonID = @personID ORDER BY AktivUdleveringer.AktivIndsamlet ASC, AktivUdleveringer.AktivUddelt DESC";
        public AktivudleveringService(IConfiguration configuration) : base(configuration)
        {

        }
        
        
        public async Task<bool> AddUdleveringAsync(int pID, int aID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@PersonID", pID);
                command.Parameters.AddWithValue("@AktivID", aID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }


        public async Task<List<Aktivudlevering>> GetAktivudleveringerByPersonId(int pID)
        {
            List<Aktivudlevering> aktivudleveringer = new List<Aktivudlevering>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qByPIdJoin, connection);
                command.Parameters.AddWithValue("personID", pID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int udleveringsId = reader.GetInt32(0);
                    string? aktivType = nullableGet.getNullableString(1, reader);
                    string? maerke = nullableGet.getNullableString(2, reader);
                    string? serieNr = nullableGet.getNullableString(3, reader);
                    DateTime ? aktivUddelt=nullableGet.getNullableDateTime(4,reader);
                    DateTime ? aktivIndsamlet = nullableGet.getNullableDateTime(5, reader);

                    Aktivudlevering aktivudlevering = new Aktivudlevering();
                    aktivudlevering.UdleveringsID = udleveringsId;
                    aktivudlevering.AktivType = aktivType;
                    aktivudlevering.Maerke = maerke;
                    aktivudlevering.SerieNr = serieNr;
                    aktivudlevering.AktivUddelt = aktivUddelt;
                    aktivudlevering.AktivIndsamlet = aktivIndsamlet;

                    aktivudleveringer.Add(aktivudlevering);
                }

            }
            return aktivudleveringer;
        }

        public async Task<List<Aktivudlevering>> GetByPID(int pID)
        {
            List<Aktivudlevering> aktivudleveringer = new List<Aktivudlevering>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryByPId, connection);
                command.Parameters.AddWithValue("personID", pID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {

                }
                return aktivudleveringer;
            }
        }

    }
}
