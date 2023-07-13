using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using BusTracker.API.Profiles;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using CityTransport.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddNewtonsoftJson();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IBusesRepository, BusesRepository>();
builder.Services.AddScoped<IMetropolitanAreasRepository, MetropolitanAreasRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(MetropolitanAreaProfile));
builder.Services.AddDbContext<RatBVTransportContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RatBvDbConnection"));
    }
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

/**
 * Marks the position in  the mioddleware pipeline where a routing decision is made.
 */
app.UseRouting();

// Middleware that runs in between selecting thie endpoint and executing the selected endpoint can be injected

app.UseAuthorization();

/**
 * Marks the position in the middleware pipeline whre the selected endpoint is executed.
 */
app.UseEndpoints(endpoints =>
{
   endpoints.MapControllers();
});

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal");

// updating database to last migration by runing the app
using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<RatBVTransportContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration");
    }

await app.RunAsync();
