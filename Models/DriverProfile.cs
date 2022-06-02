using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SUDO.Models
{
    public class DriverProfile
    {
        public int Id {get;set;}
        public ApplicationUser User {get; set;}
        public List<Opine> OpinesAboutUser {get;set;}
        public List<Opine> UserOpines {get;set;}
    }
    
}