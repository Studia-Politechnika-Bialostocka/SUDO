using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Areas.Identity.Data;
using SUDO.Interfaces.Users;
using SUDO.Models;

namespace SUDO.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly SUDOIdentityDbContext _context;

        public UserRepository(SUDOIdentityDbContext context) {
            _context = context;
        }


        public IQueryable<ApplicationUser> GetAllEntries() {
            return _context.Users;
        }
        public ApplicationUser GetEntryById(string Id) {
            return _context.Users.First(u => u.Id == Id);
        }
    }
}