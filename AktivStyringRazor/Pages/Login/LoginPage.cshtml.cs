using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.Login
{
    public class LoginPageModel : PageModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void OnGetAsync()
        {

        }

        public async void onPostAsync()
        {

        }
    }
}
