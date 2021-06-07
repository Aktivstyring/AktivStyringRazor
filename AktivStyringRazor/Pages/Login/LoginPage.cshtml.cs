using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AktivStyringRazor.Services;

namespace AktivStyringRazor.Pages.Login
{
    public class LoginPageModel : PageModel
    {
        private LoginService lService;
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Keyphrase { get; set; }

        public LoginPageModel(LoginService service)
        {
            this.lService = service;
        }

        public void OnGetAsync()
        {

        }

        public async Task OnPostAsync()
        {
            if(await lService.LogInAsync(Keyphrase,Email))
            { RedirectToPage(); }
            else { ErrorMessage = "Forkert e-mail eller password"; }
        }
    }
}
