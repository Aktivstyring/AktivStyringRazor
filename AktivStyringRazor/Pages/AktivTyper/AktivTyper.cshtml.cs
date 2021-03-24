using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.AktivTyper
{
    public class AktivTyperModel : PageModel
    {
        public List<Models.AktivTyper> AktivTypes { get; set; }
        private IAktivTyperService aktivTyperService;

        public AktivTyperModel(IAktivTyperService aService)
        {
            this.aktivTyperService = aService;
        }

        public async Task OnGetAsync()
        {
            AktivTypes = await aktivTyperService.GetAktivtyperAsync();
        }
    }
}
