using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.ViewModels.User;

namespace SUDO.Interfaces.Users
{
    public interface IUserService
    {
        UserWithTripsVM GetUserWithTrips(string userId);
    }
}