namespace Scooters.Service.IoC
{
    public class SwaggerConfigurator
    {
        /// <summary>
        /// Настройка служб Swagger.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            // Добавление служб, которые необходимы для разбора и анализа
            // конечных точек API.
            // Необходимо для генерации документации Swagger.
            services.AddEndpointsApiExplorer();

            // Добавление служб, которые необходимы для генерации
            // документации Swagger.
            services.AddSwaggerGen();
        }

        /// <summary>
        /// Настройка приложения для работы с Swagger.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureApplication(IApplicationBuilder app)
        {
            // Включение генерации и предоставление документации
            // в формате Swagger JSON.
            app.UseSwagger();

            // Предоставление пользовательского интерфейса для взаимодействия
            // с документацией API.
            app.UseSwaggerUI();
        }
    }
}
