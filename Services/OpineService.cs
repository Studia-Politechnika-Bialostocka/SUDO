using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SUDO.Interfaces.Opines;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Interfaces.Users;
using SUDO.Models;
using SUDO.ViewModels.Opines;

namespace SUDO.Services
{
    public class OpineService : IOpinesService
    {
        private readonly IOpinesRepository _opineRepo;

        private readonly IDriverProfileRepository _driverRepo;

        public OpineService(IOpinesRepository opineRepo, IDriverProfileRepository driverRepo)
        {
            _opineRepo = opineRepo;
            _driverRepo = driverRepo;
        }
        public void AddEntry(OpineVM entry)
        {
            Opine opine = new Opine()
            {
                DrivingRating = entry.DrivingRating,
                ProprietyRating = entry.ProprietyRating,
                PunctualityRating = entry.PunctualityRating,
                Comment = entry.Comment,
                CurrentUserId = entry.CurrentUserId,
                CommentedUserId = entry.CommentedUserId
            };
            _opineRepo.AddEntry(opine);
        }

        public OpineListVM GetAllEntries()
        {
            var opines = _opineRepo.GetAllEntries();
            OpineListVM result = new OpineListVM();

            result.Opines = new List<OpineVM>();
            foreach (var opine in opines)
            {
                var oVM = new OpineVM()
                {
                    DrivingRating = opine.DrivingRating,
                    ProprietyRating = opine.ProprietyRating,
                    PunctualityRating = opine.PunctualityRating,
                    CurrentUserId = opine.CurrentUserId,
                    CommentedUserId = opine.CommentedUserId,
                };
                result.Opines.Add(oVM);
            }
            result.Count = result.Opines.Count;
            return result;
        }

        public OpineVM GetOpineById(int id)
        {
            Opine opine = _opineRepo.GetOpineById(id);

            var oVM = new OpineVM()
            {
                Id = opine.Id,
                DrivingRating = opine.DrivingRating,
                ProprietyRating = opine.ProprietyRating,
                PunctualityRating = opine.PunctualityRating,
                Comment = opine.Comment,
                CurrentUserId = opine.CurrentUserId,
                CommentedUserId = opine.CommentedUserId,
            };
            return oVM;
        }
    }
}