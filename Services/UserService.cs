using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.Users;
using SUDO.ViewModels.User;
using SUDO.ViewModels.Offer;
using SUDO.Models;

namespace SUDO.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo) {
            _userRepo = userRepo;
        }

        public UserWithTripsVM GetUserWithTrips(string userId) {
            ApplicationUser user = _userRepo.GetEntryById(userId);

            List<Offer> Pending = new List<Offer>();
            List<Offer> Accepted = new List<Offer>();
            List<Offer> Past = new List<Offer>();

            foreach(var pt in user.PassengerTrips.Where(pt => !pt.Accepted))
                Pending.Add(pt.Trip);
            
            foreach(var pt in user.PassengerTrips.Where(pt => pt.Accepted && pt.Trip.Arrival > DateTime.Now))
                Accepted.Add(pt.Trip);

            foreach(var pt in user.PassengerTrips.Where(pt => pt.Accepted && pt.Trip.Arrival <= DateTime.Now))
                Past.Add(pt.Trip);

            var uVM = new UserWithTripsVM{
                Id = user.Id,
                PendingTrips = Pending,
                AcceptedTrips = Accepted,
                PastTrips = Past
            };

            return uVM;
        }
    }
}