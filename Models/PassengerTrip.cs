using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUDO.Models
{
    public class PassengerTrip
    {
        public string? PassengerId {get; set;}
        public virtual ApplicationUser Passenger {get; set;}

        public int? TripId {get; set;}
        public virtual Offer Trip {get; set;}

        public bool Accepted {get; set;}
    }
}