using Scooters.WebAPI.IoC;
using Scooters.WebAPI.Settings;

// �������� ������� ������������ �� ������ ����� appsettings.json.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = ScootersSettingsReader.Read(configuration);
var builder = WebApplication.CreateBuilder();

// ����������� ������������ ��� ��������� HTTP-��������.
builder.Services.AddControllers();

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

// ���������� ������� ����������.
var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

// ��������� ������������� ����� ��� ��������������� HTTP-��������
// � HTTPS, �������������� � ��������� ������������.
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();
