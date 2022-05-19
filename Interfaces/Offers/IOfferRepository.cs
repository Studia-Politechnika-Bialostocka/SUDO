using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Models;

namespace SUDO.Interfaces.Offers
{
    public interface IOfferRepository
    {
        void AddEntry(Offer entry);
        IQueryable<Offer> GetAllEntries();
    }
}