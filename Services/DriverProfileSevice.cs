using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Interfaces.Users;
using SUDO.Models;
using SUDO.ViewModels.DriverProfiles;

namespace SUDO.Services
{
    public class DriverProfileSevice : IDriverProfileService
    {
        private readonly IDriverProfileRepository _driverRepo;

        private readonly IUserRepository _userRepo;

        public DriverProfileSevice(IDriverProfileRepository driverRepo, IUserRepository userRepo)
        {
            _driverRepo = driverRepo;
            _userRepo = userRepo;
        }
        public void AddEntry(DriverProfileVM entry)
        {
            ApplicationUser UserP = _userRepo.GetEntryById(entry.UserId);
            DriverProfile driverProfile = new DriverProfile()
            {
                Id = entry.Id,
                User = UserP,
                OpinesAboutUser = entry.OpinesAboutUser,
                UserOpines = entry.UserOpines,
            };
            _driverRepo.AddEntry(driverProfile);
        }

        public DriverProfileListVM GetAllEntries()
        {
            var drivers = _driverRepo.GetAllEntries();
            DriverProfileListVM result = new DriverProfileListVM();

            result.Users = new List<DriverProfileVM>();
            foreach (var driver in drivers)
            {
                var dVM = new DriverProfileVM()
                {
                    Id = driver.Id,
                    UserId = driver.User.Id,
                    OpinesAboutUser = driver.OpinesAboutUser,
                    UserOpines = driver.UserOpines
                };
                result.Users.Add(dVM);
            }

            result.Count = result.Users.Count;
            return result;
        }

        public DriverProfileVM GetDriverProfileByCurrentUser(string id)
        {
                var driver = _driverRepo.GetDriverProfileByUser(id);  
                var dVM = new DriverProfileVM()
                {
                    Id = driver.Id,
                    UserId = driver.User.Id,
                    OpinesAboutUser = driver.OpinesAboutUser,
                    UserOpines = driver.UserOpines
                };
            return dVM;
        }
    }
}