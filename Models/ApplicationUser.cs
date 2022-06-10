using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SUDO.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Offer>? Offers {get; set;}

        public virtual ICollection<PassengerTrip> PassengerTrips {get; set;}
    }
}