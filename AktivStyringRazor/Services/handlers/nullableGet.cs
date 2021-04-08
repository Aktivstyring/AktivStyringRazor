using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services.handlers
{
    public static class nullableGet
    {
        public static int? getNullableInt(int readerNr, SqlDataReader reader)
        {
            int? nullableInt=null;
            if (!reader.IsDBNull(readerNr))
            { nullableInt = reader.GetInt32(readerNr); }
            return nullableInt;
        }
        public static string getNullableString(int readerNr, SqlDataReader reader)
        {
            string nullablestring = null;
            if (!reader.IsDBNull(readerNr))
            { nullablestring = reader.GetString(readerNr); }
            return nullablestring;
        }
        public static DateTime? getNullableDateTime(int readerNr, SqlDataReader reader)
        {
            DateTime? nullabletime = null;
            if (!reader.IsDBNull(readerNr))
            { nullabletime = reader.GetDateTime(readerNr); }
            return nullabletime;

        }
    
        //public static T nullableData<T>(int readerNr, SqlDataReader reader)
        //{
        //    T nullableValue = null;
        //}
             
    }
}
