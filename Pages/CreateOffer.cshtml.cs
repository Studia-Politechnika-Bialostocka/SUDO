using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.ViewModels.Offer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SUDO.Models;


namespace SUDO.Pages
{
    [Authorize]
    public class CreateOfferModel : PageModel
    {

        private readonly IOfferService _offerService;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public OfferVM Offer {get; set;}

        public string CurrentUserId {get; set;}

        public CreateOfferModel(IOfferService offerService, UserManager<ApplicationUser> userManager) {
            _offerService = offerService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost() {
            if (Offer.Departure < DateTime.Now) 
                ModelState.AddModelError("", "Departure cannot be set to a past date or time");
            if (Offer.Arrival < Offer.Departure) 
                ModelState.AddModelError("", "Arrival can not be earlier than departure");
            
            if (ModelState.IsValid) {
                Offer.DriverId = _userManager.GetUserId(User);;
                _offerService.AddEntry(Offer);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
