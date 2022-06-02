using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.Interfaces.Offers;
using SUDO.Interfaces.Users;
using SUDO.Interfaces.DriverProfiles;
using SUDO.Services;
using SUDO.Repositories;

namespace SUDO
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services) {
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDriverProfileService, DriverProfileSevice>();
            services.AddTransient<IDriverProfileRepository, DriverProfileRepository>();
            return services;
        }
    }
}