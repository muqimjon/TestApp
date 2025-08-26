namespace TestApp.Application.Commons.Exceptions;

using System.Net;

public class NotFoundException(string message) : TestAppException(message)
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.NotFound;
}