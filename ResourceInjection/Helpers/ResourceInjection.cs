using ldy985.ResourceInjection.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace ldy985.ResourceInjection.Helpers
{
    /// <summary>Helper to add the services to the service collection.</summary>
    public static class ResourceInjection
    {
        /// <summary>Adds the resource injection service</summary>
        /// <param name="services"></param>
        /// <param name="strict">strict throws if multiple resources have same name.</param>
        public static void AddResourceInjection(this IServiceCollection services, bool strict = false)
        {
            if (strict)
                services.AddScoped<IResourceService, StrictResourceService>();
            else
                services.AddScoped<IResourceService, ResourceService>();
        }
    }
}