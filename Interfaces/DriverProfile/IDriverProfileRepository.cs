using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Models;

namespace SUDO.Interfaces.DriverProfiles
{
    public interface IDriverProfileRepository
    {
        void AddEntry(DriverProfile entry);
        IQueryable<DriverProfile> GetAllEntries();

        DriverProfile GetDriverProfileByUser(string id);
        void SaveChanges();
  
    }
}