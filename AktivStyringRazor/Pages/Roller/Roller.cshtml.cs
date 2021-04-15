using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Roller
{
    public class RollerModel : PageModel
    {

        public List<Models.Roller> Roller { get; set; }
        private IRollerService rollerService;

        public RollerModel(IRollerService rolService)
        {
            this.rollerService = rolService;
        }
        
        public async Task OnGetAsync()
        {
            Roller = await rollerService.GetRollerAsync();
        }
    }
}
