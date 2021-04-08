using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Aktiver
{
    public class AktiverModel : PageModel
    {
        public List<Models.Aktiv> Aktiver { get; set; }
        private IAktivService aktivService;

        public AktiverModel(IAktivService aktService)
        {
            this.aktivService = aktService;
        }
        
        public async Task OnGetAsync()
        {
            Aktiver = await aktivService.GetAktiverAsync();
        }
    }
}
