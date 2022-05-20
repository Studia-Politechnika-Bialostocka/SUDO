using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using SUDO.Models;


namespace SUDO.Areas.Identity
{
    public class MySignInManager : SignInManager<ApplicationUser>
    {
        public MySignInManager(UserManager<ApplicationUser> userManager, 
                               IHttpContextAccessor contextAccessor, 
                               IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, 
                               IOptions<IdentityOptions> optionsAccessor, 
                               ILogger<SignInManager<ApplicationUser>> logger, 
                               IAuthenticationSchemeProvider schemes,
                               IUserConfirmation<ApplicationUser> confirmation) : base(userManager, 
                                                                                       contextAccessor, 
                                                                                       claimsFactory, 
                                                                                       optionsAccessor, 
                                                                                       logger, 
                                                                                       schemes, 
                                                                                       confirmation) {}
        

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password,
            bool isPersistent, bool lockoutOnFailure)
        {
            var user = await UserManager.FindByEmailAsync(userName);
            if (user == null)
            {
                return SignInResult.Failed;
            }

            return await PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }
    }
}