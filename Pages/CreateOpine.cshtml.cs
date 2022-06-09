using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.DriverProfiles;
using SUDO.ViewModels.DriverProfiles;
using SUDO.Interfaces.Opines;
using SUDO.Interfaces.Offers;
using SUDO.ViewModels.Opines;
using SUDO.ViewModels.Offer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SUDO.Models;

namespace SUDO.Pages
{
    [Authorize]
    public class CreateOpineModel : PageModel
    {
        private readonly IOfferService _offerService;
        private readonly IDriverProfileService _driverService;

        private readonly IOpinesService _opineService;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public OpineVM Opine {get; set;}

        public OfferManagingVM Offer {get;set;} 

        public CreateOpineModel(IOfferService offerService, UserManager<ApplicationUser> userManager,IOpinesService opineService,IDriverProfileService driverService) {
            _offerService = offerService;
            _userManager = userManager;
            _opineService = opineService;
            _driverService = driverService;
        }
        public void OnGet(int offerId)
        {
            //TODO check if CurrentUserId is in offer
        }
        public IActionResult OnPost(int offerId) {
            Offer = _offerService.GetOfferManageById(offerId);
            Opine.CurrentUserId = _userManager.GetUserId(User);
            Opine.CommentedUserId = Offer.DriverId;
            Console.WriteLine("halo"+Opine.CommentedUserId);
                if (ModelState.IsValid) {
                Console.WriteLine("halo"+offerId);
                _driverService.AddOpine(Opine,_userManager.GetUserId(User),Offer.DriverId);
                return Redirect("/DriverProfileId/"+Offer.DriverId);
            }
            return Page();
        }

    }
}