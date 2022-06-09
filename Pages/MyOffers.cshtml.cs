using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SUDO.ViewModels.Offer;

namespace SUDO.Pages
{
    [Authorize]
    public class MyOffersModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOfferService _offerService;
        
        public OfferListVM Offers;
        public MyOffersModel(UserManager<ApplicationUser> userManager, IOfferService offerService) {
            _userManager = userManager;
            _offerService = offerService;
        }
        public void OnGet()
        {
            Offers = _offerService.GetOffersForDriver(_userManager.GetUserId(User));
        }
    }
}
