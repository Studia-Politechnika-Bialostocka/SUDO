using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.ViewModels.Offer;

namespace SUDO.Pages
{
    public class CreateOfferModel : PageModel
    {

        private readonly IOfferService _offerService;

        [BindProperty]
        public OfferVM Offer {get; set;}

        public CreateOfferModel(IOfferService offerService) {
            _offerService = offerService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                _offerService.AddEntry(Offer);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
