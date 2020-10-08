using System;
using Microsoft.Extensions.DependencyInjection;

namespace BlockUI.Blazor
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers dependencies required for Blazor component <see cref="BlockUserInterface"/>
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Service collection with registered dependencies.</returns>
        public static IServiceCollection AddBlockUserInterface(this IServiceCollection services)
        {
            if (null == services) throw new ArgumentNullException(nameof(services));

            return services
                .AddScoped<IBlockUserInterfaceService, BlockUserInterfaceService>()
                .AddScoped<IBlockInternalService, BlockInternalService>();
        }
    }
}