namespace TestApp.Application.Commons.Exceptions;

using System.Net;

public class ConflictException(string message) : TestAppException(message)
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.Conflict;
}