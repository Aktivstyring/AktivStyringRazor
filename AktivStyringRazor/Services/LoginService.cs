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

        //Til Demo
        private string unsafeLogInSQL = "Select * from Personer where Email = ";

        //demo fortsat
        public async Task<bool> UnsafeLogInAsync(string keyphrase, string email)
        {
        
        string unsafeQuery = unsafeLogInSQL + email + " and Keyphrase = " +keyphrase;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(logInSql, connection);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

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
