﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Models
{
    public class Aktiv
    {
        public int AktivID { get; set; }
        public int AktivTypeID { get; set; }
        public string Maerke { get; set; }
        public string Model { get; set; }
        public string ModelUddyb { get; set; }
        public string SerieNr { get; set; }
        public string Kaldenavn { get; set; }
        public int? AktivstatusID { get; set; }
        public string Detaljer { get; set; }
        public int? HarStregkode { get; set; }
        public int? FraKommando { get; set; }
        public int? Privat { get; set; }
        public DateTime Købt { get; set; }
        public DateTime Udskrevet { get; set; }
        public DateTime Oprettet { get; set; }
        public DateTime Opdateret { get; set; }

        public Aktiv()
        {

        }
        public Aktiv(int aktivID, int aktivTypeId, string maerke, string model, string modelUddyb, string serieNr, string kaldenavn, int? aktivstatusId, string detaljer, int? harStregkode, int? fraKommando, int? privat, DateTime købt, DateTime udskrevet, DateTime oprettet, DateTime opdateret)
        {
            AktivID = aktivID;
            AktivTypeID = aktivTypeId;
            Maerke = maerke;
            Model = model;
            ModelUddyb = modelUddyb;
            SerieNr = serieNr;
            Kaldenavn = kaldenavn;
            AktivstatusID = aktivstatusId;
            Detaljer = detaljer;
            HarStregkode = HarStregkode;
            FraKommando = fraKommando;
            Privat = privat;
            Købt = købt;
            Udskrevet =udskrevet;
            Oprettet = oprettet;
            Opdateret = opdateret;
        }
    }
}
