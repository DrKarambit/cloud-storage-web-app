using CloudStorage.Domain;
using CloudStorage.Domain.CloudFiles;
using Microsoft.Extensions.DependencyInjection;

namespace CloudStorage.DataAccess
{
    public static class DataAccessIocService
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<CloudFile>, GenericRepository<CloudFile>>();

            return services;
        }
    }
}
