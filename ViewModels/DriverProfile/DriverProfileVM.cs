using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SUDO.Models;

namespace SUDO.ViewModels.DriverProfiles
{
    public class DriverProfileVM
    {
        public int Id {get;set;}

        public string? UserId {get;set;}
        public List<Opine>? OpinesAboutUser {get;set;}
        public List<Opine>? UserOpines {get;set;}
    }
}