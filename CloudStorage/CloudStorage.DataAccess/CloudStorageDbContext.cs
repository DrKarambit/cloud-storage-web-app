using CloudStorage.Domain.Authentication;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CloudFile = CloudStorage.Domain.CloudFiles.CloudFile;

namespace CloudStorage.DataAccess
{
    public class CloudStorageDbContext: IdentityDbContext<ApplicationUser, Role, string>, IPersistedGrantDbContext
    {
        public CloudStorageDbContext()
        {

        }

        public CloudStorageDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
        public DbSet<Key> Keys { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

        // DomainEntities
        public DbSet<CloudFile> CloudFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                // TODO: update relative path to be nice
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\CloudStorage")
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigurationStoreOptions storeConfigurationOptions = new();
            OperationalStoreOptions storeOperationalOptions = new();

            builder.ConfigureClientContext(storeConfigurationOptions);
            builder.ConfigureResourcesContext(storeConfigurationOptions);
            builder.ConfigurePersistedGrantContext(storeOperationalOptions);

            builder.Entity<CloudFile>(b =>
            {
                b.ToTable(string.Concat(nameof(CloudFile), "s"));
            });


            var admin = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@admin.com",
            };

            var x = new PasswordHasher().HashPassword("Asdf1234;");
            admin.PasswordHash = x;

            builder.Entity<ApplicationUser>().HasData(admin);
        }
    }
}
