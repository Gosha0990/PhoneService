using Microsoft.Extensions.DependencyInjection;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPhoneServiceCore(this IServiceCollection services) 
        {
            services.AddSingleton<IPhoneServiceCore, PhoneServiceCore>();

            return services;
        }
    }
}
