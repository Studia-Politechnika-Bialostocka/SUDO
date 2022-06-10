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
        public virtual ApplicationUser User {get; set;}
        public virtual List<Opine>? OpinesAboutUser {get;set;}
        public virtual List<Opine>? UserOpines {get;set;}
    }
    
}