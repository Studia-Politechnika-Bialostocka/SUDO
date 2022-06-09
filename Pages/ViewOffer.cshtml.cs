using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.Models;
using SUDO.ViewModels.Offer;
namespace SUDO.Pages
{
    public class ViewOfferModel : PageModel
    {

        private readonly IOfferService _offerService;

        private readonly UserManager<ApplicationUser> _userManager;

        public OfferViewingVM Offer{get; set;}
        public List<PassengerTrip> Passengers{get; set;}

        public string CurrentUserId {get; set;}

        public DateTime CurrentDateTime {get; set;}

        public string Status {get; set;}

        public ViewOfferModel(IOfferService offerService,  UserManager<ApplicationUser> userManager) {
            _offerService = offerService;
            _userManager = userManager;
        }
        public IActionResult OnGet(int offerId)
        {
            CurrentUserId = _userManager.GetUserId(User);
            CurrentDateTime = DateTime.Now;
            Console.WriteLine("CURRENT DATEJKDLSFJSKLDFJSKFDLJL: " + CurrentDateTime);
            Offer = _offerService.GetOfferViewById(offerId);
            Passengers = Offer.PassengerTrips.Where(pt => pt.Accepted).ToList();

            if (!Offer.PassengerTrips.Any(p => p.PassengerId == CurrentUserId))                         Status = "None";
            else if (!Offer.PassengerTrips.Where(p => p.PassengerId == CurrentUserId).First().Accepted) Status = "Pending";
            else                                                                                        Status = "Accepted";

            return Page();
        }

        public IActionResult OnPostLeave(int offerId) {
            _offerService.RemovePassengerApplication(offerId, _userManager.GetUserId(User));
            return Redirect("/ViewOffer/" + offerId);
        }

        public IActionResult OnPostApply(int offerId) {
            _offerService.AddPassenger(offerId, _userManager.GetUserId(User));
            return Redirect("/ViewOffer/" + offerId);
        }
    
    }
}
