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

        public virtual IdentityUser Driver {get; set;}

        public int MaxPassengerCount {get; set;}

        public bool NonSmoking {get; set;}

        public String Destination {get; set;}
        //TODO: Define destination and possible stops along the way. Define locations as objects or strings?????
    }
}