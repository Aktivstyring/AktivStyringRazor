using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services
{
    public class LoginService : Connection
    {
        private string logInSql = "Select * from Personer where Email = @Email and Keyphrase = @Keyphrase";
        public LoginService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> LogInAsync(string keyphrase, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(logInSql, connection);
                command.Parameters.AddWithValue("@Keyphrase", keyphrase);
                command.Parameters.AddWithValue("@Email", email);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }

}
