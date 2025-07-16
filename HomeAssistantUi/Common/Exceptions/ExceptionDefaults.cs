namespace HomeAssistantUi.Common.Exceptions;

public static class ExceptionDefaults
{
    public static readonly ProblemDetails GetDefaultProblemDetails = new()
    {
        Type = "https://httpstatuses.com/500",
        Title = "Undefined error.",
        Detail = "Unepxected error.",
        Status = 500,
        Instance = "urn:error:undefined"
    };
}
