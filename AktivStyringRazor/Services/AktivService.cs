using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services.AktivService
{
    public class AktivService: Connection ,IAktivService
    {
        private string queryString = "select * from Aktiver";
        private string queryById = "select * from Aktiver where AktivID = @ID";
        private string insertSql = "insert into Aktiver(AktivTypeID, Maerke, Model, ModelUddyb, SerieNr, Kaldenavn, AktivstatusID, Detaljer, HarStregkode, FraKommando, Privat, Købt, Udskrevet, Oprettet, Opdateret) values(@AktivTypeID, @Maerke, @Model, @ModelUddyb, @SerieNr, @Kaldenavn, @AktivstatusID, @Detaljer, @HarStregkode, @FraKommando, @Privat, @Købt, @Udskrevet, @Oprettet, @Opdateret)";
        private string queryDelete = "delete from Personer where PersonId = @ID";


       
        public AktivService(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> AddAktivAsync(Aktiv aktiv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);

                #region AktivTypeID
                if (aktiv.AktivTypeID == null)
                {
                    command.Parameters.AddWithValue("@AktivTypeID", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@AktivTypeID", aktiv.AktivTypeID);
                }
                #endregion

                #region Maerke
                //Maerke
                if (aktiv.Maerke == null)
                {
                    command.Parameters.AddWithValue("@Maerke", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Maerke", aktiv.Maerke);
                }
                #endregion

                #region Model
                //Model
                if (aktiv.Model == null)
                {
                    command.Parameters.AddWithValue("@Model", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Model", aktiv.Model);
                }
                #endregion

                #region ModelUddyb
                //ModelUddyb
                if (aktiv.ModelUddyb == null)
                {
                    command.Parameters.AddWithValue("@ModelUddyb", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@ModelUddyb", aktiv.ModelUddyb);
                }
                #endregion

                #region SerieNr
                //SerieNr
                if (aktiv.SerieNr == null)
                {
                    command.Parameters.AddWithValue("@SerieNr", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@SerieNr", aktiv.SerieNr);
                }
                #endregion

                #region KaldeNavn
                //KaldeNavn
                if (aktiv.Kaldenavn == null)
                {
                    command.Parameters.AddWithValue("@Kaldenavn", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Kaldenavn", aktiv.Kaldenavn);
                }
                #endregion

                #region AktivstatusID
                if (aktiv.AktivstatusID == null)
                {
                    command.Parameters.AddWithValue("@AktivstatusID", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@AktivstatusID", aktiv.AktivstatusID);
                }
                #endregion

                #region Detaljer
                if (aktiv.Detaljer == null)
                {
                    command.Parameters.AddWithValue("@Detaljer", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Detaljer", aktiv.Detaljer);
                }
                #endregion

                #region HarStregkode
                if (aktiv.HarStregkode == null)
                {
                    command.Parameters.AddWithValue("@HarStregkode", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@HarStregkode", aktiv.HarStregkode);
                }
                #endregion

                #region FraKommando
                if (aktiv.FraKommando == null)
                {
                    command.Parameters.AddWithValue("@FraKommando", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@FraKommando", aktiv.FraKommando);
                }
                #endregion

                #region Privat
                if (aktiv.Privat == null)
                {
                    command.Parameters.AddWithValue("@Privat", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@Privat", aktiv.Privat);
                }
                #endregion

                #region Købt
                if (aktiv.Købt == null)
                {
                    command.Parameters.AddWithValue("@Købt", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Købt", aktiv);
                }
                #endregion

                #region Udskrevet
                if (aktiv.Udskrevet == null)
                {
                    command.Parameters.AddWithValue("@Udskrevet", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Udskrevet", aktiv.Udskrevet);
                }
                #endregion

                #region Oprettet
                if (aktiv.Oprettet == null)
                {
                    command.Parameters.AddWithValue("@Oprettet", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Oprettet", aktiv.Oprettet);
                }
                #endregion

                #region Opdateret
                if (aktiv.Opdateret == null)
                {
                    command.Parameters.AddWithValue("@Opdateret", "null");
                }
                else
                {
                    command.Parameters.AddWithValue("@Opdateret", aktiv.Opdateret);
                }
                #endregion
                
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }
        /*

        @AktivTypeID        @Maerke        @Model        @ModelUddyb
        @SerieNr        @Kaldenavn        @AktivstatusID        @Detaljer
        @HarStregkode        @FraKommando        @Privat        @Købt
        @Udskrevet        @Oprettet         @Opdateret 

        
                if (aktiv.AktivTypeID == null)
                {
                    command.Parameters.AddWithValue("@", null);
                }
                else
                {
                    command.Parameters.AddWithValue("@", aktiv);
                }

        AktivTypeID
        Maerke
        Model
        ModelUddyb 
        SerieNr
        Kaldenavn
        AktivstatusID
        Detaljer
        HarStregkode
        FraKommando
        Privat
        Købt
        Udskrevet
        Oprettet
        Opdateret
         */
        public Task DeleteAktivAsync(Aktiv aktiv)
        {
            throw new NotImplementedException();
        }

        public Task<Aktiv> GetAktivById()
        {
            throw new NotImplementedException();
        }

        public Task<List<Aktiv>> GetAktiverAsync()
        {
            throw new NotImplementedException();
        }
    }
}




/*

List<Aktiv> aktiver;
string connectionString;
public IConfiguration Configuration { get; }
public AktivService(IConfiguration configuration)
{
    Configuration = configuration;
    connectionString = Configuration["ConnectionStrings:DefaultConfiguration"];
    aktiver = new List<Aktiv>();
}
*/