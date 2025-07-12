using HomeAssistantUi.Common;
using HomeAssistantUi.Services;

namespace HomeAssistantUi.Configurations;

public static class ServicesConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<HomeAssistantApiOptions>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return configuration.GetSection("HomeAssistant").Get<HomeAssistantApiOptions>() ?? throw new InvalidOperationException("HomeAssistantApi section is not configured.");
            })
            .AddScoped<IHomeAssistantApiService, HomeAssistantApiService>();
    }
}
