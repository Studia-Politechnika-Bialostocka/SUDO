using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Models;

namespace SUDO.ViewModels.Offer
{
    public class OfferManagingVM
    {
        public int? Id {get; set;}

        public string DriverId {get; set;}
        public string Destination {get; set;}
        public ICollection<PassengerTrip>? PassengerTrips {get; set;}

        public int MaxPassengerCount {get; set;}
        public int PassengerCount {get; set;}
        public bool IsFull {get; set;}

    }
}