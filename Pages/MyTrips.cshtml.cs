using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SUDO.ViewModels.User;
using SUDO.Models;
using SUDO.Interfaces.Users;

namespace SUDO.Pages
{
    [Authorize]
    public class MyTripsModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        public UserWithTripsVM CurrentUser {get; set;}


        public MyTripsModel(UserManager<ApplicationUser> userManager, IUserService userService) {
            _userManager = userManager;
            _userService = userService;
        }

        public async void OnGet()
        {   
            CurrentUser = _userService.GetUserWithTrips(_userManager.GetUserId(User));
            
        }
    }
}
