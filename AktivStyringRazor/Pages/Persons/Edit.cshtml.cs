using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Persons
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public Personer Person { get; set; }
        private IPersonerService personService;

        public 
            EditModel(IPersonerService pService)
        {
            this.personService = pService;
        }

        public async Task OnGetAsync(int id)
        {
            Person = await personService.GetPersonerByIdAsync(id);
        }

        public async Task OnPostAsync()
        {
            await personService.UpdatePersonAsync(Person);
        }
    }
}
