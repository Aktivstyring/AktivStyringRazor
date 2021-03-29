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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Personer Person { get; set; }
        private IPersonerService personService;
        public CreateModel(IPersonerService pService)
        {

            this.personService = pService;
        }


        public void OnGet()
        {
            Person = new Personer();
            
                }

        public async Task OnPostAsync()
        {
            await personService.AddPersonerAsync(Person);
        }
    }
}
