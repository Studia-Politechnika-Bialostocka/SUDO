using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SUDO.Interfaces.DriverProfiles;
using SUDO.ViewModels.DriverProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SUDO.Models;

namespace SUDO.Pages
{
    [Authorize]
    public class DriverProfileModel: PageModel
    {
        private readonly IDriverProfileService _driverProfileService;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public DriverProfileVM DriverProfile {get; set;}
        public string CurrentUserId {get; set;}

        public DriverProfileModel(IDriverProfileService driverProfileService, UserManager<ApplicationUser> userManager)
        {
            _driverProfileService = driverProfileService;
            _userManager = userManager; 
        }

        public void OnGet()
        {
            CurrentUserId = _userManager.GetUserId(User);
            DriverProfileVM vm = new DriverProfileVM{Id = 1,UserId=CurrentUserId,OpinesAboutUser= new List<Opine>(),UserOpines=new List<Opine>()};
            _driverProfileService.AddEntry(vm);
            DriverProfile = _driverProfileService.GetDriverProfileByCurrentUser(CurrentUserId);
        }
    }
}