using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AktivStyringRazor.Services
{
    public class Connection
    {
        protected String connectionString;
        public IConfiguration Configuration { get; }

        public Connection(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:ThomasConfiguration"];
            connectionString = Configuration["ConnectionStrings:ChristianConfiguration"];
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];

        }
    }
}
