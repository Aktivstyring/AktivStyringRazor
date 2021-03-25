using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Placeringer
{
    public class PlaceringerModel : PageModel
    {
        public List<Models.Placeringer> Placeringer { get; set; }
        private IPlaceringerService placeringerService;

        public PlaceringerModel(IPlaceringerService pService)
        {
            this.placeringerService = pService;
        }

        public async Task OnGetAsync()
        {
            Placeringer = await placeringerService.GetPlaceringerAsync();
        }

    }
}
