using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Services.Interfaces;
using AktivStyringRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Persons
{
    public class DeleteModel : PageModel
    {
        public Personer Person { get; set; }
        private int personId { get; set; }
        private IPersonerService personService;

        public DeleteModel(IPersonerService pService)
        {
            this.personService = pService;
        }

        public async Task OnGetAsync(int id)
        {
            Person = await personService.GetPersonerByIdAsync(id);
            personId = id;
        }

        public async Task OnPostAsync()
        {
            await personService.DeletePersonerAsync(personId);
            int a = 1;
        }
    }
}
