using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerDomain
{
    /// <summary>
    /// Extension class to make it easy to specify services that need to be dependency injected for customers domain
    /// N.B. the generic variant allows you to specify your own classes for mocking
    /// </summary>
    public static class CustomersServiceExtensions
    {
        public static void AddCustomersDomain<S, N>(this IServiceCollection services)
            where S : class, ICustomerStore
            where N : class, ICustomerNotify
        {
            if (services.FirstOrDefault(s => s.ServiceType == typeof(ICustomerStore)) != null)
                services.AddScoped<S>();
            if (services.FirstOrDefault(s => s.ServiceType == typeof(ICustomerNotify)) != null)
                services.AddScoped<N>();
        }

        public static void AddCustomersDomain(this IServiceCollection services)
        {
            services.AddCustomersDomain<CustomerStore, CustomerNotify>();
        }
    }
}
