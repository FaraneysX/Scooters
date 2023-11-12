using Scooters.WebAPI.IoC;
using Scooters.WebAPI.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = ScootersSettingsReader.Read(configuration);
var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();
