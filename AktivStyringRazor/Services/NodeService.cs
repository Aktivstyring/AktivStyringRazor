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
    public class NodeService : Connection, INodeService 
    {
        private string queryString = "select * from Noder";
        private string queryById = "select * from Noder where MusikID = @ID";
        private string insertSql = "insert into Noder(Titel, Komponist, Forfatter, Forlag) values(@Titel, @Komponist, @Forfatter, @Forlag)";
        private string queryDelete = "delete from Noder where MusikID = @ID";


        public NodeService(IConfiguration configuration) : base(configuration)
        {

        }


        public async Task<bool> AddNodeAsync(Node node)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                if (node.Titel == null)
                { command.Parameters.AddWithValue("@Titel", "null"); }
                else
                { command.Parameters.AddWithValue("@Titel", "null"); }

                if (node.Komponist == null)
                { command.Parameters.AddWithValue("@Komponist", "null"); }
                else
                { command.Parameters.AddWithValue("@Komponist", "null"); }

                if (node.Forfatter == null)
                { command.Parameters.AddWithValue("@Forfatter", "null"); }
                else
                { command.Parameters.AddWithValue("@Forfatter", "null"); }

                if (node.Forlag == null)
                { command.Parameters.AddWithValue("@Forlag", "null"); }
                else
                { command.Parameters.AddWithValue("@Forlag", "null"); }

                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }


        public async Task<Node> GetNodeByIdAsync(int musikID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", musikID);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int musikId = reader.GetInt32(0);

                    string titel = nullableGet.getNullableString(1, reader);

                    string komponist = nullableGet.getNullableString(2, reader);

                    string forfatter = nullableGet.getNullableString(3, reader);

                    string forlag = nullableGet.getNullableString(4, reader);

                    Node node = new Node(musikId, titel, komponist, forfatter, forlag);
                    return node;
                }
                return null;
            }
        }


        public async Task<Node> DeleteNodeAsync(int musikID)
        {
            Node node = await GetNodeByIdAsync(musikID);
            if ( node == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", musikID);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return node; }
                return null;
            }
        }


        public async Task<List<Node>> GetNoderAsync()
        {
            List<Node> noder = new List<Node>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int musikID = reader.GetInt32(0);

                    string titel;
                    if (reader.IsDBNull(1)) { titel = "null"; }
                    else { titel = reader.GetString(1); }

                    string komponist;
                    if (reader.IsDBNull(2)) { komponist = "null"; }
                    else { komponist = reader.GetString(2); }

                    string forfatter;
                    if (reader.IsDBNull(3)) { forfatter = "null"; }
                    else { forfatter = reader.GetString(3); }

                    string forlag;
                    if (reader.IsDBNull(4)) { forlag = "null"; }
                    else { forlag = reader.GetString(4); }

                    Node node = new Node(musikID, titel, komponist, forfatter, forlag);
                    noder.Add(node);
                }
            }
            return noder;
        }







    }
}
