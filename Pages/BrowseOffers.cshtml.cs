using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.ViewModels.Offer;
using Microsoft.AspNetCore.Identity;
using SUDO.Models;


namespace SUDO.Pages
{
    public class BrowseOffersModel : PageModel
    {

        private readonly IOfferService _offerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OfferListVM Offers {get; set;}

        public BrowseOffersModel(IOfferService offerService,  UserManager<ApplicationUser> userManager) {
            _offerService = offerService;
            _userManager = userManager;
        }
        public void OnGet()
        {
            Offers = _offerService.GetAllEntries();
        }

        public IActionResult OnPostApply(int OfferId) {
            _offerService.AddPassenger(OfferId, _userManager.GetUserId(User));
            return RedirectToPage("./BrowseOffers");
        }
    }
}
