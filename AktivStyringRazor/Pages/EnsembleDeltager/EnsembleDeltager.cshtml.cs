using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.EnsembleDeltager
{
    public class EnsembleDeltagerModel : PageModel
    {
        public List<Models.EnsembleDeltager> EnsDeltager { get; set; }
        private IEnsembleDeltagerService ensDeltagerService;

        public EnsembleDeltagerModel(IEnsembleDeltagerService ensDelService)
        {
            this.ensDeltagerService = ensDelService;
        }
        
        public async Task OnGetAsync()
        {
            EnsDeltager = await ensDeltagerService.GetEnsembleDeltagerAsync();
        }
    }
}
