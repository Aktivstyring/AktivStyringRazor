using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Persons
{
    public class GetAllPersonsModel : PageModel
    { 
        public List<Models.Personer> Persons { get; set; }
        private IPersonerService personService;

        public GetAllPersonsModel(IPersonerService pService)
        {
            this.personService = pService;
        }

        public async Task OnGetAsync()
        {
            Persons = await personService.GetPersonerAsync();
        }
    }
}
