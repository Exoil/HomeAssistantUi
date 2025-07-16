using System.Net;

namespace HomeAssistantUi.Common.Exceptions;

public sealed class ExternalServiceHttpException : Exception
{
    public ProblemDetails? ProblemDetails { get; init; }
    public readonly HttpStatusCode StatusCode;

    public ExternalServiceHttpException(ProblemDetails problemDetails)
        :base(problemDetails.Title)
    {
        ProblemDetails = problemDetails;
        StatusCode = problemDetails.Status.HasValue ? (HttpStatusCode)problemDetails.Status : HttpStatusCode.InternalServerError;
    }
}
