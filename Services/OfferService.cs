using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Interfaces.Offers;
using SUDO.Interfaces.Users;
using SUDO.ViewModels.Offer;
using SUDO.Models;

namespace SUDO.Services
{
    public class OfferService : IOfferService
    {

        private readonly IOfferRepository _offerRepo;

        public OfferService(IOfferRepository offerRepo) {
            _offerRepo = offerRepo;
        }
        public void AddEntry(OfferVM entry) {
            Offer offer = new Offer() {
                DriverId = entry.DriverId,
                Destination = entry.Destination,
                MaxPassengerCount = entry.MaxPassengerCount,
                NonSmoking = entry.NonSmoking,
                Cost = entry.Cost
            };

            _offerRepo.AddEntry(offer);
        }

        public OfferListVM GetAllEntries() {
            var offers = _offerRepo.GetAllEntries();
            OfferListVM result = new OfferListVM();

            result.Offers = new List<OfferVM>();
            foreach(var offer in offers) {
                var oVM = new OfferVM() {
                    Id = offer.Id,
                    Destination = offer.Destination,
                    DriverName = offer.Driver.UserName,
                    MaxPassengerCount = offer.MaxPassengerCount,
                    NonSmoking = offer.NonSmoking,
                    Cost = offer.Cost,
                    IsFull = false //TODO: have to implement a way to track how many spots are taken up either db field or query to linked customers
                };
                result.Offers.Add(oVM);
            }

            result.Count = result.Offers.Count;
            return result;
        }
    }
}