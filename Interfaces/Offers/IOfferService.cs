using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.ViewModels.Offer;

namespace SUDO.Interfaces.Offers
{
    public interface IOfferService
    {
        void AddEntry(OfferVM entry);

        void SetPassengerStatus(int OfferId, string PassengerId, bool status);

        void RemovePassengerApplication(int OfferId, string PassengerId);

        OfferListVM GetAllEntries();

        OfferManagingVM GetOfferById(int id);

        void AddPassenger(int offerId, string userId);

        
    }
}