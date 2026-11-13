using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Chantin.Api.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Status = GetStatusCode(exception),
            Title = GetTitle(exception),
            Detail = GetDetail(exception),
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static int GetStatusCode(Exception exception) => exception switch
    {
        ArgumentException => 400,
        KeyNotFoundException => 404,
        UnauthorizedAccessException => 401,
        InvalidOperationException => 409,
        _ => 500
    };

    private static string GetTitle(Exception exception) => exception switch
    {
        ArgumentException => "Bad Request",
        KeyNotFoundException => "Not Found",
        UnauthorizedAccessException => "Unauthorized",
        InvalidOperationException => "Conflict",
        _ => "Internal Server Error"
    };

    private static string GetDetail(Exception exception) => exception switch
    {
        ArgumentException ex => ex.Message,
        KeyNotFoundException ex => ex.Message,
        UnauthorizedAccessException ex => ex.Message,
        InvalidOperationException ex => ex.Message,
        _ => "An unexpected error occurred. Please try again later."
    };
}
