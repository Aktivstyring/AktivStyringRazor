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
        public string ErrorMessage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginPageModel(LoginService service)
        {
            this.lService = service;
        }

        public void OnGetAsync()
        {

        }

        public async void onPostAsync()
        {
            if(await lService.LogInAsync(Password,Email))
            { RedirectToPage(); }
            else { ErrorMessage = "Log-in fejlede"; }
        }
    }
}
