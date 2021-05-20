using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CustomerDomain
{
    /// <summary>
    /// Extension class to make it easy to specify services that need to be dependency injected for customers domain
    /// N.B. the generic variant allows you to specify your own classes for mocking
    /// </summary>
    public static class CustomersServiceExtensions
    {
        public static void AddCustomersDomain<R, E>(this IServiceCollection services)
            where R : class, ICustomerRepository
            where E : class, ICustomerEvents
        {
            // Make sure you only register a service if it is not already registered
            services.TryAddScoped<R>();
            services.TryAddScoped<E>();
        }

        public static void AddCustomersDomain(this IServiceCollection services)
        {
            services.AddCustomersDomain<CustomerRepository, CustomerEvents>();
        }
    }
}
