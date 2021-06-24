using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;
using AktivStyringRazor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AktivStyringRazor.Pages.StemmeBøger
{
    public class StemmeBøgerModel : PageModel
    {

        public List<Models.StemmeBogInJoLi> StemmeBogInJoLis { get; set; }
        private IStemmeBogService stemmeBogService;

        public StemmeBøgerModel(IStemmeBogService steBLService)
        {
            this.stemmeBogService = steBLService;
        }


        public async Task OnGetAsync()
        {
            StemmeBogInJoLis = await stemmeBogService.GetStemmeBogInJoLiAsync();
        }
    }
}







//private IStemmeBogTypeService sBTypeService;
//private IStemmeBogStatusService sBStatusService;
//private IPersonerService persService;
//private IAktivTyperService aTypService;
//private IStemmeNummerService sNrService;
//private IStemmeBogService sBogService;
//[BindProperty]
//public Personer StemmeBogPerson { get; set; }
//public List<StemmeBogType> BogTypeList { get; set; }
//public List<StemmeBogStatus> BogStatusList { get; set; }
//public List<Models.AktivTyper> AktivTyperList { get; set; }
//public List<StemmeNummer> StemmeNummerList { get; set; }
//public List<Models.StemmeBog> StemmeBoger { get; set; }
//[BindProperty]
//public int StemmeBogID { get; set; }


//public StemmeBøgerModel(IStemmeBogService steBogService, IStemmeBogTypeService sBogTypeService, IStemmeBogStatusService sBogStatusService, IPersonerService personService, IAktivTyperService aTyperService, IStemmeNummerService stemmeNrService, IStemmeBogService stemBogService)
//{
//this.sBogService = steBogService;
//this.sBTypeService = sBogTypeService;
//this.sBStatusService = sBogStatusService;
//this.persService = personService;
//this.aTypService = aTyperService;
//this.sNrService = stemmeNrService;

//}


//public async Task OnGetAsync()
//{
//StemmeBoger = await sBogService.GetStemmeBogAsync();
//}
