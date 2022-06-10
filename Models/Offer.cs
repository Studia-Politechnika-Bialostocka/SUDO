using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SUDO.Models
{
    public class Offer
    {
        public int Id {get; set;}

        public string? DriverId {get; set;}
        public virtual ApplicationUser? Driver {get; set;}

        public int MaxPassengerCount {get; set;}

        public virtual ICollection<PassengerTrip>? PassengerTrips {get; set;}

        public bool NonSmoking {get; set;}

        public double Cost {get; set;}

        public String Destination {get; set;}

        public String? Stops {get; set;}

        public DateTime Departure {get; set;}
        public DateTime Arrival {get; set;}
        
    }
}