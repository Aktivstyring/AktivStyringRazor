using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services
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


        AktivTypeID        Maerke        Model        ModelUddyb 
        SerieNr        Kaldenavn        AktivstatusID        Detaljer
        HarStregkode        FraKommando        Privat        Købt
        Udskrevet        Oprettet        Opdateret
         */
        public async Task<Aktiv> DeleteAktivAsync(int aktivId)
        {
            Aktiv aktiv = await GetAktivByIdAsync(aktivId);
            if (aktiv == null) { return null; }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryDelete, connection);
                command.Parameters.AddWithValue("@ID", aktivId);
                await command.Connection.OpenAsync();
                int noOfRows = await command.ExecuteNonQueryAsync();
                if (noOfRows == 1) { return aktiv; }
                return null;
            }
        }

        public async Task<Aktiv> GetAktivByIdAsync(int aktivId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryById, connection);
                command.Parameters.AddWithValue("@ID", aktivId);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int aktiv = reader.GetInt32(0);

                    int aktivTypeID = reader.GetInt32(1);

                    string maerke;
                    if (reader.IsDBNull(2)) { maerke = "null"; }
                    else { maerke = reader.GetString(2); }

                    string model;
                    if (reader.IsDBNull(3)) { model = "null"; }
                    else { model = reader.GetString(3); }

                    string modelUddyb;
                    if (reader.IsDBNull(4)) { modelUddyb = "null"; }
                    else { modelUddyb = reader.GetString(4); }

                    string serieNr;
                    if (reader.IsDBNull(5)) { serieNr = "null"; }
                    else { serieNr = reader.GetString(5); }

                    string kaldenavn;
                    if (reader.IsDBNull(6)) { kaldenavn = "null"; }
                    else { kaldenavn = reader.GetString(6); }

                    int? aktivstatusID;
                    if (reader.IsDBNull(7)) { aktivstatusID = null; }
                    else { aktivstatusID = reader.GetInt32(7); }

                    string detaljer;
                    if (reader.IsDBNull(8)) { detaljer = "null"; }
                    else { detaljer = reader.GetString(8); }

                    int? harStregKode;
                    if (reader.IsDBNull(9)) { harStregKode = null; }
                    else { harStregKode = reader.GetInt32(9); }

                    int? fraKommando;
                    if (reader.IsDBNull(10)) { fraKommando = null; }
                    else { fraKommando = reader.GetInt32(10); }

                    int? privat;
                    if (reader.IsDBNull(11)) { privat = null; }
                    else { privat = reader.GetInt32(11); }

                    DateTime købt;
                    //if (reader.IsDBNull(12)) { købt = null; }
                    //else 
                    { købt = reader.GetDateTime(12); }

                    DateTime udskrevet;
                    //if (reader.IsDBNull(13)) { købt = null; }
                    //else 
                    { udskrevet = reader.GetDateTime(13); }

                    DateTime oprettet;
                    //if (reader.IsDBNull(14)) { købt = null; }
                    //else 
                    { oprettet = reader.GetDateTime(14); }

                    DateTime opdateret;
                    //if (reader.IsDBNull(15)) { købt = null; }
                    //else 
                    { opdateret = reader.GetDateTime(15); }

                    Aktiv aktiver = new Aktiv(aktiv, aktivTypeID, maerke, model, modelUddyb, serieNr, kaldenavn, aktivstatusID, detaljer, harStregKode, fraKommando, privat, købt, udskrevet, oprettet, opdateret);
                    return aktiver;
                }
                return null;
            }
        }

        public async Task<List<Aktiv>> GetAktiverAsync()
        {
            List<Aktiv> aktiver = new List<Aktiv>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                await command.Connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    int aktiv = reader.GetInt32(0);

                    int aktivTypeID = reader.GetInt32(1);

                    string maerke;
                    if (reader.IsDBNull(2)) { maerke = "null"; }
                    else { maerke = reader.GetString(2); }

                    string model;
                    if (reader.IsDBNull(3)) { model = "null"; }
                    else { model = reader.GetString(3); }

                    string modelUddyb;
                    if (reader.IsDBNull(4)) { modelUddyb = "null"; }
                    else { modelUddyb = reader.GetString(4); }

                    string serieNr;
                    if (reader.IsDBNull(5)) { serieNr = "null"; }
                    else { serieNr = reader.GetString(5); }

                    string kaldenavn;
                    if (reader.IsDBNull(6)) { kaldenavn = "null"; }
                    else { kaldenavn = reader.GetString(6); }

                    int? aktivstatusID;
                    if (reader.IsDBNull(7)) { aktivstatusID = null; }
                    else { aktivstatusID = reader.GetInt32(7); }

                    string detaljer;
                    if (reader.IsDBNull(8)) { detaljer = "null"; }
                    else { detaljer = reader.GetString(8); }

                    int? harStregKode;
                    if (reader.IsDBNull(9)) { harStregKode = null; }
                    else { harStregKode = reader.GetInt32(9); }

                    int? fraKommando;
                    if (reader.IsDBNull(10)) { fraKommando = null; }
                    else { fraKommando = reader.GetInt32(10); }

                    int? privat;
                    if (reader.IsDBNull(11)) { privat = null; }
                    else { privat = reader.GetInt32(11); }

                    DateTime købt;
                    //if (reader.IsDBNull(12)) { købt = null; }
                    //else 
                    { købt = reader.GetDateTime(12); }

                    DateTime udskrevet;
                    //if (reader.IsDBNull(13)) { købt = null; }
                    //else 
                    { udskrevet = reader.GetDateTime(13); }

                    DateTime oprettet;
                    //if (reader.IsDBNull(14)) { købt = null; }
                    //else 
                    { oprettet = reader.GetDateTime(14); }

                    DateTime opdateret;
                    //if (reader.IsDBNull(15)) { købt = null; }
                    //else 
                    { opdateret = reader.GetDateTime(15); }

                    Aktiv aktiverlist = new Aktiv(aktiv, aktivTypeID, maerke, model, modelUddyb, serieNr, kaldenavn, aktivstatusID, detaljer, harStregKode, fraKommando, privat, købt, udskrevet, oprettet, opdateret);
                    aktiver.Add(aktiverlist);
                }
            }

            return aktiver;
        }
    }
}
