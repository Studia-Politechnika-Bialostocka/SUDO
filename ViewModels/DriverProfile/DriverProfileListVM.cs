using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUDO.ViewModels.DriverProfiles
{
    public class DriverProfileListVM
    {
        public List<DriverProfileVM> Users {get;set;}
        public int Count {get;set;}
    }
}