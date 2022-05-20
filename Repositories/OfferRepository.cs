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
            return _context.Offer.Include(o => o.Driver);
        }
    }
}