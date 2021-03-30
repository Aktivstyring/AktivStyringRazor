using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages
{
    public class LageroptællingModel : PageModel
    {
        public List<Models.Lageroptælling> Lageroptællinger { get; set; }
        private ILageroptællingService optællingService;

        public LageroptællingModel(ILageroptællingService optService)
        {
            this.optællingService = optService;
        }

        public async Task OnGetAsync()
        {
            Lageroptællinger = await optællingService.GetLageroptællingAsync();
        }
    }
}
