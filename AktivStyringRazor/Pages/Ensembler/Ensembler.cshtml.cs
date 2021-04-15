using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Ensembler
{
    public class EnsemblerModel : PageModel
    {
        public List<Models.Ensemble>Ensembler { get; set; }
        private IEnsemblerService ensemblerService;

        public EnsemblerModel(IEnsemblerService ensService)
        {
            this.ensemblerService = ensService;
        }

        public async Task OnGetAsync()
        {
            Ensembler = await ensemblerService.GetEnsembleAsync();
        }
    }
}
