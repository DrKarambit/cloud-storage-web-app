using CloudStorage.Domain.CloudFiles;
using Microsoft.Extensions.DependencyInjection;

namespace CloudStorage.Domain
{
    public static class BusinessLogicIocServices
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICloudFilesApplicationService, CloudFilesApplicationService>();

            return services;
        }
    }
}
