using Serilog;

namespace Scooters.Service.IoC
{
    public class SerilogConfigurator
    {
        /// <summary>
        /// Настройка логирования на уровне сервисов приложения.
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                // Добавление идентификатора корреляции к логам.
                // Чтение настроек логирования из конфигурации приложения.
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            // Добавление службы доступа к контексту HTTP.
            builder.Services.AddHttpContextAccessor();
        }

        /// <summary>
        /// Настройка логирования на уровне приложения.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureApplication(IApplicationBuilder app)
        {
            // Использование Serilog для логирования HTTP-запросов.
            app.UseSerilogRequestLogging();
        }
    }
}
