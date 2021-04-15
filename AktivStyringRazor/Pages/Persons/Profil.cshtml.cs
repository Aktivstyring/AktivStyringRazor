using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using AktivStyringRazor.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AktivStyringRazor.Pages.Persons
{
    public class ProfilModel : PageModel
    {
        private IPersonerService pService;
        private IAktivService aService;
        private AktivudleveringService aUService;
        [BindProperty]
        public Personer ProfilPerson { get; set; }
        public List<Aktivudlevering> AktivUdleveringer { get; set; }
        public List<SelectListItem> Muligheder { get; set; }
        [BindProperty]
        public int AktivId { get; set; }

        public ProfilModel(IPersonerService personService, AktivudleveringService akUdService, IAktivService aktivService)
        {
            this.pService = personService;
            this.aUService = akUdService;
            this.aService = aktivService;
        }
        public async Task OnGetAsync(int id)
        {
            ProfilPerson = await pService.GetPersonerByIdAsync(id);
            AktivUdleveringer = await aUService.GetAktivudleveringerByPersonId(id);

            Muligheder = aService.GetAktiverAsync().Result.Select(a => new SelectListItem { Value = a.AktivID.ToString(), Text = "ID: "+ a.AktivID.ToString() + ", Type: " + a.AktivTypeID.ToString() + ", Serienummer: " + a.SerieNr.ToString()}).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            await aUService.AddUdleveringAsync(ProfilPerson.PersonId, AktivId);
            return RedirectToPage();
        }
    }
}
