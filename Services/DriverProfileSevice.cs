using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Interfaces.Users;
using SUDO.Interfaces.Opines;
using SUDO.Models;
using SUDO.ViewModels.Opines;
using SUDO.ViewModels.DriverProfiles;

namespace SUDO.Services
{
    public class DriverProfileSevice : IDriverProfileService
    {
        private readonly IDriverProfileRepository _driverRepo;

        private readonly IUserRepository _userRepo;

        private readonly IOpinesRepository _opineRepo;

        public DriverProfileSevice(IDriverProfileRepository driverRepo, IUserRepository userRepo,IOpinesRepository opineRepo)
        {
            _driverRepo = driverRepo;
            _userRepo = userRepo;
            _opineRepo = opineRepo;
        }
        public void AddEntry(DriverProfileVM entry)
        {
            ApplicationUser UserP = _userRepo.GetEntryById(entry.UserId);
            DriverProfile driverProfile = new DriverProfile()
            {
                User = UserP,
                OpinesAboutUser = entry.OpinesAboutUser,
                UserOpines = entry.UserOpines,
            };
            _driverRepo.AddEntry(driverProfile);
        }

        public void AddOpine(OpineVM opinevm, string currentUserId, string commentedUserId)
        {
            DriverProfile currentDriver = _driverRepo.GetDriverProfileByUser(currentUserId);
            DriverProfile commentedUser = _driverRepo.GetDriverProfileByUser(commentedUserId);
            Opine opine = new Opine{
                DrivingRating = opinevm.DrivingRating,
                ProprietyRating = opinevm.ProprietyRating,
                PunctualityRating = opinevm.PunctualityRating,
                Comment = opinevm.Comment,
                CurrentUserId = currentUserId,
                CommentedUserId = commentedUserId
            };
            currentDriver.UserOpines.Add(opine);
            commentedUser.OpinesAboutUser.Add(opine);
            _driverRepo.SaveChanges();
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
                    UserName = driver.User.UserName,
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
            Console.WriteLine("id:"+id);
                var driver = _driverRepo.GetDriverProfileByUser(id);  
                var dVM = new DriverProfileVM()
                {
                    Id = driver.Id,
                    UserId = driver.User.Id,
                    UserName = driver.User.UserName,
                    OpinesAboutUser = driver.OpinesAboutUser,
                    UserOpines = driver.UserOpines
                };
            return dVM;
        }
    }
}