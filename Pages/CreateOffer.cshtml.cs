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
            
            if (ModelState.IsValid) {
                Console.WriteLine("Cost: " + Offer.Cost);
                Offer.DriverId = _userManager.GetUserId(User);;
                _offerService.AddEntry(Offer);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
