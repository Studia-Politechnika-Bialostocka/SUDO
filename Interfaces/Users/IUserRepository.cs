using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Models;

namespace SUDO.Interfaces.Users
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetAllEntries();

        ApplicationUser GetEntryById(string Id);
    }
}