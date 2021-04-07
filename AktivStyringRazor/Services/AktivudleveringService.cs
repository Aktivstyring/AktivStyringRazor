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
        public AktivudleveringService(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<Aktivudlevering>> GetAktivudleveringerByPersonId(int personID)
        {
            List<Aktivudlevering> aktivudleveringer = new List<Aktivudlevering>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryByPId, connection);
                command.Parameters.AddWithValue("personID", personID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int? aktivID=nullableGet.getNullableInt(0, reader);
                    int? _personID =nullableGet.getNullableInt(1, reader);
                    DateTime ? aktivUddelt=nullableGet.getNullableDateTime(2,reader);
                    DateTime ? aktivIndsamlet = nullableGet.getNullableDateTime(3, reader);
                    int udleveringsId=reader.GetInt32(4);

                    Aktivudlevering aktivudlevering = new Aktivudlevering();
                    aktivudlevering.AktivID = aktivID;
                    aktivudlevering.PersonID = _personID;
                    aktivudlevering.AktivUddelt = aktivUddelt;
                    aktivudlevering.AktivIndsamlet = aktivIndsamlet;
                    aktivudlevering.UdleveringsID = udleveringsId;

                    aktivudleveringer.Add(aktivudlevering);
                }

            }
                return aktivudleveringer;
        }
    }
}
