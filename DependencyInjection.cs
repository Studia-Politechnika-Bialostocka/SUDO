using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.Offers;
using SUDO.Interfaces.Users;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Interfaces.Opines;
using SUDO.Interfaces.Users;
using SUDO.Services;
using SUDO.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SUDO
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services) {
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDriverProfileService, DriverProfileSevice>();
            services.AddTransient<IDriverProfileRepository, DriverProfileRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IOpinesRepository, OpineRepository>();
            services.AddTransient<IOpinesService, OpineService>();
            return services;
        }
    }
}