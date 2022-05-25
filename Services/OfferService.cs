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
                int passengerCount = offer.PassengerTrips.Count;

                var oVM = new OfferVM() {
                    Id = offer.Id,
                    Destination = offer.Destination,
                    DriverName = offer.Driver.UserName,
                    DriverId = offer.DriverId,
                    MaxPassengerCount = offer.MaxPassengerCount,
                    NonSmoking = offer.NonSmoking,
                    Cost = offer.Cost,
                    PassengerCount = passengerCount,
                    IsFull = passengerCount >= offer.MaxPassengerCount
                };
                result.Offers.Add(oVM);
            }

            result.Count = result.Offers.Count;
            return result;
        }

        public void AddPassenger(int offerId, string userId) {
            Console.WriteLine("userID: " + userId);
            Offer offer = _offerRepo.GetOfferById(offerId);
            if (offer.DriverId == userId) 
                return; //TODO: throw an exception or have this method return a status code which then causes redirect to an error page

            if (offer.PassengerTrips.Any(p => p.PassengerId == userId))
                return;//TODO: see above

            //TODO: Add check if offer date is colliding with a trip that the user is already signed up for

            PassengerTrip pt = new PassengerTrip() {
                TripId = offerId,
                PassengerId = userId
            };

            offer.PassengerTrips.Add(pt);
            _offerRepo.SaveChanges();
        }
    }
}