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

        public OfferViewingVM Offer {get;set;} 

        public CreateOpineModel(IOfferService offerService, UserManager<ApplicationUser> userManager,IOpinesService opineService,IDriverProfileService driverService) {
            _offerService = offerService;
            _userManager = userManager;
            _opineService = opineService;
            _driverService = driverService;
        }
        public IActionResult OnGet(int offerId)
        {
            Offer = _offerService.GetOfferViewById(offerId);
            if (!Offer.PassengerTrips.Any(pt => pt.PassengerId == _userManager.GetUserId(User)))
                return RedirectToPage("./BrowseOffers");

            return Page();
        }
        public IActionResult OnPost(int offerId) {
            Offer = _offerService.GetOfferViewById(offerId);
            Opine.CurrentUserId = _userManager.GetUserId(User);
            Opine.CommentedUserId = Offer.DriverId;
            if (ModelState.IsValid) {
                Console.WriteLine("halo"+offerId);
                _driverService.AddOpine(Opine,_userManager.GetUserId(User),Offer.DriverId);
                return Redirect("/DriverProfileId/"+Offer.DriverId);
            }
            return Page();
        }

    }
}