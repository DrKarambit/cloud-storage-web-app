using CloudStorage.DataAccess;
using CloudStorage.Domain;

var builder = WebApplication.CreateBuilder(args);

var separatedAngularCorsPolicy = "_separatedAngularCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: separatedAngularCorsPolicy,
        policy => 
        {
            policy.WithOrigins("https://localhost:44419", "https://localhost:7060").AllowAnyHeader();
        });
    });

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppDb");
DataAccessServiceConfigurator.ConfigureServices(builder.Services, connectionString);

DataAccessIocService.RegisterServices(builder.Services);
BusinessLogicIocServices.RegisterServices(builder.Services);

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
