using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CloudStorage.DataAccess
{
    public static class DataAccessServiceConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CloudStorageDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
