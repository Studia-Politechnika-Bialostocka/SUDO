using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.Offers;
using SUDO.Models;
using SUDO.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace SUDO.Repositories
{
    public class OfferRepository : IOfferRepository
    {

        private readonly SUDOIdentityDbContext _context;

        public OfferRepository(SUDOIdentityDbContext context) {
            _context = context;
        }


        public void AddEntry(Offer entry) {
            _context.Offer.Add(entry);
            _context.SaveChanges();
        }
        public IQueryable<Offer> GetAllEntries() {
            return _context.Offer.Include(o => o.Driver).Include(o => o.PassengerTrips);
        }

        public Offer GetOfferById(int id) {
            return _context.Offer.Include(o => o.PassengerTrips).First(o => o.Id == id);
        }

        public IQueryable<Offer> GetEntriesForDriver(string userId) {
            return _context.Offer.Include(o => o.Driver).Include(o => o.PassengerTrips).Where(o => o.DriverId == userId);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}