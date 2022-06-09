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
        private readonly IUserRepository _userRepo;

        public OfferService(IOfferRepository offerRepo, IUserRepository userRepo) {
            _offerRepo = offerRepo;
            _userRepo = userRepo;
        }
        public void AddEntry(OfferVM entry) {
            Offer offer = new Offer() {
                DriverId = entry.DriverId,
                Destination = entry.Destination,
                Stops = entry.Stops,
                MaxPassengerCount = entry.MaxPassengerCount,
                NonSmoking = entry.NonSmoking,
                Cost = entry.Cost,
                Departure = entry.Departure,
                Arrival = entry.Arrival
            };

            _offerRepo.AddEntry(offer);
        }

        public void DeleteOffer(int offerId) {
            Offer offer = _offerRepo.GetOfferById(offerId);
            offer.PassengerTrips = new List<PassengerTrip>();
            _offerRepo.SaveChanges();
            _offerRepo.DeleteEntry(offer);
        }

        public OfferListVM GetAllEntries() {
            var offers = _offerRepo.GetAllEntries();
            OfferListVM result = new OfferListVM();

            result.Offers = new List<OfferVM>();
            foreach(var offer in offers) {
                int passengerCount = offer.PassengerTrips.Where(pt => pt.Accepted == true).Count();

                var oVM = new OfferVM() {
                    Id = offer.Id,
                    Destination = offer.Destination,
                    Stops = offer.Stops,
                    DriverName = offer.Driver.UserName,
                    DriverId = offer.DriverId,
                    MaxPassengerCount = offer.MaxPassengerCount,
                    NonSmoking = offer.NonSmoking,
                    Cost = offer.Cost,
                    PassengerCount = passengerCount,
                    IsFull = passengerCount >= offer.MaxPassengerCount,
                    Departure = offer.Departure,
                    Arrival = offer.Arrival
                };
                result.Offers.Add(oVM);
            }

            result.Count = result.Offers.Count;
            return result;
        }

        public OfferListVM GetOffersForDriver(string userId) {
            var offers = _offerRepo.GetEntriesForDriver(userId);
            OfferListVM result = new OfferListVM();

            result.Offers = new List<OfferVM>();
            foreach(var offer in offers) {
                int passengerCount = offer.PassengerTrips.Where(pt => pt.Accepted == true).Count();
            
                var oVM = new OfferVM() {
                    Id = offer.Id,
                    DriverName = offer.Driver.UserName,
                    Destination = offer.Destination,
                    PassengerCount = passengerCount,
                    MaxPassengerCount = offer.MaxPassengerCount,
                    IsFull = passengerCount >= offer.MaxPassengerCount,
                    NonSmoking = offer.NonSmoking,
                    Stops = offer.Stops,
                    Departure = offer.Departure,
                    Arrival = offer.Arrival,
                    Cost = offer.Cost
                };
                result.Offers.Add(oVM);
            }

            result.Count = result.Offers.Count;
            return result;
        }

        public OfferManagingVM GetOfferManageById(int id) {
            Offer offer = _offerRepo.GetOfferById(id);

            int passengerCount = offer.PassengerTrips.Where(pt => pt.Accepted == true).Count();
            Console.WriteLine("Passenger Count: " + offer.PassengerTrips.Count);

            var oVM = new OfferManagingVM() {
                Id = offer.Id,
                Destination = offer.Destination,
                DriverId = offer.DriverId,
                PassengerCount = passengerCount,
                MaxPassengerCount = offer.MaxPassengerCount,
                PassengerTrips = offer.PassengerTrips,
                IsFull = passengerCount >= offer.MaxPassengerCount,
            };
            return oVM;
        }

        public OfferViewingVM GetOfferViewById(int id) {
            Offer offer = _offerRepo.GetOfferById(id);

            int passengerCount = offer.PassengerTrips.Where(pt => pt.Accepted == true).Count();
            
            var oVM = new OfferViewingVM() {
                Id = offer.Id,
                DriverId = offer.DriverId,
                DriverName = offer.Driver.UserName,
                Destination = offer.Destination,
                PassengerCount = passengerCount,
                MaxPassengerCount = offer.MaxPassengerCount,
                PassengerTrips = offer.PassengerTrips,
                IsFull = passengerCount >= offer.MaxPassengerCount,
                NonSmoking = offer.NonSmoking,
                Stops = offer.Stops.Split(",").ToList(),
                Departure = offer.Departure,
                Arrival = offer.Arrival,
                Cost = offer.Cost
            };
            return oVM;
        }

        public void AddPassenger(int offerId, string userId) {
            Offer offer = _offerRepo.GetOfferById(offerId);
            ApplicationUser user = _userRepo.GetEntryById(userId);

            if (offer.DriverId == userId) 
                return; //TODO: throw an exception or have this method return a status code which then causes redirect to an error page

            if (offer.PassengerTrips.Any(p => p.PassengerId == userId))
                return;//TODO: see above

            if (user.PassengerTrips.Any(p => p.Trip.Departure <= offer.Arrival && p.Trip.Arrival >= offer.Departure))
                return; //see above


            PassengerTrip pt = new PassengerTrip() {
                TripId = offerId,
                PassengerId = userId
            };

            offer.PassengerTrips.Add(pt);
            _offerRepo.SaveChanges();
        }
        
        public void SetPassengerStatus(int OfferId, string PassengerId, bool status) {
            Offer offer = _offerRepo.GetOfferById(OfferId);
            PassengerTrip pt = offer.PassengerTrips.Where(pt => pt.PassengerId == PassengerId).First();

            pt.Accepted = status;
            _offerRepo.SaveChanges();
        }

        public void RemovePassengerApplication(int OfferId, string PassengerId) {
            Offer offer = _offerRepo.GetOfferById(OfferId);
            PassengerTrip pt = offer.PassengerTrips.Where(pt => pt.PassengerId == PassengerId).First();

            offer.PassengerTrips.Remove(pt);
            _offerRepo.SaveChanges();
        }
    }
}