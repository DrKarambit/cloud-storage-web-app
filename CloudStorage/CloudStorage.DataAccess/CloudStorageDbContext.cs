using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CloudFile = CloudStorage.Domain.CloudFiles.CloudFile;

namespace CloudStorage.DataAccess
{
    public class CloudStorageDbContext : DbContext
    {
        // FIY: it is required for migrations
        public CloudStorageDbContext()
        {

        }

        public CloudStorageDbContext(DbContextOptions<CloudStorageDbContext> options) : base(options)
        {

        }


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

            builder.Entity<CloudFile>(b =>
            {
                b.ToTable(string.Concat(nameof(CloudFile), "s"));
            });
        }
    }
    }
