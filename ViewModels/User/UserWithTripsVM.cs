using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Models;

namespace SUDO.ViewModels.User
{
    public class UserWithTripsVM
    {
        public string? Id {get; set;}

        public string Username {get; set;}

        public List<SUDO.Models.Offer> PendingTrips {get; set;}

        public List<SUDO.Models.Offer> AcceptedTrips {get; set;}

        public List<SUDO.Models.Offer> PastTrips {get; set;}
    }
}