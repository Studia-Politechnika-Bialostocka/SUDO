using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Models;

namespace SUDO.Interfaces.Opines
{
    public interface IOpinesRepository
    {
        void AddEntry(Opine entry);
        IQueryable<Opine> GetAllEntries();
        Opine GetOpineById(int id);
        void SaveChanges();
    }
}