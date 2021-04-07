using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using AktivStyringRazor.Services;

namespace AktivStyringRazor.Pages.Persons
{
    public class ProfilModel : PageModel
    {
        private IPersonerService pService;
        private AktivudleveringService aUService;
        public Personer Person { get; set; }
        public List<Aktivudlevering> AktivUdleveringer { get; set; }

        public ProfilModel(IPersonerService personService, AktivudleveringService akUdService)
        {
            this.pService = personService;
            this.aUService = akUdService;
        }
        public async Task OnGetAsync(int id)
        {
            Person = await pService.GetPersonerByIdAsync(id);
            AktivUdleveringer = await aUService.GetAktivudleveringerByPersonId(id);

        }
    }
}
