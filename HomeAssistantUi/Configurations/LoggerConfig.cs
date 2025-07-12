using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace HomeAssistantUi.Configurations;

public static class LoggerConfig
{
    public static IServiceCollection RegisterLogger(this IServiceCollection services)
    {
        var levelSwitch = new LoggingLevelSwitch
        {
            MinimumLevel = LogEventLevel.Information
        };

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
            .WriteTo.BrowserConsole(levelSwitch: levelSwitch)
            .CreateLogger();


        return services.AddLogging(loggingBuilder => loggingBuilder
            .AddSerilog(dispose: true));
    }
}
