using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.Opines;
using SUDO.Models;
using SUDO.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace SUDO.Repositories
{
    public class OpineRepository : IOpinesRepository
    {
        private readonly SUDOIdentityDbContext _context;

        public OpineRepository(SUDOIdentityDbContext context) {
            _context = context;
        }
        public void AddEntry(Opine entry)
        {
            _context.Opine.Add(entry);
            _context.SaveChanges();
        }

        public IQueryable<Opine> GetAllEntries()
        {
            return _context.Opine;
        }

        public Opine GetOpineById(int id)
        {
            return _context.Opine.First(o => o.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}