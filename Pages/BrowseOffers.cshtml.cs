using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.ViewModels.Offer;

namespace SUDO.Pages
{
    public class BrowseOffersModel : PageModel
    {

        private readonly IOfferService _offerService;

        public OfferListVM Offers {get; set;}

        public BrowseOffersModel(IOfferService offerService) {
            _offerService = offerService;
        }
        public void OnGet()
        {
            Offers = _offerService.GetAllEntries();
        }
    }
}
