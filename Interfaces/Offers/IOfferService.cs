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

        OfferListVM GetAllEntries();

        void AddPassenger(int offerId, string userId);

    
    }
}