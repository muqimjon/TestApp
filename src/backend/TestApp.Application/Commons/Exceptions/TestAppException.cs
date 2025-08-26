using System.Net;

namespace TestApp.Application.Commons.Exceptions;

public class TestAppException(string message, HttpStatusCode Status) : Exception(message)
{
    public HttpStatusCode StatusCode { get; init; } = Status;
}
