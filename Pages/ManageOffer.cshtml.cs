using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.Offers;
using SUDO.Models;
using SUDO.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;

namespace SUDO.Pages
{
    [Authorize]
    public class ManageOfferModel : PageModel
    {
        private readonly IOfferService _offerService;

        private readonly UserManager<ApplicationUser> _userManager;

        public OfferManagingVM Offer{get; set;}
        public List<PassengerTrip> PendingApplications{get; set;}
        public List <PassengerTrip> AcceptedApplications {get; set;}

        public ManageOfferModel(IOfferService offerService,  UserManager<ApplicationUser> userManager) {
            _offerService = offerService;
            _userManager = userManager;
        }
        public IActionResult OnGet(int offerId)
        {
            Offer = _offerService.GetOfferManageById(offerId);
            if (_userManager.GetUserId(User) != Offer.DriverId)
                return RedirectToPage("./BrowseOffers");

            PendingApplications = Offer.PassengerTrips.Where(pt => !pt.Accepted).ToList();
            AcceptedApplications = Offer.PassengerTrips.Where(pt => pt.Accepted).ToList();
            return Page();
        }

        public IActionResult OnPostAccept(int OfferId, string PassengerId) {
            _offerService.SetPassengerStatus(OfferId, PassengerId, true);
            return Redirect("/ManageOffer/" + OfferId);
        }

        public IActionResult OnPostMoveToPending(int OfferId, string PassengerId) {
            _offerService.SetPassengerStatus(OfferId, PassengerId, false);
            return Redirect("/ManageOffer/" + OfferId);
        }

        public IActionResult OnPostRemove(int OfferId, string PassengerId) {
            _offerService.RemovePassengerApplication(OfferId, PassengerId);
            return Redirect("/ManageOffer/" + OfferId);
        }

        public IActionResult OnPostDelete(int OfferId) {
            _offerService.DeleteOffer(OfferId);
            return RedirectToPage("./BrowseOffers");
        }
    }
}
