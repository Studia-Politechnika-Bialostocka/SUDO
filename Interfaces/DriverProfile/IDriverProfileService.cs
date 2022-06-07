using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.ViewModels.DriverProfiles;
using SUDO.Models;
using SUDO.ViewModels.Opines;

namespace SUDO.Interfaces.DriverProfiles
{
    public interface IDriverProfileService
    {
        void AddEntry(DriverProfileVM entry);
        DriverProfileListVM GetAllEntries();
        DriverProfileVM GetDriverProfileByCurrentUser(string id);
        void AddOpine(OpineVM opine, string currentUserId, string commentedUserId);
  
    }
}