using System.ComponentModel.DataAnnotations;
using SUDO.Models;

namespace SUDO.ViewModels.Offer
{
    public class OfferViewingVM
    {
        public int? Id {get; set;}

        public string Destination {get; set;}

        public List<string>? Stops {get; set;}

        public string? DriverName {get; set;}

        public string DriverId {get; set;}

        public int MaxPassengerCount {get; set;}

        public bool NonSmoking {get; set;}

        public double Cost {get; set;}

        public DateTime Departure{get; set;}

        public DateTime Arrival{get; set;}
        public int PassengerCount {get; set;}
        public bool IsFull {get; set;}

        public ICollection<PassengerTrip>? PassengerTrips {get; set;}

    }
}