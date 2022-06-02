using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Models;
using SUDO.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace SUDO.Repositories
{
    public class DriverProfileRepository : IDriverProfileRepository
    {
        private readonly SUDOIdentityDbContext _context;

        public DriverProfileRepository(SUDOIdentityDbContext context) {
            _context = context;
        }
        public void AddEntry(DriverProfile entry)
        {
            _context.DriverProfiles.Add(entry);
            _context.SaveChanges();
        }

        public IQueryable<DriverProfile> GetAllEntries()
        {
            return _context.DriverProfiles;
        }

        public DriverProfile GetDriverProfileByUser(string id)
        {
            return  _context.DriverProfiles.Include(m=>m.User).Where(x=>x.User.Id == id).First();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}