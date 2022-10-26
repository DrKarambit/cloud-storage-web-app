using CloudStorage;
using CloudStorage.DataAccess;
using CloudStorage.Domain;
using CloudStorage.Domain.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

var separatedAngularCorsPolicy = "_separatedAngularCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: separatedAngularCorsPolicy,
        policy => 
        {
            policy.WithOrigins("https://localhost:44419", "https://localhost:7060")
                .AllowAnyHeader()
                .AllowCredentials();
        });
    });

var connectionString = builder.Configuration.GetConnectionString("AppDb");
DataAccessServiceConfigurator.ConfigureServices(builder.Services, connectionString);

builder.Services.AddAutoMapper(typeof(ApiAutoMapperConfiguration)); 

DataAccessIocService.RegisterServices(builder.Services);
BusinessLogicIocServices.RegisterServices(builder.Services);

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<Role>()
    .AddEntityFrameworkStores<CloudStorageDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, CloudStorageDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    // Register other policies here
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(separatedAngularCorsPolicy);

//app.UseAuthentication();
//app.UseIdentityServer();
//app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}"
    );

app.MapFallbackToFile("index.html"); ;

app.Run();
