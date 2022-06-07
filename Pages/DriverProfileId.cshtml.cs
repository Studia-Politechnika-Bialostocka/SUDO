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
    public class DriverProfileIdModel: PageModel
    {
        private readonly IDriverProfileService _driverProfileService;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public DriverProfileVM DriverProfile {get; set;}
        public string CurrentUserId {get; set;}

        public DriverProfileIdModel(IDriverProfileService driverProfileService, UserManager<ApplicationUser> userManager)
        {
            _driverProfileService = driverProfileService;
            _userManager = userManager; 
        }

        public void OnGet(string driverProfileId)
        {    
            DriverProfile = _driverProfileService.GetDriverProfileByCurrentUser(driverProfileId);
        }
    }
}