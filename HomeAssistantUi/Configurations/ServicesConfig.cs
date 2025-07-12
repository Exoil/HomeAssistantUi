using HomeAssistantUi.Services;

namespace HomeAssistantUi.Configurations;

public static class ServicesConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services
                .AddScoped<IHomeAssistantApiService, HomeAssistantApiService>();
    }
}
